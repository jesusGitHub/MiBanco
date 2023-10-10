using MiBancoService.Infrastructure.Contracts.Connections;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiBancoService.Infrastructure.Connections
{
   public class BancoBDConnection 
    {
        public DbConnection Connection { get; set; }

        public BancoBDConnection()
        {


             //Toma la conexion de base de datos del archivo Web.Config
            string Conexon = ConfigurationManager.AppSettings["ConectionBB"];

            Connection = new SqlConnection(Conexon);

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
