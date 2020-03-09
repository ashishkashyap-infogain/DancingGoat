using Business.Dto.Search;
using CMS.DocumentEngine;
using CMS.DocumentEngine.Types.DancingGoatMvc;
using CMS.EventLog;
using CMS.Helpers;
using CMS.Membership;
using CMS.Search;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
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
        /// <summary>
        /// Smart Search for Products
        /// </summary>
        /// <param name="searchText"></param>
        /// <returns></returns>
        public Response<SearchResultDto> Get(string searchText = "", string type = "", double priceFrom = double.MinValue, double priceTo = double.MaxValue)
        {
            try
            {
                if (searchText == "")
                {
                    return new Response<SearchResultDto>
                    {
                        StatusCode = HttpStatusCode.OK,
                        Success = true,
                        Message = "Product Search result.",
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
                    SearchParameters searchParametersAdvanced = SearchParameters.PrepareForPages(searchText, new[] { INDEX_NAME }, DEFAULT_PAGE_NUMBER, PAGE_SIZE, searchUser, cultureCode, combineWithDefaultCulture);
                    // Searches the specified indexes
                    //DancingGoatMvc.Brewer
                    SearchResult searchResults = SearchHelper.Search(searchParametersAdvanced);
                    List<SearchResultDto> results = searchResults.Items
                    .AsEnumerable()
                    .Where(x => ValidationHelper.GetString(x.GetSearchValue("ClassName"), string.Empty).Replace('.', '-').ToLower().Contains(type.ToLower()))
                    .Where(x => ValidationHelper.GetDouble(x.GetSearchValue("SKUPrice"), 0.00) > priceFrom)
                    .Where(x => ValidationHelper.GetDouble(x.GetSearchValue("SKUPrice"), 0.00) < priceTo)
                    .Select(x =>
                    {
                        return new SearchResultDto()
                        {
                            Image = x.GetImageUrl(),
                            Date = x.Created,
                            Content = x.Content,
                            Title = x.Title,
                            Price = ValidationHelper.GetDouble(x.GetSearchValue("SKUPrice"), 0.00),
                            Type = ValidationHelper.GetString(x.GetSearchValue("ClassName"), string.Empty).Replace('.', '-')
                        };
                    })
                    .ToList();
                    return new Response<SearchResultDto>
                    {
                        StatusCode = HttpStatusCode.OK,
                        Success = true,
                        Message = "Product Search Result.",
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
        public Response<Facets> GetProductFacets(string category)
        {
            List<Facets> facets = new List<Facets>();
            //category = category.Replace('-', '.').ToLower();
            switch (category)
            {
                case "DancingGoatMvc-Brewer":
                    facets = GetBrewerFacets();
                    break;
                case "DancingGoatMvc-Coffee":
                    facets = GetCoffeeFacets();
                    break;
                default:
                    break;
            }
            return new Response<Facets>
            {
                StatusCode = HttpStatusCode.OK,
                Success = true,
                Message = "Product Facets.",
                Data = facets
            };
        }

        private List<Facets> GetCoffeeFacets()
        {
            //var data = CoffeeProvider.GetCoffees();
            return null;
        }

        private List<Facets> GetBrewerFacets()
        {
            throw new NotImplementedException();
        }

        private List<Facets> GetProductsFacets(List<SearchResultDto> results)
        {
            List<Facets> facets = new List<Facets>();
            Facets newFacet = new Facets()
            {
                field = "product_type",
                label = "Product Type",
                type = "Products",
                collapse = true,
                facet_active = true,
                values = results
                .Select(s => s.Type)
                .Distinct()
                .Select(data =>
                {
                    return new FacetsValue()
                    {
                        active = true,
                        label = data.Split('-')[1],
                        value = data,
                        count = 0,
                    };
                })
                .ToList()
            };
            facets.Add(newFacet);
            newFacet = new Facets()
            {
                field = "price_range",
                label = "Prices",
                type = "Products",
                collapse = true,
                facet_active = true,
                values = GetPriceRange(results)
            };
            facets.Add(newFacet);
            return facets;
        }

        private List<FacetsValue> GetPriceRange(List<SearchResultDto> results)
        {
            return new List<FacetsValue>
            {
                new FacetsValue {active=true, label = "Prices",type="DancingGoatMvc-Coffee", value = "$0 - $50"},
                new FacetsValue {active=true, label = "Prices",type="DancingGoatMvc-Coffee", value = "$50 - $100"},
                new FacetsValue {active=true, label = "Prices",type="DancingGoatMvc-Brewer", value = "$0 - $50"},
                new FacetsValue {active=true, label = "Prices",type="DancingGoatMvc-Brewer", value = "$50 - $100"},
                new FacetsValue {active=true, label = "Prices",type="DancingGoatMvc-Mobile", value = "$0 - $500"},
                new FacetsValue {active=true, label = "Prices",type="DancingGoatMvc-Mobile", value = "$500 - $1000"},
                new FacetsValue {active=true, label = "Prices",type="DancingGoatMvc-Mobile", value = "$1000 - $1500"},
                new FacetsValue {active=true, label = "Prices",type="DancingGoatMvc-Car", value = "$0 - $3000"},
                new FacetsValue {active=true, label = "Prices",type="DancingGoatMvc-Car", value = "$3000 - $5000"},
                new FacetsValue {active=true, label = "Prices",type="DancingGoatMvc-Car", value = "$5000 - $8000"},
                new FacetsValue {active=true, label = "Prices",type="DancingGoatMvc-Car", value = "$8000 - $10000"},
            };
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
                        Image = @URLHelper.GetAbsoluteUrl(ValidationHelper.GetString(x.GetValue("SKUImagePath"), string.Empty)),
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
