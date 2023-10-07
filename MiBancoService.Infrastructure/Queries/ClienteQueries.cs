using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiBancoService.Infrastructure.Queries
{
   public static class ClienteQueries
    {
        public const string GetAllClienteQuery = @"SELECT  
                                                           ClienteId AS Codigo
                                                          ,Nombre
                                                          ,Apellido
                                                          ,NumeroContacto
                                                          ,Ocupacion
                                                          ,FechaRegistro
                                                          ,FechaModificacion
                                                    FROM MiBanco.dbo.Cliente";

    }
}
