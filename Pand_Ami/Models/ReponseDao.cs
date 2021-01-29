using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Pand_Ami.Models
{
    public class ReponseDao
    {

        /*
        * Methode qui prend en paramètre un id utilisateur ainsi qu'un id d'action et qui ecrit en base de données, les arguments non nullables d'une nouvelle réponse à une action
        * (Avant d'écrire en base, la méthode vérifie qu'un utilisateur n'est pas déjà été selectionné à cette action)
        */
        public void EnregistrerNouvelleReponse(int? idUtilisateur, int idAction)
        {

            //Recupere l'utilisateur ayant été selectionné par un beneficiaire pour une action (sinon user = null)
            Utilisateur user = RecupererUtilisateurSelectionne(idAction);

            if (user.IdUtil == null) //Si un utilisateur non selectionné alors user.idUtil = null
            {
                try
                {
                    AccesBDD BDDPandami = new AccesBDD();
                    BDDPandami.OuvertureBDD();
                    SqlCommand cmd = new SqlCommand("dbo.EnregistrerNouvelleReponse", BDDPandami.Cnx);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add(new SqlParameter("@id_utilisateur", idUtilisateur));
                    cmd.Parameters.Add(new SqlParameter("@id_action", idAction));
                    cmd.Parameters.Add(new SqlParameter("@date_reponse", DateTime.Now));

                    cmd.ExecuteNonQuery();
                    BDDPandami.FermetureBDD();
                }
                catch (SqlException e)
                {
                    Console.WriteLine("Erreur : " + e.Message);
                }
            }

        }

        /*
         * Méthode permettant d'instancier un utilisateur qui a été selectionné pour une action
         * Cette méthode renvoie un utilisateur si attribué à une action, null dans le cas contraire
         */
        public Utilisateur RecupererUtilisateurSelectionne(int idAction)
        {

            int? idUtil;
            Utilisateur user;

            AccesBDD BDDPandami = new AccesBDD();
            BDDPandami.OuvertureBDD();
            SqlCommand cmd = new SqlCommand("dbo.RecupererVolontaireSelectionne", BDDPandami.Cnx);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@id_action", idAction));
            SqlDataReader reader = cmd.ExecuteReader();
            reader.Read();
            try
            {
                idUtil = reader.GetInt32(reader.GetOrdinal("id_utilisateur"));
            }
            catch (InvalidOperationException){
                idUtil = null;
            }

            if (idUtil != null)
            {
                UtilisateurDAO utilDao = new UtilisateurDAO();
                user = utilDao.UtilisateurFromBdd(idUtil);
            }
            else
            {
                user = new Utilisateur();
            }
            
            BDDPandami.FermetureBDD();

            return user;
        }

        /*
        * Methode qui prend en paramètre un id d'action et qui renvoie la liste de toutes les réponses émises
        */
        public List<Reponse> RecupererReponses(int idAction)
        {
            List<Reponse> listeSortante = new List<Reponse>();
            AccesBDD accesBDD = new AccesBDD();
            accesBDD.OuvertureBDD();
            SqlCommand cmd = new SqlCommand("dbo.RecupererReponsesParIdAction", accesBDD.Cnx);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@id_action", idAction));

            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                listeSortante.Add(new Reponse(dr));
            }

            dr.Close();
            accesBDD.FermetureBDD();

            return listeSortante;
        }

        public List<ReponseAffichage> RecupererReponsesAffichage(int idAction)
        {
            List<ReponseAffichage> reponsesAffichages = new List<ReponseAffichage>();
            AccesBDD bdd = new AccesBDD();
            bdd.OuvertureBDD();
            SqlCommand cmd = new SqlCommand("dbo.afficherListeReponse", bdd.Cnx);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@id_action", idAction));
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                ReponseAffichage reponse = new ReponseAffichage(dr);
                reponsesAffichages.Add(reponse);
            }
            dr.Close();
            bdd.FermetureBDD();
            return reponsesAffichages;
        }
    }
}
