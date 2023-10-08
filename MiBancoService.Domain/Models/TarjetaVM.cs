using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiBancoService.Domain.Models
{
    class TarjetaVM
    {
        public int Codigo { get; set; }
        public int TipoTarjetaId { get; set; }
        public string Banco { get; set; }
        public string Numero { get; set; }
        public int AnioVence { get; set; }
    }
}
