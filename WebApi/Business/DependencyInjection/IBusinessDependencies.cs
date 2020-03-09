//using Business.Services.Cache;
using Business.Services.Context;
using Business.Services.Culture;
using Business.Services.Errors;
using Business.Services.Localization;

namespace Business.DependencyInjection
{
    public interface IBusinessDependencies
    {
        ICultureService CultureService { get; }
        ISiteContextService SiteContextService { get; }
        //ICacheService CacheService { get; }
        IErrorHelperService ErrorHelperService { get; set; }
        ILocalizationService LocalizationService { get; set; }
    }
}
