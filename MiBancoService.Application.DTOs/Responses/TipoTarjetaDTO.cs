﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiBancoService.Application.DTOs.Responses
{
   public class TipoTarjetaDTO
    {
        public int TipoTarjetaId { get; set; }
        public string Descripcion { get; set; }
        public string FechaCreacion { get; set; }
        public string FechaModificacion { get; set; }
    }
}
