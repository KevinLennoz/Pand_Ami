using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Pand_Ami.Models
{
    public class ReponseAffichage
    {
        /* classe composite qui permet de créer un objet ReponseAffichage : 
         * un objet "réponse" mais qui contient les éléments à afficher lorsque l'utilisateur
         * bénéficiaire souhaite afficher la liste des réponses à l'une de ses demandes d'actions
         * */

        private int? idAction;
        private int? idUtilisateur;
        private DateTime? dateReponse;
        private string nomVolontaire;
        private string prenomVolontaire;
        private int? age;

        //constructeur vide
        public ReponseAffichage()
        {

        }

        //constructeur surchargé
        public ReponseAffichage(int? idAction, int? idUtilisateur, string nomVolontaire, string prenomVolontaire, DateTime? dateReponse, int? age)
        {
            this.IdAction = idAction;
            this.IdUtilisateur = idUtilisateur;
            this.NomVolontaire = nomVolontaire;
            this.prenomVolontaire = prenomVolontaire;
            this.DateReponse = dateReponse;
            this.Age = age;
        }

        //constructeur surchargé dataReader :
        public ReponseAffichage(SqlDataReader dr)
        {
            if (!dr.IsDBNull(dr.GetOrdinal("id_action")))
            {
                IdAction = (int)dr["id_action"];
            }
            if (!dr.IsDBNull(dr.GetOrdinal("id_utilisateur")))
            {
                IdUtilisateur = (int)dr["id_utilisateur"];
            }
            if (!dr.IsDBNull(dr.GetOrdinal("date_reponse")))
            {
                DateReponse = (DateTime)dr["date_reponse"];
            }
            if (!dr.IsDBNull(dr.GetOrdinal("nom_utilisateur")))
            {
                NomVolontaire = (string)dr["nom_utilisateur"];
            }
            if (!dr.IsDBNull(dr.GetOrdinal("prenom_utilisateur")))
            {
                PrenomVolontaire = (string)dr["prenom_utilisateur"];
            }
            if (!dr.IsDBNull(dr.GetOrdinal("date_naissance")))
            {
                DateTime dateJour = DateTime.Now;
                Age = calculAge((DateTime)dr["date_naissance"]);
            }
        }

        public int calculAge(DateTime dateNaissance)
        {
            DateTime dateJour = DateTime.Now;
            int age = dateJour.Year - dateNaissance.Year;
            if ((dateJour.Month < dateNaissance.Month) ||
                (dateJour.Month == dateNaissance.Month && dateJour.Day < dateNaissance.Day))
                {
                age = age - 1;
            }
            return age;
        }



        //getter setters
        public int? IdAction { get => idAction; set => idAction = value; }
        public int? IdUtilisateur { get => idUtilisateur; set => idUtilisateur = value; }
        public string NomVolontaire { get => nomVolontaire; set => nomVolontaire = value; }
        public string PrenomVolontaire { get => prenomVolontaire; set => prenomVolontaire = value; }
        public DateTime? DateReponse { get => dateReponse; set => dateReponse = value; }
        public int? Age { get => age; set => age = value; }


        //hashcode et les equals
        public override bool Equals(object obj)
        {
            return obj is ReponseAffichage affichage &&
                   idAction == affichage.idAction &&
                   idUtilisateur == affichage.idUtilisateur &&
                   nomVolontaire == affichage.nomVolontaire &&
                   prenomVolontaire == affichage.prenomVolontaire &&
                   dateReponse == affichage.dateReponse &&
                   age == affichage.age;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(idAction, idUtilisateur, nomVolontaire, prenomVolontaire, dateReponse, age);
        }
    }
}
