using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Pand_Ami.Models.Referentiels
{
    public class JourSemaine
    {
        int idJourSemaine;
        string libelleJourSemaine;

        public JourSemaine()
        {
        }

        public JourSemaine(int idJour)
        {
            this.idJourSemaine = idJour;
            this.recupererJour(idJour);
        }

        public int IdJourSemaine { get => idJourSemaine; set => idJourSemaine = value; }
        public string LibelleJourSemaine { get => libelleJourSemaine; set => libelleJourSemaine = value; }

        public void recupererJour(int idJour) //Recuperation des informations Jour de la Semaine en provenance de la BDD
        {
            AccesBDD BDDPandami = new AccesBDD();
            BDDPandami.OuvertureBDD();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = BDDPandami.Cnx;
            cmd.CommandText = String.Format("SELECT libelle_jour FROM Jour_semaine WHERE id_jour = {0}", idJour);
            cmd.CommandType = CommandType.Text;
            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                this.LibelleJourSemaine = (string)dr["libelle_jour"];
            }
            dr.Close();
            BDDPandami.FermetureBDD();
        }
    }
}
