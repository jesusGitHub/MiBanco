using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiBancoService.Application.DTOs.Responses
{
   public class ClienteDTO
    {

        [Column("ClienteId")]
        public int Codigo { get; set; }

        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string NumeroContacto { get; set; }
        public string Ocupacion { get; set; }
        
        public DateTime FechaCreacion { get; set; }
        public DateTime FechaModificacion { get; set; }

        //Datos de paginacion, Esta propiedades deben estar en una clase base astracta
        public int TotalRegistro { get; set; }
        public string start { get; set; }
        public int length { get; set; }
        public string search { get; set; }

    }
}
