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
        * Cette méthode renvoie un int : "1" si l'écriture a été effectuée, "0" dans le cas contraire.
        */
        public int EnregistrerNouvelleReponse(int? idUtilisateur, int idAction)
        {
            int nbTuple = 0;
            List<Reponse> reponses = RecupererReponses(idAction);

            foreach (Reponse rep in reponses)
            {
                if ((rep.IdUtil != idUtilisateur) && (rep.DateSelection != null))
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

                        nbTuple = cmd.ExecuteNonQuery();
                        BDDPandami.FermetureBDD();
                    }
                    catch (SqlException e)
                    {
                        nbTuple = 0;
                        Console.WriteLine("Erreur : " + e.Message);
                    }
                }
            }
            return nbTuple;
        }

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
                listeSortante.Add(new Reponse((int)dr["id_utilisateur"], (int)dr["id_action"], (DateTime)dr["date_reponse"]));
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
