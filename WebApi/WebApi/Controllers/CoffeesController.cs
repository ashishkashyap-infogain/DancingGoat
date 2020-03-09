using Business.DependencyInjection;
using Business.Repository.Coffee;
using System.Web.Http;

namespace WebApi.Controllers
{
    //[RoutePrefix("Test")]
    [RoutePrefix("Coffees")]
    public class CoffeesController : ApiController
    {

        private ICoffeeRepository CoffeeRepository { get; }
        private IBusinessDependencies Dependencies { get; }

        //public CoffeesController(
        //    IBusinessDependencies dependencies,
        //    ICoffeeRepository coffeeRepository
        //    ) : base(dependencies)
        //{
        //    CoffeeRepository = coffeeRepository;
        //}
        public CoffeesController(
            ICoffeeRepository coffeeRepository
            )
        {
            CoffeeRepository = coffeeRepository;
        }
        private ICoffeeRepository coffeeRepository = new CoffeeRepository();
        //public CoffeesController(IBusinessDependencies dependencies) : base(dependencies)
        //{
        //    CoffeeRepository = coffeeRepository;
        //}
        public CoffeesController( )
        {
            CoffeeRepository = coffeeRepository;
        }
        [Route("Get")]
        public string Get()
        {
            System.Collections.Generic.IEnumerable<Business.Dto.Coffee.CoffeeDto> data = CoffeeRepository.GetCoffees();
            return "Data";
        }


    }
}
