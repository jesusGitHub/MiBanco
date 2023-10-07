[assembly: WebActivator.PostApplicationStartMethod(typeof(MiBanco.App_Start.SimpleInjectorInitializer), "Initialize")]

namespace MiBanco.App_Start
{
    using System.Reflection;
    using System.Web.Mvc;
    using MiBancoService.Application.Contracts.Services;
    using MiBancoService.Application.Services;
    using MiBancoService.Infrastructure.Contracts.Repositories;
    using MiBancoService.Infrastructure.Repositories;
    using SimpleInjector;
    using SimpleInjector.Integration.Web;
    using SimpleInjector.Integration.Web.Mvc;
    
    public static class SimpleInjectorInitializer
    {
        /// <summary>Initialize the container and register it as MVC3 Dependency Resolver.</summary>
        public static void Initialize()
        {
            var container = new Container();
            container.Options.DefaultScopedLifestyle = new WebRequestLifestyle();
            
            InitializeContainer(container);

            container.RegisterMvcControllers(Assembly.GetExecutingAssembly());
            
            container.Verify();
            
            DependencyResolver.SetResolver(new SimpleInjectorDependencyResolver(container));
        }
     
        private static void InitializeContainer(Container container)
        {
            // For Services
             container.Register<IClienteService, ClienteService>(Lifestyle.Scoped);


            //Repository
            container.Register<IClienteRepository, ClienteRepository>(Lifestyle.Scoped);
        }
    }
}