using MiBancoService.Application.Contracts.Services;
using MiBancoService.Application.DTOs.Responses;
using MiBancoService.Domain.Utility;
using MiBancoService.Infrastructure.Contracts.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiBancoService.Application.Services
{
    public class ClienteService : IClienteService
    {

        private readonly IClienteRepository _clienteRepository;

        public ClienteService(IClienteRepository clienteRepository)
        {
            _clienteRepository = clienteRepository;
        }

        public async Task<OperationResult<ClienteDTO>> GuardarCliente(ClienteDTO dtoCliente)
        {
            var Result = new OperationResult<ClienteDTO>();

             Result = await _clienteRepository.GuardarCliente(dtoCliente);

            return Result;
        }

        public async Task<OperationResult<ClienteDTO>> ObtenerCliente(ClienteDTO dtoCliente)
        {
           return await _clienteRepository.ObtenerCliente(dtoCliente);

        }

        public async Task<OperationResult<ClienteDTO>> ObtenerClienteByCodigo(int Codigo)
        {
            return await _clienteRepository.ObtenerClienteByCodigo(Codigo);
        }

        public async Task<OperationResult<ClienteDTO>> ActivarUsuario(int Codigo)
        {
            return await _clienteRepository.ActivarUsuario(Codigo);
            
        }
    }
}
