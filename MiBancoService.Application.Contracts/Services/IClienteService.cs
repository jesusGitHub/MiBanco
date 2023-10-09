using MiBancoService.Application.DTOs.Responses;
using MiBancoService.Domain.Utility;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MiBancoService.Application.Contracts.Services
{
    public interface IClienteService
    {
        Task<OperationResult<ClienteDTO>> GuardarCliente(ClienteDTO dtoCliente);

        Task<OperationResult<ClienteDTO>> ObtenerCliente(ClienteDTO dtoCliente);

        Task<OperationResult<ClienteDTO>> ObtenerClienteByCodigo(int Codigo);
    }
}
