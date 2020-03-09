using CMS.DocumentEngine;
using CMS.Helpers;
using DancingGoat.Areas.Api.Dto;
using DancingGoat.Areas.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Http;

namespace DancingGoat.Areas.Api.Controllers
{
    public class DocumentsController : ApiController
    {
        public Response<SearchResultDto> GetDocuments()
        {
            List<SearchResultDto> data = DocumentHelper.GetDocuments()
                .OrderBy("NodeOrder")
                .AsEnumerable()
                .Select(x =>
                {
                    return new SearchResultDto()
                    {
                        Image = ValidationHelper.GetString(x.GetValue("SKUImagePath"), string.Empty),
                        Date = ValidationHelper.GetDateTime(x.GetValue("DocumentCreatedWhen"), DateTime.MinValue),
                        Content = ValidationHelper.GetString(x.GetValue("DocumentContent"), string.Empty),
                        Title = ValidationHelper.GetString(x.GetValue("DocumentName"), string.Empty),
                        Price = ValidationHelper.GetDouble(x.GetValue("SKUPrice"), 0.00),
                        Type = ValidationHelper.GetString(x.GetValue("ClassName"), string.Empty).Replace('.', '-')
                    };
                })
                .ToList();
            return new Response<SearchResultDto>
            {
                StatusCode = HttpStatusCode.OK,
                Success = true,
                Message = "All documents.",
                Data = data
            };
        }
        private List<SearchResultDto> GetAllProducts()
        {
            return DocumentHelper.GetDocuments()
                .OrderBy("NodeOrder")
               // .Type("DancingGoatMvc.Brewer", "DancingGoatMvc.Coffee", "DancingGoatMvc.Mobile", "DancingGoatMvc.Laptop")
                .AsEnumerable()
                .Select(x =>
                {
                    return new SearchResultDto()
                    {
                        Image = ValidationHelper.GetString(x.GetValue("SKUImagePath"), string.Empty),
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
