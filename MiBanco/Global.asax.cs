using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using AutoMapper;
using MiBanco.App_Start;
using System.ComponentModel;
using SimpleInjector.Integration.Web.Mvc;
using SimpleInjector;
using System.Reflection;

namespace MiBanco
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            var container = new SimpleInjector.Container();

            // Other configurations

            var mapperConfig = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<AutoMapperProfiles>(); // Add your AutoMapper profile
                                               // Add other profiles if you have them
            });

            IMapper mapper = mapperConfig.CreateMapper();

            container.RegisterInstance(mapper);

           // container.Register<IMapperWrapper, AutoMapperWrapper>();

            // Register your controllers
           // container.RegisterMvcControllers(Assembly.GetExecutingAssembly());


            DependencyResolver.SetResolver(new SimpleInjectorDependencyResolver(container));

            // mapper.Initialize(cfg => cfg.AddProfile(mapperConfig));


        }
    }
}
