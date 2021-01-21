using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Pand_Ami.Models.Referentiels
{
    public class MotifDesist
    {

        int idMotifDesist;
        string libelleMotifDesist;

        public MotifDesist()
        {
        }

        public MotifDesist(int idMotifDesist)
        {
            this.IdMotifDesist = idMotifDesist;
            this.recupererMotifDesist(idMotifDesist);

        }

        public int IdMotifDesist { get => idMotifDesist; set => idMotifDesist = value; }
        public string LibelleMotifDesist { get => libelleMotifDesist; set => libelleMotifDesist = value; }

        public void recupererMotifDesist(int idMotif) //Recuperation des informations Motif Desistement en provenance de la BDD
        {
            AccesBDD BDDPandami = new AccesBDD();
            BDDPandami.OuvertureBDD();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = BDDPandami.Cnx;
            cmd.CommandText = String.Format("SELECT libelle_motif_desist FROM Motif_desist WHERE id_motif_desist = {0}", idMotif);
            cmd.CommandType = CommandType.Text;
            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                this.LibelleMotifDesist = (string)dr["libelle_motif_desist"];
            }
            dr.Close();
            BDDPandami.FermetureBDD();
        }
    }
}
