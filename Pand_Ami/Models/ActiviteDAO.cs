using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.SqlClient;


namespace Pand_Ami.Models
{
    public class ActiviteDAO
    {

        public string ObtenirNomActivite()
        {
            string nomActivite;
            string maRequete = "SELECT TOP (1) nom_activite FROM Activite";
            SqlCommand cmd = new SqlCommand();
            AccesBDD monAccesBDD = new AccesBDD();
            monAccesBDD.OuvertureBDD();
            cmd.Connection = monAccesBDD.Cnx;
            cmd.CommandText = maRequete;
            cmd.CommandType = System.Data.CommandType.Text;
            nomActivite = cmd.ExecuteScalar().ToString();
            monAccesBDD.FermetureBDD();
            return nomActivite;
        }

        public Activite IdToActivite(int id_activite)
        {
            Activite monActivite = new Activite();
            string maRequete = "SELECT * FROM Activite where id_activite = " + id_activite.ToString();
            //Faire une méthode qui à partir d'un requete renvoit une commande SQL
            SqlCommand cmd = new SqlCommand();
            AccesBDD monAccesBDD = new AccesBDD();
            monAccesBDD.OuvertureBDD();
            cmd.Connection = monAccesBDD.Cnx;
            cmd.CommandText = maRequete;
            cmd.CommandType = System.Data.CommandType.Text;
            //Jusque là
            SqlDataReader dr = cmd.ExecuteReader();
            dr.Read();
            monActivite.Id_activite = (int)dr["id_activite"];
            monActivite.Id_domaine_activite = (int)dr["id_domaine_activite"];
            monActivite.Nom_activite = (string)dr["nom_activite"];
            if (!dr.IsDBNull(2))
            {
                monActivite.Id_materiel = (int)dr["id_materiel"];
            }

            return monActivite;
        }
    }
}
