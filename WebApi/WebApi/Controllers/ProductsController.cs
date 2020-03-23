using Business.Dto.Coffee;
using Business.Dto.Search;
using CMS.DocumentEngine;
using CMS.DocumentEngine.Types.DancingGoatMvc;
using CMS.Ecommerce;
using CMS.EventLog;
using CMS.Helpers;
using CMS.Localization;
using CMS.Membership;
using CMS.Search;
using CMS.SiteProvider;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Web.Http;
using WebApi.Models;

namespace WebApi.Controllers
{
    [RoutePrefix("Products")]
    public class ProductsController : ApiController
    {
        private const string INDEX_NAME = "DancingGoat.COFFEEANDBREWER";
        private const int PAGE_SIZE = 100;
        private const int DEFAULT_PAGE_NUMBER = 1;
        private const string cultureCode = "en-us";
        public Response<SearchResultDto> GetProducts()
        {
            List<SearchResultDto> data = GetAllProducts().ToList();
            return new Response<SearchResultDto>
            {
                StatusCode = HttpStatusCode.OK,
                Success = true,
                Message = "All Products.",
                Data = data
            };
        }
        [Route("Get")]
        [HttpPost]
        public Response<SearchResultDto> Get(Filter filter)
        {
            try
            {
                EventLogProvider.LogInformation("Product Search", JsonConvert.SerializeObject(filter), Convert.ToString(filter));
                if (filter?.SearchText == null)
                {
                    return new Response<SearchResultDto>
                    {
                        StatusCode = HttpStatusCode.OK,
                        Success = true,
                        Message = "All products Data",
                        Data = GetAllProducts().ToList()
                    };
                }
                else
                {
                    UserInfo searchUser = MembershipContext.AuthenticatedUser;
                    /* Indicates whether the search service uses site default language version of pages as a replacement
                    for pages that are not translated into the language specified by 'cultureCode' */
                    bool combineWithDefaultCulture = true;

                    // Prepares a 'SearchParameters' object to search through indexes of the 'Pages' type
                    SearchParameters searchParametersAdvanced = SearchParameters.PrepareForPages(filter.SearchText, new[] { INDEX_NAME }, DEFAULT_PAGE_NUMBER, PAGE_SIZE, searchUser, cultureCode, combineWithDefaultCulture);
                    // Searches the specified indexes
                    SearchResult searchResults = SearchHelper.Search(searchParametersAdvanced);
                    EventLogProvider.LogInformation("Product Search count", searchResults.Items.Count.ToString(), "");
                    List<SearchResultDto> results = searchResults.Items
                    .AsEnumerable()
                    .Where(x => ValidationHelper.GetString(x.GetSearchValue("ClassName"), string.Empty).Replace('.', '-').ToLower().Contains(filter.Category == null ? string.Empty : filter.Category.ToLower()))
                    .Where(x => ValidationHelper.GetDouble(x.GetSearchValue("SKUPrice"), 0.00) >= (filter?.price?.MinPrice == null ? double.MinValue : filter?.price?.MinPrice))
                    .Where(x => ValidationHelper.GetDouble(x.GetSearchValue("SKUPrice"), 0.00) <= (filter?.price?.MaxPrice == null ? double.MaxValue : filter?.price?.MaxPrice))
                    .Select(x =>
                    {
                        return new SearchResultDto()
                        {
                            Image = @URLHelper.GetAbsoluteUrl(x.GetImageUrl()?.Replace("/WebApi", "")),
                            Date = x.Created,
                            Content = x.Content,
                            Title = x.Title,
                            Price = ValidationHelper.GetDouble(x.GetSearchValue("SKUPrice"), 0.00),
                            Type = ValidationHelper.GetString(x.GetSearchValue("ClassName"), string.Empty).Replace('.', '-')

                        };
                    })
                    .ToList();
                    EventLogProvider.LogInformation("Product Search count", results.Count.ToString(), "");
                    List<string> processing = filter?.facets?.CoffeeProcessing?.ToLower().Split(',').ToList();
                    if (processing != null)
                    {
                        results = results
                            .Where(x => processing.Contains(x.Content))
                            .ToList();
                    }
                    EventLogProvider.LogInformation("Product Search count", results.Count.ToString(), "");
                    return new Response<SearchResultDto>
                    {
                        StatusCode = HttpStatusCode.OK,
                        Success = true,
                        Message = "Product search Result.",
                        Data = results
                    };
                }
            }
            catch (Exception ex)
            {
                EventLogProvider.LogException("ProductsController", "Get", ex);
                throw;
            }
        }

        [Route("Facets")]
        public Response<FacetsData> GetProductFacets(string category)
        {
            List<FacetsData> facets = new List<FacetsData>();
            //category = category.Replace('-', '.').ToLower();
            switch (category.ToLower())
            {
                case "dancinggoatmvc-brewer":
                    facets = GetBrewerFacets(category);
                    break;
                case "dancinggoatmvc-coffee":
                    facets = GetCoffeeFacets(category);
                    break;
                case "dancinggoatmvc-car":
                    facets = GetCarFacets(category);
                    break;
                default:
                    break;
            }
            return new Response<FacetsData>
            {
                StatusCode = HttpStatusCode.OK,
                Success = true,
                Message = "Product Facets.",
                Data = facets
            };
        }

        [HttpPost]
        [Route("Create")]
        public Response<SKUTreeNode> createCoffee(Object createProduct)
        {
            var product =  (ProductInfo<CoffeeDto>)createProduct;
            try
            {
                string productType = product.Sku.ProductType;
                // Gets a department
                DepartmentInfo department = DepartmentInfoProvider.GetDepartmentInfo(productType + "s", SiteContext.CurrentSiteName);

                // Creates a new product object
                SKUInfo newProduct = new SKUInfo
                {
                    // Sets the product properties
                    SKUName = product.Sku.SKUName,
                    SKUNumber = product.Sku.SKUNumber,
                    SKUPrice = product.Sku.SKUPrice,
                    SKUEnabled = product.Sku.SKUEnabled
                };
                if (department != null)
                {
                    newProduct.SKUDepartmentID = department.DepartmentID;
                }
                newProduct.SKUSiteID = SiteContext.CurrentSiteID;

                // Saves the product to the database
                // Note: Only creates the SKU object. You also need to create a connected product page to add the product to the site.
                SKUInfoProvider.SetSKUInfo(newProduct);

                // Gets a TreeProvider instance
                TreeProvider tree = new TreeProvider(MembershipContext.AuthenticatedUser);

                // Gets the parent page
                TreeNode parent = tree.SelectNodes("DancingGoatMvc.ProductSection")
                    .Path("/Products/" + productType + "s")
                    .OnCurrentSite()
                    .FirstOrDefault();

                if ((parent != null) && (newProduct != null))
                {
                    // Creates a new product page of the 'CMS.Product' type
                    SKUTreeNode node = (SKUTreeNode)TreeNode.New(Coffee.CLASS_NAME, tree);

                    // Sets the product page properties
                    node.DocumentSKUName = product.Sku.SKUName;
                    node.DocumentCulture = LocalizationContext.PreferredCultureCode;

                    //Sets a value for a field of the given product page type

                    PropertyInfo[] properties = product.CustomProperties.GetType().GetProperties();
                    foreach (PropertyInfo pi in properties)
                    {
                        node.SetValue(pi.Name, pi.GetValue(product.CustomProperties, null));
                    }

                    // Assigns the product to the page
                    node.NodeSKUID = newProduct.SKUID;

                    node.DocumentName = product.Sku.SKUName;

                    // Saves the product page to the database
                    node.Insert(parent);
                    return new Response<SKUTreeNode>
                    {
                        StatusCode = HttpStatusCode.OK,
                        Success = true,
                        Message = "Product Created Successfully.",
                        Data = null
                    };
                }
                return new Response<SKUTreeNode>
                {
                    StatusCode = HttpStatusCode.InternalServerError,
                    Success = false,
                    Message = "Product type name is not correct.",
                    Data = null
                };
            }
            catch (Exception ex)
            {
                EventLogProvider.LogException("CreateProduct", ex.StackTrace, ex);
                return new Response<SKUTreeNode>
                {
                    StatusCode = HttpStatusCode.InternalServerError,
                    Success = false,
                    Message = ex.Message,
                    Data = null
                };
            }
        }

        

        //private void CreateProduct(string productType, DataRow product)
        //{
        //    try
        //    {
        //        string productName = ValidationHelper.GetString(product["Name"], string.Empty);


        //        Creates a new product object
        //       SKUInfo newProduct = new SKUInfo
        //       {
        //             Sets the product properties
        //            SKUName = productName,
        //            SKUNumber = productName,
        //            SKUPrice = ValidationHelper.GetDecimal(product["Price"], decimal.Zero),
        //            SKUEnabled = true
        //       };

        //        newProduct.SKUSiteID = SiteContext.CurrentSiteID;

        //        Saves the product to the database
        //         Note: Only creates the SKU object.You also need to create a connected product page to add the product to the site.
        //       SKUInfoProvider.SetSKUInfo(newProduct);

        //        Gets a TreeProvider instance
        //        TreeProvider tree = new TreeProvider(MembershipContext.AuthenticatedUser);

        //        Gets the parent page
        //        TreeNode parent = tree.SelectNodes("DancingGoatMvc.ProductSection")
        //            .Path("/Products/" + productType + "s")
        //            .OnCurrentSite()
        //            .FirstOrDefault();

        //        if ((parent != null) && (newProduct != null))
        //        {
        //            Creates a new product page of the 'CMS.Product' type
        //           SKUTreeNode node = (SKUTreeNode)TreeNode.New("DancingGoatMvc." + productType, tree);

        //            Sets the product page properties
        //            node.DocumentSKUName = productName;
        //            node.DocumentCulture = LocalizationContext.PreferredCultureCode;

        //            Sets a value for a field of the given product page type

        //           node.SetValue("CoffeeFarm", "Farm 1");
        //            node.SetValue("CoffeeCountry", "India");
        //            node.SetValue("CoffeeVariety", "Criolla, Caturra");
        //            node.SetValue("CoffeeProcessing", "Washed");
        //            node.SetValue("CoffeeAltitude", 4110);

        //            node.SetValue("Company", ValidationHelper.GetString(product["Company"], string.Empty));
        //            node.SetValue("ModelYear", ValidationHelper.GetString(product["ModelYear"], string.Empty));

        //            Assigns the product to the page
        //            node.NodeSKUID = newProduct.SKUID;

        //            node.DocumentName = productName;

        //            Saves the product page to the database
        //            node.Insert(parent);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        EventLogProvider.LogException("CreateProduct", ex.StackTrace, ex);
        //    }
        //}
        private List<FacetsData> GetCarFacets(string category)
        {
            List<FacetsData> facets = new List<FacetsData>();
            IEnumerable<Car> cars = GetCachedCar();

            facets.Add(new FacetsData()
            {
                field = "",
                label = "Price Range",
                type = "range",
                collapse = true,
                facet_active = true,
                values = GetPriceRange(category, cars.Select(x => x.SKU.SKUPrice).Min().ToString("F"), cars.Select(x => x.SKU.SKUPrice).Max().ToString("F"))
            });
            return facets;
        }

        private IEnumerable<Car> GetCachedCar()
        {
            Func<IEnumerable<Car>> cars = () => CarProvider.GetCars();

            CacheSettings cacheSettings = new CacheSettings(10, "myapp|data|cars")
            {
                GetCacheDependency = () =>
                {
                    // Creates caches dependencies. This example makes the cache clear data when any article is modified, deleted, or created in Kentico.
                    string dependencyCacheKey = string.Format("nodes|{0}|all", Car.CLASS_NAME.ToLowerInvariant());
                    return CacheHelper.GetCacheDependency(dependencyCacheKey);
                }
            };

            return CacheHelper.Cache(cars, cacheSettings);
        }

        private List<FacetsData> GetCoffeeFacets(string category)
        {
            List<FacetsData> facets = new List<FacetsData>();
            IEnumerable<Coffee> coffees = GetCachedCoffees();

            facets.Add(new FacetsData()
            {
                field = "CoffeeProcessing",
                label = "Processing",
                type = "checkBox",
                collapse = true,
                facet_active = true,
                values = coffees
                .Select(x => x.CoffeeProcessing)
                .Distinct()
                .ToList()
                .Select(data =>
                {
                    return new FacetsValue()
                    {
                        active = true,
                        label = data,
                        value = data,
                        count = 0,
                    };
                })
                .ToList()
            });

            facets.Add(new FacetsData()
            {
                field = "",
                label = "Price Range",
                type = "range",
                collapse = true,
                facet_active = true,
                values = GetPriceRange(category, coffees.Select(x => x.SKU.SKUPrice).Min().ToString("F"), coffees.Select(x => x.SKU.SKUPrice).Max().ToString("F"))
            });
            return facets;
        }

        public IEnumerable<Coffee> GetCachedCoffees(int count = 0)
        {
            Func<IEnumerable<Coffee>> coffees = () => CoffeeProvider.GetCoffees();

            CacheSettings cacheSettings = new CacheSettings(10, "myapp|data|Coffees")
            {
                GetCacheDependency = () =>
                {
                    // Creates caches dependencies. This example makes the cache clear data when any article is modified, deleted, or created in Kentico.
                    string dependencyCacheKey = string.Format("nodes|{0}|all", Coffee.CLASS_NAME.ToLowerInvariant());
                    return CacheHelper.GetCacheDependency(dependencyCacheKey);
                }
            };

            return CacheHelper.Cache(coffees, cacheSettings);
        }

        private List<FacetsData> GetBrewerFacets(string category)
        {
            List<FacetsData> facets = new List<FacetsData>();
            IEnumerable<Brewer> brewers = GetCachedBrewer();

            facets.Add(new FacetsData()
            {
                field = "",
                label = "Price Range",
                type = "range",
                collapse = true,
                facet_active = true,
                values = GetPriceRange(category, brewers.Select(x => x.SKU.SKUPrice).Min().ToString("F"), brewers.Select(x => x.SKU.SKUPrice).Max().ToString("F"))
            });
            return facets;
        }

        private IEnumerable<Brewer> GetCachedBrewer()
        {
            Func<IEnumerable<Brewer>> brewers = () => BrewerProvider.GetBrewers();

            CacheSettings cacheSettings = new CacheSettings(10, "myapp|data|brewers")
            {
                GetCacheDependency = () =>
                {
                    // Creates caches dependencies. This example makes the cache clear data when any article is modified, deleted, or created in Kentico.
                    string dependencyCacheKey = string.Format("nodes|{0}|all", Brewer.CLASS_NAME.ToLowerInvariant());
                    return CacheHelper.GetCacheDependency(dependencyCacheKey);
                }
            };

            return CacheHelper.Cache(brewers, cacheSettings);
        }

        private List<FacetsValue> GetPriceRange(string category, string minPrice, string maxPrice)
        {
            List<FacetsValue> priceRange = new List<FacetsValue>
            {
                new FacetsValue()
                {
                    active = true,
                    label = "Min Price",
                    value = minPrice,
                    count = 0,
                },
                new FacetsValue()
                {
                    active = true,
                    label = "Max Price",
                    value = maxPrice,
                    count = 0,
                }
            };
            return priceRange;
        }
        private List<SearchResultDto> GetAllProducts()
        {
            return DocumentHelper.GetDocuments()
                .OrderBy("NodeOrder")
                .Types("DancingGoatMvc.Brewer", "DancingGoatMvc.Coffee", "DancingGoatMvc.Mobile", "DancingGoatMvc.Laptop", "DancingGoatMvc.Car")
                .AsEnumerable()
                .Select(x =>
                {
                    return new SearchResultDto()
                    {
                        Image = @URLHelper.GetAbsoluteUrl(ValidationHelper.GetString(x.GetValue("SKUImagePath"), string.Empty)).Replace("/WebApi", string.Empty),
                        Date = ValidationHelper.GetDateTime(x.GetValue("DocumentCreatedWhen"), DateTime.MinValue),
                        Content = ValidationHelper.GetString(x.GetValue("DocumentContent"), string.Empty),
                        Title = ValidationHelper.GetString(x.GetValue("DocumentName"), string.Empty),
                        Price = ValidationHelper.GetDouble(x.GetValue("SKUPrice"), 0.00),
                        Type = ValidationHelper.GetString(x.GetValue("ClassName"), string.Empty).Replace('.', '-')
                    };
                })
                .ToList();
        }

    }
}
