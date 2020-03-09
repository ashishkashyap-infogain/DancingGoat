using DancingGoat.Repositories;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace DancingGoat.Areas.Api.Controllers
{
    public class ProductSkusController : ApiController
    {
        // Existing Dancing Goat repositories
        private readonly ICoffeeRepository mCoffeeRepository;
        private readonly IBrewerRepository mBrewerRepository;


        // Constructor with injected dependencies
        public ProductSkusController(
            ICoffeeRepository coffeeRepository,
            IBrewerRepository brewerRepository
        )
        {
            mCoffeeRepository = coffeeRepository;
            mBrewerRepository = brewerRepository;
        }

        public IEnumerable<string> Get()
        {
            IEnumerable<string> coffeeSkus = mCoffeeRepository
                .GetCoffees(null)
                .Select(coffee => coffee.SKU.SKUNumber);

            IEnumerable<string> brewerSkus = mBrewerRepository
                .GetBrewers(null)
                .Select(brewer => brewer.SKU.SKUNumber);

            return coffeeSkus.Concat(brewerSkus);
        }
    }
}
