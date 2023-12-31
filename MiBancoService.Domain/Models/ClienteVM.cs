﻿using System;
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
        public ClienteVM()
        {
            TarjetaVMs = new List<TarjetaVM>();
        }

        public int Codigo { get; set; }
        public int CodigoActivacion { get; set; }
        [Required(ErrorMessage = "El campo {0} es requerido")]
        [MaxLength(50, ErrorMessage = "El campo {0} no debe contener mas de 50 caracteres")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido")]
        [MaxLength(50, ErrorMessage = "El campo {0} no debe contener mas de 50 caracteres")]
        public string Apellido { get; set; }

        [DisplayName("Número Contacto")]
        [Required(ErrorMessage = "El campo {0} es requerido")]
        [DataType(DataType.PhoneNumber)]
        [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$", ErrorMessage = "Número de contacto incorrecto")]
        public string NumeroContacto { get; set; }
        [MaxLength(75, ErrorMessage = "El campo {0} no debe contener mas de 75 caracteres")]
        public string Ocupacion { get; set; }
       
        public bool EstadoActivo { get; set; }

        public bool Estado { get; set; } = true;



        public List<TarjetaVM> TarjetaVMs { get; set; }

        public string start { get; set; }
        public int length { get; set; }
        public string draw { get; set; }
        public string search { get; set; }

    }
}
