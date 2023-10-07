using MiBancoService.Application.Contracts.Services;
using MiBancoService.Application.Services;
using MiBancoService.Infrastructure.Contracts.Repositories;
using MiBancoService.Infrastructure.Repositories;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiBancoService.CrossCutting.Register
{
    public static class IOCRegister
    {
        public static void AddRegistration(this IServiceCollection services)
        {
            AddRegisterRepositories(services);
            AddRegisterServices(services);
        }

       
        /// <summary>
        /// Agregar Registro de Servicios.
        /// </summary>
        /// <param name="services">Servicio.</param>
        private static void AddRegisterServices(IServiceCollection services)
        {
            services.AddTransient<IClienteService, ClienteService>();           
        }

        /// <summary>
        /// Agregar Registro de Repositorios.
        /// </summary>
        /// <param name="services">Repositorio.</param>
        private static void AddRegisterRepositories(IServiceCollection services)
        {
            services.AddTransient<IClienteRepository, ClienteRepository>();            
        }
    }
}
