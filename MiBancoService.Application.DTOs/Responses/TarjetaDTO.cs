using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiBancoService.Application.DTOs.Responses
{
    public class TarjetaDTO
    {
        public int CodigoCliente { get; set; }
        public int CodigoTarjeta { get; set; }
        public int TipoTarjetaId { get; set; }
        public string Tipo { get; set; }
        public string Banco { get; set; }
        public string Numero { get; set; }
        public int MesVence { get; set; }
        public int AnioVence { get; set; }
        public bool Estado { get; set; } = true;
        
    }
}
