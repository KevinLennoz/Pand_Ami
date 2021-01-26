using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Pand_Ami.Models
{
    public class ActionAffichage
    {

        /* Classe composite qui permet de créer un objet ActionAffichage :
         * un objet "action" mais qui contient les éléments à afficher : nom utilisateur, nom ville
         * en BDD, ces informations proviennent de jointures entre tables -> objet composite
         */

        private int? idAction;
        private string nomVille;
        private string nomUtilisateur;
        private string nomActivite;
        private DateTime? dateAction;
        private DateTime? dateSoumission;
        private int? heureDebut;
        private int? heureFin;
        private int? minuteDebut;
        private int? minuteFin;

        public int? IdAction { get => idAction; set => idAction = value; }
        public string NomVille { get => nomVille; set => nomVille = value; }
        public string NomUtilisateur { get => nomUtilisateur; set => nomUtilisateur = value; }
        public string NomActivite { get => nomActivite; set => nomActivite = value; }
        public DateTime? DateAction { get => dateAction; set => dateAction = value; }
        public DateTime? DateSoumission { get => dateSoumission; set => dateSoumission = value; }
        public int? HeureDebut { get => heureDebut; set => heureDebut = value; }
        public int? HeureFin { get => heureFin; set => heureFin = value; }
        public int? MinuteDebut { get => minuteDebut; set => minuteDebut = value; }
        public int? MinuteFin { get => minuteFin; set => minuteFin = value; }

        public ActionAffichage()
        {

        }
        public ActionAffichage(int? idAction, string nomVille, string nomUtilisateur, string nomActivite, DateTime? dateAction,
            DateTime? dateSoumission, int? heureDebut, int? heureFin, int? minuteDebut, int? minuteFin)
        {
            this.IdAction = idAction;
            this.NomVille = nomVille;
            this.NomUtilisateur = nomUtilisateur;
            this.NomActivite = nomActivite;
            this.DateAction = dateAction;
            this.DateSoumission = dateSoumission;
            this.HeureDebut = heureDebut;
            this.HeureFin = heureFin;
            this.MinuteDebut = minuteDebut;
            this.MinuteFin = minuteFin;
        }

        public ActionAffichage(SqlDataReader dr)
        {
            if (!dr.IsDBNull(0))
            {
                IdAction = (int)dr["id_action"];
            }
            if (!dr.IsDBNull(1))
            {
                NomVille = (string)dr["nom_ville"];
            }
            if (!dr.IsDBNull(2))
            {
                NomUtilisateur = (string)dr["nom_util"];
            }
            if (!dr.IsDBNull(3))
            {
                NomActivite = (string)dr["nom_activite"];
            }
            if (!dr.IsDBNull(4))
            {
                DateAction = (DateTime?)dr["date_action"];
            }
            if (!dr.IsDBNull(5))
            {
                DateSoumission = (DateTime?)dr["date_soumission"];
            }
            if (!dr.IsDBNull(6))
            {
                HeureDebut = (int?)dr["heure_debut"];
            }
            if (!dr.IsDBNull(7))
            {
                MinuteDebut = (int?)dr["minute_debut"];
            }
            if (!dr.IsDBNull(8))
            {
                HeureFin = (int?)dr["heure_fin"];
            }
            if (!dr.IsDBNull(9))
            {
                MinuteFin = (int?)dr["minute_fin"];
            }
        }

        public override bool Equals(object obj)
        {
            return obj is ActionAffichage affichage &&
                   IdAction == affichage.IdAction &&
                   NomVille == affichage.NomVille &&
                   NomUtilisateur == affichage.NomUtilisateur &&
                   NomActivite == affichage.NomActivite &&
                   DateAction == affichage.DateAction &&
                   DateSoumission == affichage.DateSoumission &&
                   HeureDebut == affichage.HeureDebut &&
                   HeureFin == affichage.HeureFin &&
                   MinuteDebut == affichage.MinuteDebut &&
                   MinuteFin == affichage.MinuteFin;
        }

        public override int GetHashCode()
        {
            HashCode hash = new HashCode();
            hash.Add(IdAction);
            hash.Add(NomVille);
            hash.Add(NomUtilisateur);
            hash.Add(NomActivite);
            hash.Add(DateAction);
            hash.Add(DateSoumission);
            hash.Add(HeureDebut);
            hash.Add(HeureFin);
            hash.Add(MinuteDebut);
            hash.Add(MinuteFin);
            return hash.ToHashCode();
        }
    }
}
