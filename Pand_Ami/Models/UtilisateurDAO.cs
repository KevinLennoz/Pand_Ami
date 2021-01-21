using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Pand_Ami.Models
{
    public class UtilisateurDAO
    {

        SqlConnection cnx;

        public SqlConnection Cnx
        {
            get { return this.cnx; }
        }

        public UtilisateurDAO()
        {
            this.cnx = new SqlConnection();
        }

        //avec la variable d'environnement qui renvoie le nom de l'ordi : FORM220 par exemple
        private string nomConnection()
        {
            string stringConnect = "Data Source" + Environment.MachineName + "\\SQLEXPRESS;Initial Catalog = bddPandami; Integrated Security=true";
            return stringConnect;
        }

        public bool OuvreConnection()
        {
            bool ouvert = false;
            this.cnx.ConnectionString = nomConnection();
            try
            {
                this.cnx.Open();
                ouvert = true;
            }
            catch (SqlException e)
            {
                Console.WriteLine("Erreur ouverture SQL : " + e.Message);
            }
            catch (Exception e)
            {
                Console.WriteLine("Autre type d'erreur à l'ouverture : " + e.Message);
            }
            return ouvert;
        }

        public void FermetureConnection()
        {
            this.cnx.Close();
        }

        

    }
}
