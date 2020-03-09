using System.Web.Http;
using System.Web.Mvc;

namespace DancingGoat.Areas.Api
{
    public class ApiAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "Api";
            }
        }

        //public override void RegisterArea(AreaRegistrationContext context) 
        //{
        //    context.MapRoute(
        //        "Api_default",
        //        "Api/{controller}/{action}/{id}",
        //        new { action = "Index", id = UrlParameter.Optional }
        //    );
        //}

        public override void RegisterArea(AreaRegistrationContext context)
        {
            //attribute routing
            context.Routes.MapMvcAttributeRoutes();

            //Api routing
            context.Routes.MapHttpRoute(
                "Api_DefaultWebApiRoute",
                "Api/{controller}/{id}",
                new { id = RouteParameter.Optional }
            );
        }
    }
}