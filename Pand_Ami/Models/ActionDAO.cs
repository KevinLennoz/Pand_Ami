using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Pand_Ami.Models
{
    public class ActionDAO
    {

        string stringConnect = "Data Source=FORM233\\SQLEXPRESS;Initial Catalog=bddPandami; Integrated Security=true";


        SqlConnection cnx;
        public SqlConnection Cnx
        {
            get { return this.cnx; }
        }
        public ActionDAO()
        {
            this.cnx = new SqlConnection();
        }

        public bool OuvreConnection()
        {
            bool ouvertureOk = false;

            this.cnx.ConnectionString = stringConnect;
            // si ConfigurationManager.ConnectionStrings["baseLocale"] est null, alors, je retourne null, sinon je continue et je retourne la valeur de ConnectionString
            // Récupération d'un app setting : ConfigurationManager.ConfigurationSettings.AppSettings["NumeroSalle"];
            try
            {
                this.cnx.Open();
                ouvertureOk = true;
            }
            catch (SqlException e)
            {
                Console.WriteLine("Erreur ouverture SQL : " + e.Message);
            }
            catch (Exception e)
            {
                Console.WriteLine("Erreur autre sur l'ouverture : " + e.Message);
            }
            return ouvertureOk;
        }

        public void FermetureBDD()
        {
            this.cnx.Close();
        }

        public Action LireAction()
        {
            string maRequete = "SELECT TOP (1) FROM client";
            SqlCommand cmd = new SqlCommand();
            this.OuvreConnection();
            cmd.Connection = this.cnx;
            cmd.CommandText = maRequete;
            cmd.CommandType = System.Data.CommandType.Text;
            SqlDataReader resultat = cmd.ExecuteReader();
            Action actReq = new Action();
            // traitement resultat... voir méthode LireMaTable()
            resultat.Close();
            this.FermetureBDD();
            return actReq;

        }

        public string GetPremierString()
        {
            string voie;
            string requeteSQL = "SELECT TOP (1) voie_action FROM Action";
            SqlCommand cmd = new SqlCommand();
            this.OuvreConnection();
            cmd.Connection = this.cnx;
            cmd.CommandText = requeteSQL;
            cmd.CommandType = System.Data.CommandType.Text;
            voie = cmd.ExecuteScalar().ToString();
            this.FermetureBDD();
            return voie;
        }

    }
}
