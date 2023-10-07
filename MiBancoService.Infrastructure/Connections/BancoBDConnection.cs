using MiBancoService.Infrastructure.Contracts.Connections;
using System;
using System.Collections.Generic;
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


            //Lo recomendable seria que el connectionString se obtubiera del Environment
            //Como se ve en este comentario pero como es una prueba  para menos estres lo pondre directamente.
           
            //Connection = new SqlConnection(Environment.GetEnvironmentVariable("BancoDB"));

            Connection = new SqlConnection("Integrated Security=SSPI;Persist Security Info=False;User ID=sa;Initial Catalog=MiBanco;Data Source=AFPLPT-91");
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
