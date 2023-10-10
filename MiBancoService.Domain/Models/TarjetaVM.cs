using System.Web.Mvc;

namespace MiBancoService.Domain.Models
{
    class TarjetaVM
    {
        public int Codigo { get; set; }
        public int TipoTarjetaId { get; set; }
        public string Banco { get; set; }
        public string Numero { get; set; }
        public int AnioVence { get; set; }
        public bool Estado { get; set; } = true;
        public SelectList TipoTarjeta { get; set; }
    }
}
