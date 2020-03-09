using CMS.Helpers;
using CMS.Membership;
using CMS.Search;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Http;
using WebApi.Models;

namespace WebApi.Controllers
{
    [RoutePrefix("SmartSearch")]
    public class SmartSearchController : ApiController
    {
        private const string CAFE_INDEX_NAME = "Cafe";
        private const string COFFEEANDBREWER_INDEX_NAME = "DancingGoat.COFFEEANDBREWER";
        private const int PAGE_SIZE = 5;
        private const int DEFAULT_PAGE_NUMBER = 1;
        private const string cultureCode = "en-us";

        //[Authorize]
        [Route("Cafe")]
        public Response<CafeModel> GetCafeResult(string searchText)
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
                SearchParameters searchParametersAdvanced = SearchParameters.PrepareForPages(CMS.Helpers.ValidationHelper.GetString(searchText, string.Empty), new[] { CAFE_INDEX_NAME }, DEFAULT_PAGE_NUMBER, PAGE_SIZE, searchUser, cultureCode, combineWithDefaultCulture);
                // Searches the specified indexes
                SearchResult searchResultAdvanced = SearchHelper.Search(searchParametersAdvanced);

                var data = searchResultAdvanced.Items
                    .AsEnumerable()
                    .Select(x =>
                    {
                        return new CafeModel()
                        {
                            CafeID = ValidationHelper.GetInteger(x.GetSearchValue("CafeID"), 0),
                            CafeName = ValidationHelper.GetString(x.GetSearchValue("CafeName"), string.Empty),
                            CafeIsCompanyCafe = ValidationHelper.GetBoolean(x.GetSearchValue("CafeIsCompanyCafe"), false),
                            CafeStreet = ValidationHelper.GetString(x.GetSearchValue("CafeStreet"), string.Empty),
                            CafeCity = ValidationHelper.GetString(x.GetSearchValue("CafeCity"), string.Empty),
                            CafeCountry = ValidationHelper.GetString(x.GetSearchValue("CafeCountry"), string.Empty),
                            CafeZipCode = ValidationHelper.GetString(x.GetSearchValue("CafeZipCode"), string.Empty),
                            CafePhone = ValidationHelper.GetString(x.GetSearchValue("CafePhone"), string.Empty),
                            CafeAdditionalNotes = ValidationHelper.GetString(x.GetSearchValue("CafeAdditionalNotes"), string.Empty)
                        };
                    })
                    .ToList();
                return new Response<CafeModel>
                {
                    StatusCode = HttpStatusCode.OK,
                    Success = true,
                    Message = "Search result from Coffee and Brewer.",
                    Data = data
                };
            }
        }

        [Authorize]
        [Route("CoffeeAndBrewerSearch")]
        public Response<SearchResultItemModel> GetCoffeeAndBrewerSearchResult(string searchText)
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
                SearchResult searchResults = SearchHelper.Search(searchParametersAdvanced);
                List<SearchResultItemModel> data = searchResults.Items
                .AsEnumerable()
                .Select(x =>
                {
                    return new SearchResultItemModel()
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

                return new Response<SearchResultItemModel>
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
