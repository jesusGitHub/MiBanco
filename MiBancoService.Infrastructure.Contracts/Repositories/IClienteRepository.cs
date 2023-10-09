using MiBancoService.Application.DTOs.Responses;
using MiBancoService.Domain.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiBancoService.Infrastructure.Contracts.Repositories
{
   public interface IClienteRepository
    {
        Task<OperationResult<ClienteDTO>> ObtenerCliente(ClienteDTO dtoCliente);

        Task<OperationResult<ClienteDTO>> GuardarCliente(ClienteDTO dtoCliente);

        Task<OperationResult<ClienteDTO>> ObtenerClienteByCodigo(int codigo);
    }
}
