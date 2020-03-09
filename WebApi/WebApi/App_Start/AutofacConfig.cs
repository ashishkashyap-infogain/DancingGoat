using Autofac;
using Autofac.Integration.Mvc;
using Autofac.Integration.WebApi;
using Business.DependencyInjection;
using Business.Identity;
using Business.Identity.Models;
using Business.Repository;
using Business.Services;
using Business.Services.Context;
using Microsoft.Owin.Security;
using System;
using System.Globalization;
using System.Net.Http;
using System.Reflection;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using WebApi.Config;
using WebApi.Utils;

namespace WebApi.App_Start
{
    public class AutofacConfig
    {
        public static void DependencyBuilder()
        {
            // Create the builder with which components/services are registered.
            ContainerBuilder builder = new ContainerBuilder();

            // Register your Web API controllers.
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());

            builder.RegisterAssemblyTypes(AppDomain.CurrentDomain.GetAssemblies())
                                      .Where(t => t.GetCustomAttribute<InjectableAttribute>() != null)
                                      .AsImplementedInterfaces()
                                      .InstancePerRequest();

            builder.RegisterWebApiFilterProvider(GlobalConfiguration.Configuration);

            //Build the Container
            IContainer container = builder.Build();

            //Create the Dependency Resolver
            AutofacWebApiDependencyResolver resolver = new AutofacWebApiDependencyResolver(container);

            //Configuring WebApi with Dependency Resolver
            GlobalConfiguration.Configuration.DependencyResolver = resolver;

        }
        public static void ConfigureContainer()
        {

            // Initializes the Autofac builder instance
            ContainerBuilder builder = new ContainerBuilder();

            // Register dependencies in controllers
            builder.RegisterControllers(typeof(WebApiApplication).Assembly);

            // Register dependencies in Web API 2 controllers
            builder.RegisterApiControllers(typeof(WebApiApplication).Assembly);

            // Adds a custom registration source (IRegistrationSource) that provides all services from the Kentico API
            builder.RegisterSource(new CmsRegistrationSource());

            // Registers all services that implement IService interface
            builder.RegisterAssemblyTypes(typeof(IService).Assembly)
                .Where(x => x.IsClass && !x.IsAbstract && typeof(IService).IsAssignableFrom(x))
                .AsImplementedInterfaces()
                .InstancePerRequest();

            // Registers site context
            builder.RegisterType<SiteContextService>().As<ISiteContextService>()
                .WithParameter((parameter, context) => parameter.Name == "currentCulture",
                    (parameter, context) => CultureInfo.CurrentUICulture.Name)
                .WithParameter((parameter, context) => parameter.Name == "sitename",
                    (parameter, context) => AppConfig.SiteName)
                .InstancePerRequest();

            // Registers business dependencies
            builder.RegisterType<BusinessDependencies>().As<IBusinessDependencies>()
                .InstancePerRequest();

            // Registers all repositories that implement IRepository interface
            builder.RegisterAssemblyTypes(typeof(IRepository).Assembly)
                .Where(x => x.IsClass && !x.IsAbstract && typeof(IRepository).IsAssignableFrom(x))
                .AsImplementedInterfaces()
                .InstancePerRequest();

            // Registers the common file management helper
            builder.RegisterType<FileManager>().As<IFileManager>()
                .InstancePerRequest();

            // Registers the common error handler
            builder.RegisterType<ErrorHelper>().As<IErrorHelper>()
                .InstancePerRequest();

            builder.RegisterType<SampleRespository>().As<ISampleRespository>()
                .InstancePerRequest();
            //builder.RegisterType<EmployeeManager>().As<IEmployeeManager>()
            //    .InstancePerRequest();


            // Hotfix-independent variant (begin)
            /*
            // Registers the class that wraps the Kentico.Membership.UserStore class.
            builder.Register(context => new KenticoUserStore(context.Resolve<ISiteContextService>().SiteName))
                .As<IKenticoUserStore>()
                .InstancePerRequest();
            */
            // Hotfix-independent variant (end)

            // Registers the application-level user store.
            builder.RegisterType<DubaiCultureUserStore>()
                .As<IDubaiCultureUserStore>()
                .WithParameter((parameter, context) => parameter.Name == "siteName",
                    (parameter, context) => AppConfig.SiteName)
                .InstancePerRequest();

            // Registers the application-level user manager.
            builder.RegisterType<DubaiCultureUserManager>()
                .As<IDubaiCultureUserManager<DubaiCultureUser, int>>()
                .InstancePerRequest();

            // Registers the authentication manager of the OWIN context for DI retrieval.
            builder.Register(context =>
                HttpContext.Current.GetOwinContext().Authentication)
                .As<IAuthenticationManager>();

            // Registers the application-level sign in manager.
            builder.RegisterType<DubaiCultureSignInManager>()
                .As<IDubaiCultureSignInManager<DubaiCultureUser, int>>()
                .InstancePerRequest();

            // Registers the account manager.
            builder.RegisterType<AccountManager>()
                .As<IAccountManager>()
                .InstancePerRequest();


            // Registers a view registration source so that views can take advantage of DI.
            // See https://autofaccn.readthedocs.io/en/latest/integration/mvc.html#enable-property-injection-for-view-pages
            builder.RegisterSource(new ViewRegistrationSource());

            IContainer container = builder.Build();

            // Sets the dependency resolver for Web API 2
            GlobalConfiguration.Configuration.DependencyResolver = new AutofacWebApiDependencyResolver(container);

            // Resolves the dependencies
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));

        }
    }
}