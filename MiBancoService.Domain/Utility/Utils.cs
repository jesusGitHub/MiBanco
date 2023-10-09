using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace MiBancoService.Domain.Utility
{
   public static class Utils
    {
        public static int CalculaNumeroPagina(int NumeroPagina, int CantidadRegistro)
        {
            if (NumeroPagina <= 0)
                return 1;

            return ((NumeroPagina / CantidadRegistro) + 1);
        }

        public static List<string> GetModelStateMessage(ModelStateDictionary modelState)
        {
            var lstError = new List<string>();

            foreach (var campo in modelState.Values)
            {
                foreach (var error in campo.Errors)
                {
                    lstError.Add(error.ErrorMessage);
                    if (error.Exception != null)
                        lstError.Add(error.Exception.InnerException.ToString() + error.Exception.Message);
                }
            }
            return lstError;
        }
    }
}
