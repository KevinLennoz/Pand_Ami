using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Pand_Ami.Models.Referentiels
{
    public class MotifAnnul
    {

        int idMotifAnnul;
        string libelleMotifAnnul;

        public MotifAnnul()
        {
        }

        public MotifAnnul(int idMotifAnnul)
        {
            this.IdMotifAnnul = idMotifAnnul;
            this.recupererMotifAnnul(idMotifAnnul);
        }

        public int IdMotifAnnul { get => idMotifAnnul; set => idMotifAnnul = value; }
        public string LibelleMotifAnnul { get => libelleMotifAnnul; set => libelleMotifAnnul = value; }

        public void recupererMotifAnnul(int idMotif) //Recuperation des informations Motif Annulation en provenance de la BDD
        {
            AccesBDD BDDPandami = new AccesBDD();
            BDDPandami.OuvertureBDD();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = BDDPandami.Cnx;
            cmd.CommandText = String.Format("SELECT libelle_motif_annul FROM Motif_annulation WHERE id_motif_annul = {0}", idMotif);
            cmd.CommandType = CommandType.Text;
            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                this.LibelleMotifAnnul = (string)dr["libelle_motif_annul"];
            }
            dr.Close();
            BDDPandami.FermetureBDD();
        }
    }
}
