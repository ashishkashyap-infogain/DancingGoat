using CMS.Helpers;
using CMS.Membership;
using CMS.Search;
using DancingGoat.Areas.Api.Dto;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace DancingGoat.Areas.Api.Controllers
{
    public class SmartSearchController : ApiController
    {
        private const string CAFE_INDEX_NAME = "Cafe";
        private const int PAGE_SIZE = 5;
        private const int DEFAULT_PAGE_NUMBER = 1;
        private const string cultureCode = "en-us";

        public List<CafeDto> GetSearchResult(string searchText)
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

                // 'FullSearch' ensures no special characters in the query are escaped
                // This makes, for example, exact field searches such as the one in 'searchText' possible
                //SearchOptionsEnum searchOptions = SearchOptionsEnum.FullSearch;

                // Prepares a 'SearchParameters' object to search through indexes of the 'Pages' type
                SearchParameters searchParametersAdvanced = SearchParameters.PrepareForPages(CMS.Helpers.ValidationHelper.GetString(searchText, string.Empty), new[] { CAFE_INDEX_NAME }, DEFAULT_PAGE_NUMBER, PAGE_SIZE, searchUser, cultureCode, combineWithDefaultCulture);
                // Searches the specified indexes
                SearchResult searchResultAdvanced = SearchHelper.Search(searchParametersAdvanced);

                return searchResultAdvanced.Items
                    .AsEnumerable()
                    .Select(x =>
                    {
                        return new CafeDto()
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
                //var searchResultItemModels = searchResultAdvanced.Items
                //    .Select(searchResultItem => mSearchItemViewModelFactory.GetTypedSearchResultItemModel(searchResultItem));
                //return searchResultItemModels;
            }
        }

    }

}
