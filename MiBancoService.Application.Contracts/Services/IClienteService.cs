using MiBancoService.Application.DTOs.Responses;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MiBancoService.Application.Contracts.Services
{
    public interface IClienteService
    {
        Task<IEnumerable<ClienteDTO>> ObtenerCliente();
    }
}
