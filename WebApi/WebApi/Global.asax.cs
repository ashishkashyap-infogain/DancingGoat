using System.Web;
using System.Web.Http;
using WebApi.App_Start;

namespace WebApi
{
    public class WebApiApplication : HttpApplication
    {
        protected void Application_Start()
        {
            // Configures Web API 2
            GlobalConfiguration.Configure(WebApiConfig.Register);

            // Dependency injection
            AutofacConfig.ConfigureContainer();
                
        }
    }
}
