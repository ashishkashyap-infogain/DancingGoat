using Autofac;
using System;
using System.Linq;
using System.Reflection;
using System.Web.Http;
using System.Web.Mvc;

namespace Business.DependencyInjection
{
    public class AutofacDependecyBuilder
    {
        public static void DependencyBuilder()
        {
            // Create the builder with which components/services are registered.
            ContainerBuilder builder = new ContainerBuilder();

            // Register your Web API controllers.
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());

            builder.RegisterAssemblyTypes(AppDomain.CurrentDomain.GetAssemblies())
                                      .Where(t => t.GetCustomAttribute <InjectableAttribute > () != null)
                                      .AsImplementedInterfaces()
                                      .InstancePerRequest();

            builder.RegisterWebApiFilterProvider( GlobalConfiguration. Configuration);

            //Build the Container
            IContainer container = builder.Build();

            //Create the Dependency Resolver
            bool resolver = new AutofacWebApiDependencyResolver(container);

            //Configuring WebApi with Dependency Resolver
            GlobalConfiguration. Configuration. DependencyResolver = resolver;

        }
    }
}
