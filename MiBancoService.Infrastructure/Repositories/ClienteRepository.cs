using MiBancoService.Application.DTOs.Responses;
using MiBancoService.Infrastructure.Contracts.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiBancoService.Infrastructure.Repositories
{
   public class ClienteRepository : IClienteRepository
    {
        public Task<IEnumerable<ClienteDTO>> ObtenerCliente()
        {


            throw new NotImplementedException();
        }
    }
}
