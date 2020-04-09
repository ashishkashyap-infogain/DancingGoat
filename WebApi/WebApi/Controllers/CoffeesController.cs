using Business.DependencyInjection;
using Business.Dto.Coffee;
using Business.Repository.Coffee;
using CMS.Base;
using CMS.DocumentEngine;
using CMS.DocumentEngine.Types.DancingGoatMvc;
using CMS.Ecommerce;
using CMS.EventLog;
using CMS.Helpers;
using CMS.Localization;
using CMS.Membership;
using CMS.SiteProvider;
using System;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Web.Http;
using WebApi.Models;
//using System.Web.WebPages;

namespace WebApi.Controllers
{
    //[RoutePrefix("Test")]
    [RoutePrefix("Coffees")]
    public class CoffeesController : ApiController
    {

        private ICoffeeRepository CoffeeRepository { get; }
        private IBusinessDependencies Dependencies { get; }

        //public CoffeesController(
        //    IBusinessDependencies dependencies,
        //    ICoffeeRepository coffeeRepository
        //    ) : base(dependencies)
        //{
        //    CoffeeRepository = coffeeRepository;
        //}
        public CoffeesController(
            ICoffeeRepository coffeeRepository
            )
        {
            CoffeeRepository = coffeeRepository;
        }
        private readonly ICoffeeRepository coffeeRepository = new CoffeeRepository();
        //public CoffeesController(IBusinessDependencies dependencies) : base(dependencies)
        //{
        //    CoffeeRepository = coffeeRepository;
        //}
        public CoffeesController()
        {
            CoffeeRepository = coffeeRepository;
        }
        [Route("Get")]
        public string Get()
        {
            //System.Collections.Generic.IEnumerable<Business.Dto.Coffee.CoffeeDto> data = CoffeeRepository.GetCoffees();
            return "Data";
        }

        [HttpPost]
        [Route("Create")]
        public Response<SKUTreeNode> CreateCoffee(CoffeeProductDto coffeeProduct)
        {
            try
            {
                string productType = coffeeProduct.Sku.ProductType;
                // Gets a department
                DepartmentInfo department = DepartmentInfoProvider.GetDepartmentInfo(productType + "s", SiteContext.CurrentSiteName);

                // Creates a new product object
                SKUInfo newProduct = new SKUInfo
                {
                    // Sets the product properties
                    SKUName = coffeeProduct.Sku.SKUName,
                    SKUNumber = coffeeProduct.Sku.SKUNumber,
                    SKUPrice = coffeeProduct.Sku.SKUPrice,
                    SKUEnabled = coffeeProduct.Sku.SKUEnabled
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
                    node.DocumentSKUName = coffeeProduct.Sku.SKUName;
                    node.DocumentCulture = LocalizationContext.PreferredCultureCode;

                    //Sets a value for a field of the given product page type

                    PropertyInfo[] properties = coffeeProduct.Coffee.GetType().GetProperties();
                    foreach (PropertyInfo pi in properties)
                    {
                        node.SetValue(pi.Name, pi.GetValue(coffeeProduct.Coffee, null));                        
                    }

                    // Assigns the product to the page
                    node.NodeSKUID = newProduct.SKUID;

                    node.DocumentName = coffeeProduct.Sku.SKUName;

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

        [HttpPost]
        [Route("Update")]
        public Response<SKUTreeNode> UpdateCoffee(CoffeeProductDto coffeeProduct)
        {
            try
            {
                string productType = coffeeProduct.Sku.ProductType;
                // Gets the product
                SKUInfo updateProduct = SKUInfoProvider.GetSKUInfo(coffeeProduct.Sku.SKUID);
                if (updateProduct != null)
                {
                    // Updates the product properties
                    updateProduct.SKUName = updateProduct.SKUName;
                    updateProduct.SKUNumber = coffeeProduct.Sku.SKUNumber;
                    updateProduct.SKUPrice = coffeeProduct.Sku.SKUPrice;
                    updateProduct.SKUEnabled = coffeeProduct.Sku.SKUEnabled;

                    // Saves the changes to the database
                    SKUInfoProvider.SetSKUInfo(updateProduct);
                }
                // Gets a TreeProvider instance
                TreeProvider tree = new TreeProvider(MembershipContext.AuthenticatedUser);

                // Gets the parent page
                TreeNode node = tree.SelectNodes("DancingGoatMvc.ProductSection")
                    .Path("/Products/" + productType + "s/"+coffeeProduct.Sku.SKUName)
                    .OnCurrentSite()
                    .FirstOrDefault();

                if (node != null)
                {
                    //Sets a value for a field of the given product page type
                    PropertyInfo[] properties = coffeeProduct.Coffee.GetType().GetProperties();
                    foreach (PropertyInfo pi in properties)
                    {
                        node.SetValue(pi.Name, pi.GetValue(coffeeProduct.Coffee, null));
                    }
                    // Saves the product page to the database
                    DocumentHelper.UpdateDocument(node, tree);
                    return new Response<SKUTreeNode>
                    {
                        StatusCode = HttpStatusCode.OK,
                        Success = true,
                        Message = "Product updated Successfully.",
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
                EventLogProvider.LogException("UpdateProduct", ex.StackTrace, ex);
                return new Response<SKUTreeNode>
                {
                    StatusCode = HttpStatusCode.InternalServerError,
                    Success = false,
                    Message = ex.Message,
                    Data = null
                };
            }
        }
    }
}
