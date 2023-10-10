using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiBancoService.Infrastructure.Queries
{
   public static class TarjetaQueries
    {
        public const string GetTarjetaByClienteQuery = @"  SELECT
                                                           T.[TarjetaId] AS CodigoTarjeta
                                                          ,TP.[Tipo]
                                                          ,T.[ClienteId]
                                                          ,T.[Banco]
                                                          ,T.[NumeroTarjeta] AS Numero
                                                          ,T.[MesVence]
                                                          ,T.[AnioVence]
                                                          ,T.[FechaRegistro]      
                                                      FROM [dbo].[Tarjeta] T
                                                        INNER JOIN [dbo].[TipoTarjeta] AS TP ON T.TipoTarjetaId = TP.TipoTarjetaId
	                                                    AND ClienteId = @ClienteId";

        public const string GetTarjetaByIdQuery = @"  SELECT
                                                           T.[TarjetaId] AS CodigoTarjeta
                                                          ,T.TipoTarjetaId
                                                          ,TP.[Tipo]
                                                          ,T.[ClienteId]
                                                          ,T.[Banco]
                                                          ,T.[NumeroTarjeta] AS Numero
                                                          ,T.[MesVence]
                                                          ,T.[AnioVence]
                                                          ,T.[FechaRegistro]      
                                                      FROM [dbo].[Tarjeta] T
                                                        INNER JOIN [dbo].[TipoTarjeta] AS TP ON T.TipoTarjetaId = TP.TipoTarjetaId
	                                                    AND T.TarjetaId = @TarjetaId";

        public const string GetTipoTarjetaQuery = @" SELECT TipoTarjetaId, Tipo AS Descripcion FROM [dbo].[TipoTarjeta]";


        public const string GetTarjetaByNumeroTarjetaQuery = @"  SELECT
                                                           T.[TarjetaId] AS CodigoTarjeta
                                                          ,T.TipoTarjetaId
                                                          ,TP.[Tipo]
                                                          ,T.[ClienteId]
                                                          ,T.[Banco]
                                                          ,T.[NumeroTarjeta] AS Numero
                                                          ,T.[MesVence]
                                                          ,T.[AnioVence]
                                                          ,T.[FechaRegistro]      
                                                      FROM [dbo].[Tarjeta] T
                                                        INNER JOIN [dbo].[TipoTarjeta] AS TP ON T.TipoTarjetaId = TP.TipoTarjetaId
	                                                    AND T.NumeroTarjeta = @NumeroTarjeta";




    }
}
