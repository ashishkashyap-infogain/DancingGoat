//using Business.Services.Cache;
using Business.Services.Context;
using Business.Services.Culture;
using Business.Services.Errors;
using Business.Services.Localization;

namespace Business.DependencyInjection
{
    public class BusinessDependencies : IBusinessDependencies
    {
        public ICultureService CultureService { get; }
        public ISiteContextService SiteContextService { get; }
        //public ICacheService CacheService { get; }
        public IErrorHelperService ErrorHelperService { get; set; }
        public ILocalizationService LocalizationService { get; set; }

        public BusinessDependencies(
            ICultureService cultureService,
            ISiteContextService siteContextService,
            //ICacheService cacheDependencyService,
            IErrorHelperService errorHelperService,
            ILocalizationService localizationService
            )
        {
            CultureService = cultureService;
            SiteContextService = siteContextService;
            //CacheService = cacheDependencyService;
            ErrorHelperService = errorHelperService;
            LocalizationService = localizationService;
        }
    }
}
