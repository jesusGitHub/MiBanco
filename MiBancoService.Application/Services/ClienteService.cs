using MiBancoService.Application.Contracts.Services;
using MiBancoService.Application.DTOs.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiBancoService.Application.Services
{
    public class ClienteService : IClienteService
    {
        public Task<IEnumerable<ClienteDTO>> ObtenerCliente()
        {

            throw new NotImplementedException();
        }
    }
}
