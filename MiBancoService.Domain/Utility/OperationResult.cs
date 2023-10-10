using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MiBancoService.Domain.Utility
{
   public class OperationResult<T>
    {
        public OperationResult()
        {

            Messages = new List<string>();
        }

        public bool Success { get; set; }

        public T ResultObject { get; set; }

        public bool Warning { get; set; }

        public List<T> ResultList { get; set; }

        public int TotalRecords { get; set; }

        public List<string> Messages { get; set; }

        public string Message { get; set; }
    }
}
