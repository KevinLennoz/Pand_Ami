using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace Pand_Ami.Models.Referentiels
{
    public class Ville
    {

        int idVille;
        int codePostal;
        string nomVille;

        public Ville()
        {
        }

        public Ville(int idVille)
        {
            this.idVille = idVille;
            this.recupererVille(idVille);
        }

        public int IdVille { get => idVille; set => idVille = value; }
        public int CodePostal { get => codePostal; set => codePostal = value; }
        public string NomVille { get => nomVille; set => nomVille = value; }

        public void recupererVille (int idVille) //Recuperation des informations Ville en provenance de la BDD
        {
            AccesBDD BDDPandami = new AccesBDD();
            BDDPandami.OuvertureBDD();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = BDDPandami.Cnx;
            cmd.CommandText = String.Format("SELECT CP, nom_ville FROM Ville WHERE id_ville = {0}", idVille);
            cmd.CommandType = CommandType.Text;
            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                this.CodePostal = (int)dr["CP"];
                this.NomVille = (string)dr["nom_ville"];
            }
            dr.Close();
            BDDPandami.FermetureBDD();
        }
    }
}
