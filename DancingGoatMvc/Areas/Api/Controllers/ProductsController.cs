using CMS.DocumentEngine;
using CMS.DocumentEngine.Types.DancingGoatMvc;
using CMS.Helpers;
using DancingGoat.Areas.Api.Dto;
using DancingGoat.Areas.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace DancingGoat.Areas.Api.Controllers
{
    public class ProductsController : ApiController
    {
        public Response<SearchResultDto> Get()
        {
            var data = GetAllProducts().ToList();
            return new Response<SearchResultDto>
            {
                StatusCode = HttpStatusCode.OK,
                Success = true,
                Message = "All Products.",
                Data = data
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
