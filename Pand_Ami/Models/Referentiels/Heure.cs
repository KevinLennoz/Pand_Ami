using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Pand_Ami.Models.Referentiels
{
    public class Heure
    {

        int idHeure;
        int valeurHeure;

        public Heure()
        {
        }

        public Heure(int idHeure)
        {
            this.IdHeure = idHeure;
            this.recupererHeure(idHeure);
        }

        public int IdHeure { get => idHeure; set => idHeure = value; }
        public int ValeurHeure { get => valeurHeure; set => valeurHeure = value; }

        public void recupererHeure(int idHeure) //Recuperation des informations Gamme d'heure en provenance de la BDD
        {
            AccesBDD BDDPandami = new AccesBDD();
            BDDPandami.OuvertureBDD();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = BDDPandami.Cnx;
            cmd.CommandText = String.Format("SELECT valeur_heure FROM Gamme_heure WHERE id_gamme_heure = {0}", idHeure);
            cmd.CommandType = CommandType.Text;
            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                this.ValeurHeure = (int)dr["valeur_heure"];
            }
            dr.Close();
            BDDPandami.FermetureBDD();
        }
    }
}
