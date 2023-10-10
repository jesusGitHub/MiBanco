using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace MiBancoService.Domain.Models
{
   public class TarjetaVM
    {
        public int CodigoTarjeta { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido")]
        public int TipoTarjetaId { get; set; }
        public int CodigoCliente { get; set; }


        public string Tipo { get; set; }


        [Required(ErrorMessage = "El campo {0} es requerido")]
        public string Banco { get; set; }

        [Display(Name = "Número Tarjeta")]
        [Required(ErrorMessage = "El campo {0} es requerido")]        
        [MaxLength(15,ErrorMessage = "El campo {0} no debe contener mas de 15 caracteres")]
        [MinLength(5, ErrorMessage = "El campo {0} debe contener al menos de 5 caracteres")]
        public string Numero { get; set; }

        [Display(Name = "Mes Vence")]
        [Required(ErrorMessage = "El campo {0} es requerido")]
        [Range(1, 12, ErrorMessage = "El campo {0} debe tener un valor comprendido entre 1 y 12")]
        public int MesVence { get; set; }

        [Display(Name = "Año vence")]
        [Required(ErrorMessage = "El campo {0} es requerido")]
        [Range(2024, 2030, ErrorMessage = "El campo {0} debe tener un valor comprendido entre 2024 y 2030")]
        public int AnioVence { get; set; } 
        
        public SelectList DDlTipoTarjeta { get; set; }
    }
}
