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
    public class TarjetaService : ITarjetaService
    {
        private readonly ITarjetaRepository _tarjetaRepository;

        public TarjetaService(ITarjetaRepository tarjetaRepository)
        {
            _tarjetaRepository = tarjetaRepository;
        }
        
        public async Task<OperationResult<TarjetaDTO>> ObtenerTarjetaByCliente(int Codigo)
        {
          return await  _tarjetaRepository.ObtenerTarjetaByCliente(Codigo);
        }
      
        public async Task<OperationResult<TipoTarjetaDTO>> ObtenerTiposTarjeta()
        {
            return await _tarjetaRepository.ObtenerTiposTarjeta();
        }

        public async Task<OperationResult<TarjetaDTO>> GuardarTarjeta(TarjetaDTO dtoTarjeta)
        {
            return await _tarjetaRepository.GuardarTarjeta(dtoTarjeta);

            throw new NotImplementedException();
        }

        public async Task<OperationResult<TarjetaDTO>> OtenerTarjetaByCodigo(int Codigo)
        {
            return await _tarjetaRepository.OtenerTarjetaByCodigo(Codigo);
        }

        public OperationResult<TarjetaDTO> OtenerTarjetaByNumero(string Numero)
        {
            return  _tarjetaRepository.OtenerTarjetaByNumero(Numero);

        }
    }
}
