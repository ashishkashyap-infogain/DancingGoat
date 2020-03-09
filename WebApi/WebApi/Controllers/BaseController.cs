using Business.DependencyInjection;
using System.Web.Http;

namespace WebApi.Controllers
{
    public class BaseController : ApiController
    {
        protected IBusinessDependencies Dependencies { get; }
        protected BaseController(IBusinessDependencies dependencies)
        {
            Dependencies = dependencies;
        }
    }
}
