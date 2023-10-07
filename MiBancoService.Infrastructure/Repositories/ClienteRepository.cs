using Dapper;
using MiBancoService.Application.DTOs.Responses;
using MiBancoService.Infrastructure.Connections;
using MiBancoService.Infrastructure.Contracts.Connections;
using MiBancoService.Infrastructure.Contracts.Repositories;
using System;
using System.Collections.Generic;
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
            return await ConnectionBD.Connection.QueryAsync<ClienteDTO>($@"SELECT * FROM Cliente");
                    
            throw new NotImplementedException();
        }
    }
}
