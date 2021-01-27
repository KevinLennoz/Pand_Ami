using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Collections;
using Ville = Pand_Ami.Models.Referentiels.Ville;

namespace Pand_Ami.Models
{
    public class UtilisateurDAO
    {
        //recuperer un utilisateur depuis son Id_Util :
        // méthode qui hydrate un objet utilisateur avec les données de la BDD, prend en paramètre l'id_utilisateur
        public Utilisateur UtilisateurFromBdd(int? idUtil)
        {
            AccesBDD bdd = new AccesBDD();
            bdd.OuvertureBDD();
            SqlCommand cmd = new SqlCommand("dbo.RecupererUtilisateurViaId", bdd.Cnx);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@id_util", idUtil));
            SqlDataReader dr = cmd.ExecuteReader();
            dr.Read();
            Utilisateur utilisateur = new Utilisateur(dr);
            bdd.FermetureBDD();
            return utilisateur;
        }

        //recuperer un utilisateur depuis son email :
        // méthode qui hydrate un objet utilisateur avec les données de la BDD, prend en paramètre l'email utilisateur
        public Utilisateur UtilisateurFromBdd(string email)
        {
            AccesBDD bdd = new AccesBDD();
            bdd.OuvertureBDD();
            SqlCommand cmd = new SqlCommand("dbo.RecupererUtilisateurViaEmail", bdd.Cnx);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@email_util", email));
            SqlDataReader dr = cmd.ExecuteReader();
            dr.Read();
            Utilisateur utilisateur = new Utilisateur(dr);
            bdd.FermetureBDD();
            return utilisateur;
        }

        public List<Utilisateur> UtilisateursFromBdd()
        {
            List<Utilisateur> utilisateurs = new List<Utilisateur>();
            AccesBDD bdd = new AccesBDD();
            bdd.OuvertureBDD();
            SqlCommand cmd = new SqlCommand("dbo.RecupererTousLesUtilisateurs", bdd.Cnx);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                Utilisateur utilisateur = new Utilisateur(dr);
                utilisateurs.Add(utilisateur);
            }
            bdd.FermetureBDD();
            return utilisateurs;
        }

        public UtilisateurAffichage UtilisateurVilleFromBdd(int idUtil)
        {
            AccesBDD bdd = new AccesBDD();
            bdd.OuvertureBDD();
            SqlCommand cmd = new SqlCommand("dbo.RecupererUtilisateurVilleViaId", bdd.Cnx);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("id_util", idUtil));
            SqlDataReader dr = cmd.ExecuteReader();
            dr.Read();
            UtilisateurAffichage util = new UtilisateurAffichage(dr);
            bdd.FermetureBDD();
            return util;
        }

        //recuperer un utilisateur via un champ
        //attention à nommer la procédure stockée exactement selon le nom du parametreSql
        
        /*
        public Utilisateur UtilisateurFromBdd(dynamic champ)
        {
            AccesBDD bdd = new AccesBDD();
            bdd.OuvertureBDD();
            string procedureStockee = "dbo.RecupererUtilisateurVia" + (string)champ;
            SqlCommand cmd = new SqlCommand(procedureStockee, bdd.Cnx);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@" + (string)champ, champ));
            SqlDataReader dr = cmd.ExecuteReader();
            dr.Read();
            Utilisateur utilisateur = new Utilisateur(dr);
            bdd.FermetureBDD();
            return utilisateur;
        }
        */
        


    }
}
