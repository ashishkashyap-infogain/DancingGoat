using Business.Dto.Search;
using CMS.DocumentEngine.Types.DancingGoatMvc;
using CMS.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Http;
using WebApi.Models;

namespace WebApi.Controllers
{
    public class CoffeeAndBrewerController : ApiController
    {
        public Response<SearchResultDto> Get()
        {

            List<SearchResultDto> data = GetCoffeeQuery().ToList();
            data.AddRange(GetBrewerQuery().ToList());

            return new Response<SearchResultDto>
            {
                StatusCode = HttpStatusCode.OK,
                Success = true,
                Message = "Coffee and Brewer list.",
                Data = data
            };
        }
        private List<SearchResultDto> GetCoffeeQuery()
        {
            return CoffeeProvider.GetCoffees()
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
        }

        private List<SearchResultDto> GetBrewerQuery()
        {
            return BrewerProvider.GetBrewers()
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
        }
    }
}
