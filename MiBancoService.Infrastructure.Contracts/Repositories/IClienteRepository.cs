using MiBancoService.Application.DTOs.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiBancoService.Infrastructure.Contracts.Repositories
{
   public interface IClienteRepository
    {
        Task<IEnumerable<ClienteDTO>> ObtenerCliente();
    }
}
