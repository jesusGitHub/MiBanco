using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiBancoService.Domain.Models
{
    class TipoTarjeta
    {
        public int CodigoTipo { get; set; }
        public string Descripcion { get; set; }
        public string FechaCreacion { get; set; }
        public string FechaModificacion { get; set; }
    }
}
