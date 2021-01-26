using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace Pand_Ami.Models
{
    public class ActionDAO
    {

        public Action LireAction(int idAction)
        {

            AccesBDD BDDPandami = new AccesBDD();
            BDDPandami.OuvertureBDD();

            SqlCommand cmd = new SqlCommand("dbo.RecuperationAction", BDDPandami.Cnx);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@id_action", idAction));

            SqlDataReader resultat = cmd.ExecuteReader();
            resultat.Read();
            Action actReq = new Action(resultat);
  
            resultat.Close();
            BDDPandami.FermetureBDD();

            return actReq;
        }

        public List<Action> RecupererListeActions()
        {
            List<Action> listeSortante = new List<Action>();
            string maRequete = "SELECT * FROM action";
            SqlCommand cmd = new SqlCommand();
            AccesBDD accesBDD = new AccesBDD();
            accesBDD.OuvertureBDD();
            cmd.Connection = accesBDD.Cnx;
            cmd.CommandText = maRequete;
            SqlDataReader resultat = cmd.ExecuteReader();

            if (!resultat.HasRows)
            {
                
            }
            while (resultat.Read())
            {
                Action actTemp = new Action(resultat);
                listeSortante.Add(actTemp);
            }
            resultat.Close();
            accesBDD.FermetureBDD();

            return listeSortante;

            }

        public List<Action> RecupererListeActionsParUtil(int idUtil)
        {
            List<Action> listeSortante = new List<Action>();
            AccesBDD accesBDD = new AccesBDD();
            accesBDD.OuvertureBDD();
            SqlCommand cmd = new SqlCommand("dbo.RecuperationActionParUtil", accesBDD.Cnx);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@id_util", idUtil));

            SqlDataReader resultat = cmd.ExecuteReader();

            if (!resultat.HasRows)
            {

            }
            while (resultat.Read())
            {
                Action actTemp = new Action(resultat);
                listeSortante.Add(actTemp);
            }
            resultat.Close();
            accesBDD.FermetureBDD();

            return listeSortante;

        }

        //Méthode pour la liste des dates et activités d'un utilisateur (pour l'afficher sur son profil)
        public List<ActionsBenef> RecupererListeActivitesEtDatesParUtil(int idUtil)
        {
            List<ActionsBenef> listeSortante = new List<ActionsBenef>();
            AccesBDD accesBDD = new AccesBDD();
            accesBDD.OuvertureBDD();
            SqlCommand cmd = new SqlCommand("dbo.recupererDateActivitePourProfil", accesBDD.Cnx);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@id_util", idUtil));

            SqlDataReader resultat = cmd.ExecuteReader();
            
            if (!resultat.HasRows)
            {

            }
            while (resultat.Read())
            {
                ActionsBenef actTemp = new ActionsBenef(resultat);
                listeSortante.Add(actTemp);
            }
            resultat.Close();
            accesBDD.FermetureBDD();
            return listeSortante;
        }
        public string GetPremierString()
        {
            string voie;
            string requeteSQL = "SELECT TOP (1) voie_action FROM Action";
            SqlCommand cmd = new SqlCommand();
            AccesBDD accesBDD = new AccesBDD();
            accesBDD.OuvertureBDD();
            cmd.Connection = accesBDD.Cnx;
            cmd.CommandText = requeteSQL;
            cmd.CommandType = System.Data.CommandType.Text;
            voie = cmd.ExecuteScalar().ToString();
            accesBDD.FermetureBDD();
            return voie;
        }

        /*
         * Methode qui prend en paramètre une Action et qui ecrit en base de données, les arguments non nullables d'une nouvelle demande
         * Cette méthode renvoie un int : "1" si l'écriture a été effectuée, "0" dans le cas contraire.
         */
        public int EnregistrerNouvelleAction (Action action)
        {

            AccesBDD BDDPandami = new AccesBDD();
            BDDPandami.OuvertureBDD();
            SqlCommand cmd = new SqlCommand("dbo.EnregistrerNouvelleAction", BDDPandami.Cnx);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add(new SqlParameter("@id_action", action.Id_action));
            cmd.Parameters.Add(new SqlParameter("@id_util", action.Id_util));
            cmd.Parameters.Add(new SqlParameter("@id_ville", action.Id_ville));
            cmd.Parameters.Add(new SqlParameter("@id_activite", action.Id_activite));
            cmd.Parameters.Add(new SqlParameter("@id_gamme_heure_debut", action.Id_gamme_heure_debut));
            cmd.Parameters.Add(new SqlParameter("@id_gamme_minute_debut", action.Id_gamme_minute_debut));
            cmd.Parameters.Add(new SqlParameter("@id_gamme_heure_fin", action.Id_gamme_heure_fin));
            cmd.Parameters.Add(new SqlParameter("@id_gamme_minute_fin", action.Id_gamme_minute_fin));
            cmd.Parameters.Add(new SqlParameter("@id_final", 1));
            cmd.Parameters.Add(new SqlParameter("@date_action", action.Date_action));
            cmd.Parameters.Add(new SqlParameter("@voie_action", action.Voie_action));
            cmd.Parameters.Add(new SqlParameter("@date_soumission", action.Date_soumission));

            int nbTuple = cmd.ExecuteNonQuery();
            BDDPandami.FermetureBDD();
            return nbTuple;
        }

        /*
         * Methode qui renvoie la prochaine valeur (id_action), n'étant pas encore attribuée à une demande d'action en Base
         */
        public int ObtenirProchainIdAction() 
        {
            int prochainID = 0;

            AccesBDD BDDPandami = new AccesBDD();
            BDDPandami.OuvertureBDD();

            SqlCommand cmdIDAction = new SqlCommand("dbo.DernierIDAction", BDDPandami.Cnx);
            cmdIDAction.CommandType = CommandType.StoredProcedure;

            SqlDataReader dr = cmdIDAction.ExecuteReader();
            dr.Read();

            prochainID = (int)dr["id_action"] + 1;
            
            BDDPandami.FermetureBDD();
            return prochainID;
        }

        //methodes pour hydrater les objets ActionAffichage : 

        public List<ActionAffichage> ActionAffichagesFromBdd()
        {
            List<ActionAffichage> lesActionsAffichages = new List<ActionAffichage>();
            AccesBDD bdd = new AccesBDD();
            bdd.OuvertureBDD();
            SqlCommand cmd = new SqlCommand("dbo.recupererToutesActionsPourRecherche", bdd.Cnx);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                ActionAffichage actionAff = new ActionAffichage(dr);
                lesActionsAffichages.Add(actionAff);
            }
            bdd.FermetureBDD();
            return lesActionsAffichages;
        }



        public List<ActionAffichage> ActionAffichagesRechercheFromBdd(int id_activite, int id_ville, DateTime dateFrom, DateTime dateTo)
        {
            List<ActionAffichage> lesActionsAffichages = new List<ActionAffichage>();
            AccesBDD bdd = new AccesBDD();
            bdd.OuvertureBDD();
            SqlCommand cmd = new SqlCommand("dbo.RecuperationActionsRecherche", bdd.Cnx);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@id_activite", id_activite));
            cmd.Parameters.Add(new SqlParameter("@id_ville", id_ville));
            cmd.Parameters.Add(new SqlParameter("@dateFrom", dateFrom));
            cmd.Parameters.Add(new SqlParameter("@dateTo", dateTo));
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                ActionAffichage actionAff = new ActionAffichage(dr);
                lesActionsAffichages.Add(actionAff);
            }
            bdd.FermetureBDD();
            return lesActionsAffichages;
        }

    }
}
