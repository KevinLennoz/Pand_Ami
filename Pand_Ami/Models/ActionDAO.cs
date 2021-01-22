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
