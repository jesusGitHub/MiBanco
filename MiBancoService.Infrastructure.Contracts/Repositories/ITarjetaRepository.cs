using MiBancoService.Application.DTOs.Responses;
using MiBancoService.Domain.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiBancoService.Infrastructure.Contracts.Repositories
{
   public interface ITarjetaRepository
    {
        Task<OperationResult<TarjetaDTO>> ObtenerTarjetaByCliente(int Codigo);

        Task<OperationResult<TipoTarjetaDTO>> ObtenerTiposTarjeta();

        Task<OperationResult<TarjetaDTO>> GuardarTarjeta(TarjetaDTO dtoTarjeta);

        Task<OperationResult<TarjetaDTO>> OtenerTarjetaByCodigo(int Codigo);

        OperationResult<TarjetaDTO> OtenerTarjetaByNumero(string Numero);

    }
}
