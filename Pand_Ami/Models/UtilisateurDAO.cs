using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Collections;

namespace Pand_Ami.Models
{
    public class UtilisateurDAO
    {

        SqlConnection cnx;

        public SqlConnection Cnx
        {
            get { return this.cnx; }
        }

        public UtilisateurDAO()
        {
            this.cnx = new SqlConnection();
        }

        //avec la variable d'environnement qui renvoie le nom de l'ordi : FORM220 par exemple
        private static string nomConnection()
        {
            string stringConnect = "Data Source=" + Environment.MachineName + "\\SQLEXPRESS;Initial Catalog = bddPandami; Integrated Security=true";
            return stringConnect;
        }

        public bool OuvreConnection()
        {
            bool ouvert = false;
            this.cnx.ConnectionString = nomConnection();
            try
            {
                this.cnx.Open();
                ouvert = true;
            }
            catch (SqlException e)
            {
                Console.WriteLine("Erreur ouverture SQL : " + e.Message);
            }
            catch (Exception e)
            {
                Console.WriteLine("Autre type d'erreur à l'ouverture : " + e.Message);
            }
            return ouvert;
        }

        public void FermetureConnection()
        {
            this.cnx.Close();
        }


        //recuperer un utilisateur depuis son Id_Util :
        // méthode qui hydrate un objet utilisateur avec les données de la BDD, prend en paramètre l'id_utilisateur
        public Utilisateur UtilisateurFromBdd(int id)
        {
            Utilisateur utilisateur = new Utilisateur();

            //******** A remplacer par une procédure stockée ********
            string requete = "SELECT * FROM Utilisateur where id_Util = " + id.ToString();
            SqlCommand cmd = new SqlCommand();
            this.OuvreConnection();
            cmd.Connection = this.cnx;
            cmd.CommandText = requete;
            cmd.CommandType = System.Data.CommandType.Text;
            SqlDataReader dr = cmd.ExecuteReader();
            dr.Read();

            //On nourrit l'objet Utilisateur, attribut par attribut, avec les données récupérées en BDD

            // non nullables en BDD : pas de test 
            utilisateur.IdUtil = (int)dr["id_Util"]; //0
            utilisateur.IdVille = (int)dr["id_ville"]; //2

            //test d'abord sur la nullité en BDD : si null, on instancie l'objet avec null en attribut
            utilisateur.IdGenre = !dr.IsDBNull(1) ? (int?)null : (int)dr["id_genre"];
            utilisateur.IdDesinscription = !dr.IsDBNull(3) ? (int?)null : (int)dr["id_desinscription"];
            utilisateur.NomUtil = !dr.IsDBNull(4) ? null : (string)dr["nom_util"];
            utilisateur.PrenomUtil = !dr.IsDBNull(5) ? null : (string)dr["prenom_util"];
            utilisateur.DateNaissance = !dr.IsDBNull(6) ? (DateTime?)null : (DateTime?)dr["date_naissance"];
            utilisateur.EmailUtil = !dr.IsDBNull(7) ? null : (string)dr["email_util"];
            utilisateur.TelUtil = !dr.IsDBNull(8) ? null : (string)dr["tel_util"];
            utilisateur.VoieUtil = !dr.IsDBNull(9) ? null : (string)dr["voie_util"];
            utilisateur.MdpUtil = !dr.IsDBNull(10) ? null : (string)dr["mdp_util"];
            utilisateur.DateInscription = !dr.IsDBNull(11) ? (DateTime?) null : (DateTime?)dr["date_inscri_util"];
            utilisateur.NomContactUrgence = !dr.IsDBNull(12) ? null : (string)dr["nom_contact_urg"];
            utilisateur.PrenomContactUrgence = !dr.IsDBNull(13) ? null : (string)dr["prenom_contact_urg"];
            utilisateur.DateDesinscription = !dr.IsDBNull(15) ? (DateTime?)null : (DateTime)dr["date_desinscription"];

            ////syntaxe équivalente pour le test de nullité, avec un if : 
            //if (!dr.IsDBNull(3))
            //{  utilisateur.IdDesinscription = (int)dr["id_desinscription"]; }

            return utilisateur;
        }

        //recuperer un utilisateur depuis son email :
        // méthode qui hydrate un objet utilisateur avec les données de la BDD, prend en paramètre l'email utilisateur
        public Utilisateur UtilisateurFromBdd(string email)
        {
            Utilisateur utilisateur = new Utilisateur();
            //remplacer par une procédure stockée
            string requete = "SELECT * FROM Utilisateur where id_Util = " + email;
            SqlCommand cmd = new SqlCommand();
            this.OuvreConnection();
            cmd.Connection = this.cnx;
            cmd.CommandText = requete;
            cmd.CommandType = System.Data.CommandType.Text;
            SqlDataReader dr = cmd.ExecuteReader();
            dr.Read();

            // non nullables en BDD : 
            utilisateur.IdUtil = (int)dr["id_Util"]; //0
            utilisateur.IdVille = (int)dr["id_ville"]; //2

            //nullables en BDD :
            utilisateur.IdGenre = !dr.IsDBNull(1) ? (int?)null : (int)dr["id_genre"];
            utilisateur.IdDesinscription = !dr.IsDBNull(3) ? (int?)null : (int)dr["id_desinscription"];
            utilisateur.NomUtil = !dr.IsDBNull(4) ? null : (string)dr["nom_util"];
            utilisateur.PrenomUtil = !dr.IsDBNull(5) ? null : (string)dr["prenom_util"];
            utilisateur.DateNaissance = !dr.IsDBNull(6) ? (DateTime?)null : (DateTime?)dr["date_naissance"];
            utilisateur.EmailUtil = !dr.IsDBNull(7) ? null : (string)dr["email_util"];
            utilisateur.TelUtil = !dr.IsDBNull(8) ? null : (string)dr["tel_util"];
            utilisateur.VoieUtil = !dr.IsDBNull(9) ? null : (string)dr["voie_util"];
            utilisateur.MdpUtil = !dr.IsDBNull(10) ? null : (string)dr["mdp_util"];
            utilisateur.DateInscription = !dr.IsDBNull(11) ? (DateTime?)null : (DateTime?)dr["date_inscri_util"];
            utilisateur.NomContactUrgence = !dr.IsDBNull(12) ? null : (string)dr["nom_contact_urg"];
            utilisateur.PrenomContactUrgence = !dr.IsDBNull(13) ? null : (string)dr["prenom_contact_urg"];
            utilisateur.DateDesinscription = !dr.IsDBNull(15) ? (DateTime?)null : (DateTime)dr["date_desinscription"];

            return utilisateur;
        }


    }
}
