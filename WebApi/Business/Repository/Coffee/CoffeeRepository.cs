using Business.Dto.Coffee;
using Business.Services.Context;
using Business.Services.Query;
using CMS.Ecommerce;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Business.Repository.Coffee
{
    public class CoffeeRepository : ICoffeeRepository
    {
        //public CoffeeRepository()
        //{

        //}
        private readonly string[] _coffeeColumns =
        {
            // Defines database columns for retrieving data
            // NodeGuid is retrieved automatically
            "NodeAlias", "CoffeeFarm", "CoffeeCountry", "CoffeeVariety", "CoffeeProcessing",
            "CoffeeAltitude", "CoffeeIsDecaf",
        };

        public CoffeeDto GetCoffee(Guid nodeGuid)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<CoffeeDto> GetCoffees()
        {
            throw new NotImplementedException();
        }
        

        //private Func<CMS.DocumentEngine.Types.DancingGoatMvc.Coffee, CoffeeDto> CoffeeDtoSelect => coffee => new CoffeeDto()
        //{
        //    CoffeeFarm = coffee.CoffeeFarm,
        //    CoffeeCountry = coffee.CoffeeCountry,
        //    CoffeeVariety = coffee.CoffeeVariety,
        //    CoffeeProcessing = coffee.CoffeeProcessing,
        //    CoffeeAltitude = coffee.CoffeeAltitude,
        //    CoffeeIsDecaf = coffee.CoffeeIsDecaf,
        //};

        //private ISiteContextService SiteContextService { get; }

        //public CoffeeRepository(IDocumentQueryService documentQueryService, ISiteContextService siteContextService) : base(documentQueryService)
        //{
        //    SiteContextService = siteContextService;
        //}

        //public IEnumerable<CoffeeDto> GetCoffees()
        //{
        //    DocumentQueryService ser = new DocumentQueryService();
        //        return DocumentQueryService.GetDocuments<CMS.DocumentEngine.Types.DancingGoatMvc.Coffee>()
        //        .AddColumns(_coffeeColumns)
        //        .Select(CoffeeDtoSelect);
        //}

        //public CoffeeDto GetCoffee(Guid nodeGuid)
        //{
        //    return DocumentQueryService.GetDocument<CMS.DocumentEngine.Types.DancingGoatMvc.Coffee>(nodeGuid)
        //        .AddColumns(_coffeeColumns)
        //        .Select(CoffeeDtoSelect)
        //        .FirstOrDefault();
        //}       
    }

    //public class CoffeeRepository : BaseRepository, ICoffeeRepository
    //{
    //    private readonly string[] _coffeeColumns =
    //    {
    //        // Defines database columns for retrieving data
    //        // NodeGuid is retrieved automatically
    //        "NodeAlias", "CoffeeFarm", "CoffeeCountry", "CoffeeVariety", "CoffeeProcessing",
    //        "CoffeeAltitude", "CoffeeIsDecaf",
    //    };

    //    private Func<CMS.DocumentEngine.Types.DancingGoatMvc.Coffee, CoffeeDto> CoffeeDtoSelect => coffee => new CoffeeDto()
    //    {
    //        CoffeeFarm = coffee.CoffeeFarm,
    //        CoffeeCountry = coffee.CoffeeCountry,
    //        CoffeeVariety = coffee.CoffeeVariety,
    //        CoffeeProcessing = coffee.CoffeeProcessing,
    //        CoffeeAltitude = coffee.CoffeeAltitude,
    //        CoffeeIsDecaf = coffee.CoffeeIsDecaf,
    //    };

    //    private ISiteContextService SiteContextService { get; }

    //    public CoffeeRepository(IDocumentQueryService documentQueryService, ISiteContextService siteContextService) : base(documentQueryService)
    //    {
    //        SiteContextService = siteContextService;
    //    }

    //    public IEnumerable<CoffeeDto> GetCoffees()
    //    {
    //        return DocumentQueryService.GetDocuments<CMS.DocumentEngine.Types.DancingGoatMvc.Coffee>()
    //            .AddColumns(_coffeeColumns)
    //            .Select(CoffeeDtoSelect);
    //    }

    //    public CoffeeDto GetCoffee(Guid nodeGuid)
    //    {
    //        return DocumentQueryService.GetDocument<CMS.DocumentEngine.Types.DancingGoatMvc.Coffee>(nodeGuid)
    //            .AddColumns(_coffeeColumns)
    //            .Select(CoffeeDtoSelect)
    //            .FirstOrDefault();
    //    }
    //}

}
