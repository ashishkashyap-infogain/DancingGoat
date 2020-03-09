using CMS.Helpers;
using CMS.Membership;
using CMS.Search;
using DancingGoat.Areas.Api.Dto;
using DancingGoat.Areas.Api.Models;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Http;

namespace DancingGoat.Areas.Api.Controllers
{
    public class CoffeeAndBrewerSearchController : ApiController
    {
        private const string COFFEEANDBREWER_INDEX_NAME = "DancingGoat.COFFEEANDBREWER";
        private const int PAGE_SIZE = 5;
        private const int DEFAULT_PAGE_NUMBER = 1;
        private const string cultureCode = "en-us";


        [Route("api/CoffeeAndBrewerSearch")]
        public Response<SearchResultDto> GetCoffeeAndBrewerSearchResult(string searchText)
        {
            if (string.IsNullOrEmpty(searchText))
            {
                return null;
            }
            else
            {
                UserInfo searchUser = MembershipContext.AuthenticatedUser;
                /* Indicates whether the search service uses site default language version of pages as a replacement
                for pages that are not translated into the language specified by 'cultureCode' */
                bool combineWithDefaultCulture = true;

                // Prepares a 'SearchParameters' object to search through indexes of the 'Pages' type
                SearchParameters searchParametersAdvanced = SearchParameters.PrepareForPages(CMS.Helpers.ValidationHelper.GetString(searchText, string.Empty), new[] { COFFEEANDBREWER_INDEX_NAME }, DEFAULT_PAGE_NUMBER, PAGE_SIZE, searchUser, cultureCode, combineWithDefaultCulture);
                // Searches the specified indexes
                //DancingGoatMvc.Brewer
                SearchResult searchResults = SearchHelper.Search(searchParametersAdvanced);
                List<SearchResultDto> data = searchResults.Items
                .AsEnumerable()
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
                    Message = "Search result from Coffee and Brewer.",
                    Data = data
                };

            }
        }
    }
}
