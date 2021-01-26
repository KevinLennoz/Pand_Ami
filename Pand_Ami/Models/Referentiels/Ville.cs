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

        //constructeur vide
        public Ville()
        {
        }

        public Ville(int idVille)
        {
            this.idVille = idVille;
            this.recupererVille(idVille);
        }

        //constructeur surchargé
        public Ville(int idVille, int codePostal, string nomVille)
        {
            this.idVille = idVille;
            this.codePostal = codePostal;
            this.nomVille = nomVille;
        }
        
        //constructeur qui prend en paramètre le dataReader
        public Ville(SqlDataReader dr)
        {
            if(!dr.IsDBNull(dr.GetOrdinal("id_ville")))
            {
                IdVille = (int)dr["id_ville"];
            }
            if(!dr.IsDBNull(dr.GetOrdinal("CP")))
            {
                CodePostal = (int)dr["CP"];
            }
            if(!dr.IsDBNull(dr.GetOrdinal("nom_ville")))
            {
                NomVille = (string)dr["nom_ville"];
            }
        }

        //getter setter
        public int IdVille { get => idVille; set => idVille = value; }
        public int CodePostal { get => codePostal; set => codePostal = value; }
        public string NomVille { get => nomVille; set => nomVille = value; }


        //methodes
        public void recupererVille(int idVille) //Recuperation des informations Ville en provenance de la BDD
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

        //recupère une liste de toutes les villes
        public List<Ville> recupererVilles()
        {
            List<Ville> villes = new List<Ville>();
            AccesBDD bdd = new AccesBDD();
            bdd.OuvertureBDD();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = bdd.Cnx;
            cmd.CommandText = String.Format("SELECT id_ville, CP, nom_ville FROM Ville");
            cmd.CommandType = CommandType.Text;
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                Ville maVille = new Ville(dr);
                villes.Add(maVille);
            }
            bdd.FermetureBDD();
            return villes;
        }

        //méthode qui permet de récupérer une liste seulement des codes postaux
        public List<int> recupererOnlyCP()
        {
            List<int> codesPostaux = new List<int>();
            AccesBDD bdd = new AccesBDD();
            bdd.OuvertureBDD();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = bdd.Cnx;
            cmd.CommandText = String.Format("SELECT CP FROM Ville");
            cmd.CommandType = CommandType.Text;
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                int codepostal = (int)dr["CP"];
                codesPostaux.Add(codepostal);
            }
            bdd.FermetureBDD();
            return codesPostaux;
        }
    }
}
