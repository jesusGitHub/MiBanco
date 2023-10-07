using Dapper;
using MiBancoService.Application.DTOs.Responses;
using MiBancoService.Infrastructure.Connections;
using MiBancoService.Infrastructure.Contracts.Connections;
using MiBancoService.Infrastructure.Contracts.Repositories;
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

    
        public async Task<IEnumerable<ClienteDTO>> ObtenerCliente()
        {
            //TODO:Esto se debe hacer en una clase Generica que se le pase el Modelo.
            //Dapper.SqlMapper.SetTypeMap(
            //    typeof(ClienteDTO),
            //        new Dapper.CustomPropertyTypeMap(
            //            typeof(ClienteDTO),
            //            (type, columnName) =>
            //               type.GetProperties().FirstOrDefault(prop =>
            //                   prop.GetCustomAttributes(false)
            //                       .OfType<ColumnAttribute>()
            //                       .Any(attr => attr.Name == columnName))));

            var result = ConnectionBD.Connection.QueryAsync<ClienteDTO>($@"SELECT * FROM Cliente").Result.ToList();

            return await ConnectionBD.Connection.QueryAsync<ClienteDTO>($@"SELECT * FROM Cliente");       
            

        }
    }
}
