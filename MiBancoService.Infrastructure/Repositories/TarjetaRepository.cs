using Dapper;
using MiBancoService.Application.DTOs.Responses;
using MiBancoService.Domain.Utility;
using MiBancoService.Infrastructure.Connections;
using MiBancoService.Infrastructure.Contracts.Repositories;
using MiBancoService.Infrastructure.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiBancoService.Infrastructure.Repositories
{
   public class TarjetaRepository : ITarjetaRepository
    {
        BancoBDConnection ConnectionBD = new BancoBDConnection();

       
        public async Task<OperationResult<TarjetaDTO>> ObtenerTarjetaByCliente(int Codigo)
        {
            var Result = new OperationResult<TarjetaDTO>() { Success = true, Messages = new List<string> { "Operacion realiazada con exito" } };

            try
            {      
                var SqlResult = await ConnectionBD.Connection.QueryAsync<TarjetaDTO>(TarjetaQueries.GetTarjetaByClienteQuery, new { ClienteId = Codigo });
                              

                if (SqlResult != null && SqlResult.Any())
                      Result.ResultList = SqlResult.ToList();

                ConnectionBD.CloseConnection();
            }
            catch (Exception Ex)
            {
                Result = new OperationResult<TarjetaDTO>() { Success = false, Messages = new List<string> { "Error realizando la consulta de tarjetas de credito." } };
            }

            return Result;

        }

        public async Task<OperationResult<TipoTarjetaDTO>> ObtenerTiposTarjeta()
        {
            var Result = new OperationResult<TipoTarjetaDTO>() { Success = true, Messages = new List<string> { "Operacion realiazada con exito" } };

            try
            {
                var SqlResult = await ConnectionBD.Connection.QueryAsync<TipoTarjetaDTO>(TarjetaQueries.GetTipoTarjetaQuery, new { ClienteId = 1 });

                if (SqlResult != null && SqlResult.Any())
                    Result.ResultList = SqlResult.ToList();
            }
            catch (Exception ex)
            {
                Result = new OperationResult<TipoTarjetaDTO>() { Success = false, Messages = new List<string> { "Error realizando la consulta de los tipos de credito." } };
            }

            return Result;
        }


        public async Task<OperationResult<TarjetaDTO>> GuardarTarjeta(TarjetaDTO dtoTarjeta)
        {
            var Result = new OperationResult<TarjetaDTO>() { Success = true, Messages = new List<string> { "Operacion realiazada con exito" } };

            try
            {
                var parameters = new Dapper.DynamicParameters();

                parameters.Add("TarjetaId", dtoTarjeta.CodigoTarjeta);
                parameters.Add("TipoTarjetaId", dtoTarjeta.TipoTarjetaId);
                parameters.Add("ClienteId", dtoTarjeta.CodigoCliente);
                parameters.Add("Banco", dtoTarjeta.Banco);
                parameters.Add("Numero", dtoTarjeta.Numero);
                parameters.Add("MesVence", dtoTarjeta.MesVence);
                parameters.Add("AnioVence", dtoTarjeta.AnioVence);

                var SqlResult = await ConnectionBD.Connection.ExecuteAsync("SPC_GUARDAR_TARJETA",
                    parameters, commandType: System.Data.CommandType.StoredProcedure);

                ConnectionBD.CloseConnection();

            }
            catch (Exception Ex)
            {
                Result = new OperationResult<TarjetaDTO>() { Success = false, Messages = new List<string> { "Error realizando la operacion." } };

            }

            return Result;

            throw new NotImplementedException();
        }


        public async Task<OperationResult<TarjetaDTO>> OtenerTarjetaByCodigo(int Codigo)
        {
            var Result = new OperationResult<TarjetaDTO>() { Success = true, Messages = new List<string> { "Operacion realiazada con exito" } };

            try
            {
                var SqlResult = await ConnectionBD.Connection.QueryFirstAsync<TarjetaDTO>(TarjetaQueries.GetTarjetaByIdQuery, new { TarjetaId = Codigo });

                if (SqlResult != null )
                    Result.ResultObject = SqlResult;

                ConnectionBD.CloseConnection();
            }
            catch (Exception ex)
            {
                Result = new OperationResult<TarjetaDTO>() { Success = false, Messages = new List<string> { "Error realizando la consulta de tarjeta por Id" } };
            }

            return Result;
        }

        public OperationResult<TarjetaDTO> OtenerTarjetaByNumero(string Numero)
        {    
                var Result = new OperationResult<TarjetaDTO>() { Success = true, Messages = new List<string> { "Operacion realiazada con exito" } };

                try
                {
                    var SqlResult =  ConnectionBD.Connection.Query<TarjetaDTO>(TarjetaQueries.GetTarjetaByNumeroTarjetaQuery, new { NumeroTarjeta = Numero });

                    if (SqlResult != null && SqlResult.Any())
                         Result.ResultObject = SqlResult.FirstOrDefault();

                    ConnectionBD.CloseConnection();
                }
                catch (Exception Ex)
                {
                    Result = new OperationResult<TarjetaDTO>() { Success = false, Messages = new List<string> { "Error realizando la consulta de tarjetas por numero." } };
                }

                return Result;
        }
    }
}
