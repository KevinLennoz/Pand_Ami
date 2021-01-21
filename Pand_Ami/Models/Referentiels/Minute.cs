using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Pand_Ami.Models.Referentiels
{
    public class Minute
    {

        int idMinute;
        int valeurMinute;

        public Minute()
        {
        }

        public Minute(int idMinute)
        {
            this.IdMinute = idMinute;
            this.recupererMinutes(idMinute);
        }

        public int IdMinute { get => idMinute; set => idMinute = value; }
        public int ValeurMinute { get => valeurMinute; set => valeurMinute = value; }

        public void recupererMinutes(int idMinute) //Recuperation des informations Gamme de minute en provenance de la BDD
        {
            AccesBDD BDDPandami = new AccesBDD();
            BDDPandami.OuvertureBDD();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = BDDPandami.Cnx;
            cmd.CommandText = String.Format("SELECT valeur_minute FROM Gamme_minute WHERE id_gamme_minute = {0}", idMinute);
            cmd.CommandType = CommandType.Text;
            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                this.ValeurMinute = (int)dr["valeur_minute"];
            }
            dr.Close();
            BDDPandami.FermetureBDD();
        }
    }
}
