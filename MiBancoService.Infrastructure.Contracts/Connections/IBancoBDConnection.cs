using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiBancoService.Infrastructure.Contracts.Connections
{
    public interface IBancoBDConnection
    {
        void OpenConnection();

        void CloseConnection();
    }
}
