using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Pand_Ami.Models
{
    public class ActionDAO
    {

        public Action LireAction(int ID)
        {
            string maRequete = "SELECT * FROM action WHERE id_action = " + ID;
            SqlCommand cmd = new SqlCommand();
            AccesBDD accesBDD = new AccesBDD();
            accesBDD.OuvertureBDD();
            cmd.Connection = accesBDD.Cnx;
            cmd.CommandText = maRequete;
            cmd.CommandType = System.Data.CommandType.Text;
            SqlDataReader resultat = cmd.ExecuteReader();
            resultat.Read();
            Action actReq = new Action(resultat);
            resultat.Close();
            accesBDD.FermetureBDD();
            return actReq;

        }

        public Action LireAction_Test(int idAction)
        {

            AccesBDD BDDPandami = new AccesBDD();
            BDDPandami.OuvertureBDD();

            SqlCommand cmd = new SqlCommand("dbo.RecuperationAction", BDDPandami.Cnx);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@id_action", idAction));

            SqlDataReader resultat = cmd.ExecuteReader();

            Action actReq = new Action();
            while (resultat.Read())
            {
                actReq.Id_action = (int)resultat["id_action"];
                actReq.Id_util = (int)resultat["id_util"];
                actReq.Id_gamme_heure_debut = (int)resultat["id_gamme_heure_debut"];
                actReq.Id_gamme_minute_debut = (int)resultat["id_gamme_minute_debut"];
            }

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

    }
}
