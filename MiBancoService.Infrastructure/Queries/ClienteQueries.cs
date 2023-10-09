using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiBancoService.Infrastructure.Queries
{
   public static class ClienteQueries
    {
        public const string GetClienteByCodigoQuery = @"SELECT  
                                                           ClienteId AS Codigo
                                                          ,Nombre
                                                          ,Apellido
                                                          ,NumeroContacto
                                                          ,Ocupacion                                                    
                                                    FROM MiBanco.dbo.Cliente WHERE ClienteId = @Codigo";

        public const string GetClientesPaginadoQuery = @" SPC_PAGINACION_CLIENTE  @CampoBusqueda,  @LengthPagina, @NumPagina ";


    }
}
