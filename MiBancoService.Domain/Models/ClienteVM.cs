using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiBancoService.Domain.Models
{
   public class ClienteVM
    {
        public int Codigo { get; set; }
        [Required(ErrorMessage = "El campo {0} es requerido")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido")]
        public string Apellido { get; set; }

        [DisplayName("Número Contacto")]
        [Required(ErrorMessage = "El campo {0} es requerido")]
        [DataType(DataType.PhoneNumber)]
        [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$", ErrorMessage = "Número de contacto incorrecto")]
        public string NumeroContacto { get; set; }
        public string Ocupacion { get; set; }

        public string start { get; set; }
        public int length { get; set; }
        public string draw { get; set; }
        public string search { get; set; }

    }
}
