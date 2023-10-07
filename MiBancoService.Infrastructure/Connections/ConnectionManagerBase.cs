using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiBancoService.Infrastructure.Connections
{
    public abstract class ConnectionManagerBase
    {
        public DbConnection Connection { get; set; }

        public ConnectionManagerBase()
        {
        }

        public void SetConnection(DbConnection dbConnection)
        {
            Connection = dbConnection;
        }

        public void OpenConnection()
        {
            if (Connection.State == ConnectionState.Closed)
            {
                Connection.Open();
            }
        }

        public void CloseConnection()
        {
            if (Connection.State == ConnectionState.Open || Connection.State == ConnectionState.Broken)
            {
                Connection.Close();
            }
        }
    }
}
