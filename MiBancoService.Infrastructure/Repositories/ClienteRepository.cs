using Dapper;
using MiBancoService.Application.DTOs.Responses;
using MiBancoService.Domain.Utility;
using MiBancoService.Infrastructure.Connections;
using MiBancoService.Infrastructure.Contracts.Connections;
using MiBancoService.Infrastructure.Contracts.Repositories;
using MiBancoService.Infrastructure.Queries;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiBancoService.Infrastructure.Repositories
{
   public class ClienteRepository : IClienteRepository
    {
       
        BancoBDConnection ConnectionBD = new BancoBDConnection();

        public async Task<OperationResult<ClienteDTO>> GuardarCliente(ClienteDTO dtoCliente)
        {
            var Result = new OperationResult<ClienteDTO>() { Success = true, Messages = new List<string> { "Operacion realiazada con exito"} };

            try
            {

                var parameters = new Dapper.DynamicParameters();

                parameters.Add("ClienteId", dtoCliente.Codigo);
                parameters.Add("Nombre", dtoCliente.Nombre);
                parameters.Add("Apellido", dtoCliente.Apellido);
                parameters.Add("NumeroContacto", dtoCliente.NumeroContacto);
                parameters.Add("Ocupacion", dtoCliente.Ocupacion);

               var SqlResult = await ConnectionBD.Connection.ExecuteAsync("SPC_GUARDAR_CLIENTE",
                   parameters, commandType: System.Data.CommandType.StoredProcedure);

                ConnectionBD.CloseConnection();

            }
            catch (Exception Ex)
            {
                Result = new OperationResult<ClienteDTO>() { Success = false, Messages = new List<string> { "Error realizando la operacion." } };

            }

            return Result;


        }

        public async Task<OperationResult<ClienteDTO>> ObtenerCliente(ClienteDTO dtoCliente)
        {           
            var Result = new OperationResult<ClienteDTO>() { Success = true, Messages = new List<string> { "Operacion realiazada con exito" } };

            try
            {
                string CampoBusqueda = dtoCliente.search;
                int LengthPagina = dtoCliente.length;
                int NumPagina = int.Parse(dtoCliente.start);

                var SqlResult = await  ConnectionBD.Connection.QueryAsync<ClienteDTO>(ClienteQueries.GetClientesPaginadoQuery, new { CampoBusqueda = CampoBusqueda, LengthPagina = LengthPagina, NumPagina = NumPagina});

                Result.ResultList = SqlResult.ToList();
                
                if(Result.ResultList != null && Result.ResultList.Any() )
                     Result.TotalRecords = SqlResult.FirstOrDefault().TotalRegistro;
            }
            catch (Exception Ex)
            {
                Result = new OperationResult<ClienteDTO>() { Success = false, Messages = new List<string> { "Error realizando la consulta paginada." } };
            }

            return Result;
        }

        public async Task<OperationResult<ClienteDTO>> ObtenerClienteByCodigo(int codigo)
        {
            var Result = new OperationResult<ClienteDTO>() { Success = true, Messages = new List<string> { "Operacion realiazada con exito" } };
            try
            {
                var SqlResult = await ConnectionBD.Connection.QueryFirstAsync<ClienteDTO>(ClienteQueries.GetClienteByCodigoQuery, new { Codigo = codigo });
                Result.ResultObject = SqlResult;

            }
            catch (Exception Ex)
            {
                Result = new OperationResult<ClienteDTO>() { Success = false, Messages = new List<string> { "Error realizando la consulta paginada." } };
            }


            return Result;
        }
    }
}
