using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace Pand_Ami.Models
{
    public class AccesBDD
    {
        SqlConnection cnx;

        public AccesBDD()
        {
            this.Cnx = new SqlConnection();
        }

        public SqlConnection Cnx { get => cnx; set => cnx = value; }

        public bool OuvertureBDD()
        {

            bool etatConnexion = false;
            this.Cnx.ConnectionString = "Data Source="+ Environment.MachineName +"\\SQLEXPRESS;Initial Catalog=bddPandami;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False";

            try
            {
                this.Cnx.Open();
                etatConnexion = true;
            }
            catch (SqlException e)
            {
                Console.WriteLine("Impossibilité de se connecter à la base de donnée : " + e.Message);
            }

            return etatConnexion;
        }

        public void FermetureBDD()
        {
            this.Cnx.Close();
        }
    }
}