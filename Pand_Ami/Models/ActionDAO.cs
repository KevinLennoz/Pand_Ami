﻿using System;
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

            dr.Close();
            BDDPandami.FermetureBDD();
            return prochainID;
        }

        //methodes pour hydrater les objets ActionAffichage : 

        public List<ActionAffichage> ActionAffichagesFromBdd(int idUtilisateur)
        {
            List<ActionAffichage> lesActionsAffichages = new List<ActionAffichage>();
            AccesBDD bdd = new AccesBDD();
            bdd.OuvertureBDD();
            SqlCommand cmd = new SqlCommand("dbo.recupererToutesActionsPourRecherche", bdd.Cnx);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@id_utilisateur", idUtilisateur));
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                ActionAffichage actionAff = new ActionAffichage(dr);
                lesActionsAffichages.Add(actionAff);
            }
            dr.Close();
            bdd.FermetureBDD();
            return lesActionsAffichages;
        }

        public List<ActionAffichage> ActionAffichagesRechercheFromBdd(int id_activite, int id_ville, DateTime dateFrom, DateTime dateTo,
            int id_util)
        {
            List<ActionAffichage> lesActionsAffichages = new List<ActionAffichage>();
            AccesBDD bdd = new AccesBDD();
            bdd.OuvertureBDD();
            SqlCommand cmd = new SqlCommand("dbo.RecuperationActionsRecherche", bdd.Cnx);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@id_activite", id_activite));
            cmd.Parameters.Add(new SqlParameter("@id_ville", id_ville));
            cmd.Parameters.Add(new SqlParameter("@dateFrom", dateFrom.ToString("yyyy-MM-dd")));
            cmd.Parameters.Add(new SqlParameter("@dateTo", dateTo.ToString("yyyy-MM-dd")));
            cmd.Parameters.Add(new SqlParameter("@id_util", id_util));
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                ActionAffichage actionAff = new ActionAffichage(dr);
                lesActionsAffichages.Add(actionAff);
            }
            dr.Close();
            bdd.FermetureBDD();
            return lesActionsAffichages;
        }

        /*
          * Methode qui renvoie le statut d'une action selon l'utilisateur connecté (Non attribuée, Attribuée ou en cours d'attribution)
          */
        public string RecupererStatutAction(int idAction, int idUtilisateur = 3) // Par défaut util 3
        {
            string statut = "";
            List<Reponse> reponses = new List<Reponse>();

            AccesBDD BDDPandami = new AccesBDD();
            BDDPandami.OuvertureBDD();

            SqlCommand cmd = new SqlCommand("dbo.RecuperDatesPourDefinitionStatut", BDDPandami.Cnx);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@id_action", idAction));
            SqlDataReader reader = cmd.ExecuteReader();

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    reponses.Add(new Reponse(reader));
                }
            }
            else
            {
                statut = "En recherche d'un Volontaire";
            }
            

            foreach(Reponse rep in reponses)
            {
                if (rep.IdUtil != idUtilisateur)
                {
                    if ((rep.DateSelection != null) && (rep.DateDesistement == null) && (rep.DateRejet == null))
                    {
                        statut = "Attribuée à un autre Volontaire";
                        break;
                    }
                    else
                    {
                        statut = "En recherche d'un Volontaire";
                    }
                }
                if (rep.IdUtil == idUtilisateur)
                {
                    if((rep.DateSelection != null) && (rep.DateDesistement == null) && (rep.DateRejet== null))
                    {
                        statut = "Vous a été attribuée";
                        break;
                    }
                    else if ((rep.DateSelection == null) && (rep.DateDesistement == null) && (rep.DateRejet != null))
                    {
                        statut = "Attribuée à un autre Volontaire";
                        break;
                    }
                    else if ((rep.DateSelection == null) && (rep.DateDesistement == null) && (rep.DateRejet == null))
                    {
                        statut = "Demande envoyée - En attente de validation";
                        break;
                    }
                }
            }
            reader.Close();
            BDDPandami.FermetureBDD();
            return statut;
        }

        public Tuple<DateTime,string> DernierService(int id_benef, int id_util)
        {
            string nomActivite = "";
            DateTime dateAction = new DateTime();
            AccesBDD bdd = new AccesBDD();
            bdd.OuvertureBDD();
            SqlCommand cmd = new SqlCommand("dbo.DernierServiceEffectue", bdd.Cnx);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@id_utilBenef", id_benef));
            cmd.Parameters.Add(new SqlParameter("@id_utilVol", id_util));
            SqlDataReader reader = cmd.ExecuteReader();

            reader.Read();
            if (reader.HasRows) 
            {
                nomActivite = (string)reader["nom_activite"];
                dateAction = (DateTime)reader["date_action"];
            }

            reader.Close();
            return Tuple.Create(dateAction, nomActivite);
        }

        public int RecupererGammeActivite(int idAction)
        {
            int gamme = 0;
            
            AccesBDD BDDPandami = new AccesBDD();
            BDDPandami.OuvertureBDD();
            SqlCommand cmd = new SqlCommand("dbo.RecupererTypeActiviteParIdAction", BDDPandami.Cnx);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@id_action", idAction));
            gamme = (int)cmd.ExecuteScalar();
            BDDPandami.FermetureBDD();

            return gamme;
        }

        //Méthode pour afficher les détail de l'action que sélectionne un volontaire
        public ActionBenefChoisie GetActionBenefChoisie(int idAction)
        {
            AccesBDD accesBDD = new AccesBDD();
            SqlCommand cmd = new SqlCommand("dbo.recupererActionBenefChoisie", accesBDD.Cnx);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@id_action", idAction));

            accesBDD.OuvertureBDD();
            SqlDataReader reader = cmd.ExecuteReader();
            reader.Read();
            ActionBenefChoisie a = new ActionBenefChoisie(reader);
            reader.Close();
            accesBDD.FermetureBDD();
            return a;
        }

    }
}
