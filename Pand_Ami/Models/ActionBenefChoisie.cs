using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Pand_Ami.Models
{
    public class ActionBenefChoisie
    {
        /*classe pour afficher les informations à propos d'une action du béneficiare*/

        private string nomActivite;
        private DateTime? dateAction;
        private int heureDebut;
        private int minDebut;
        private int heureFin;
        private int minFin;
        private string materiel;

        public string NomActivite { get; set; }
        public DateTime? DateAction { get; set; }
        public int HeureDebut { get; set; }
        public int MinDebut { get; set; }
        public int HeureFin { get; set; }
        public int MinFin { get; set; }
        public string Materiel { get; set; }


        public ActionBenefChoisie(string nomActivite, DateTime? dateAction, int heureDebut, int minDebut, int heureFin, int minFin,
                string materiel, string nomBenevole, string prenomBenevole, string villeBenevole,
            string emailBenevole, string telBenevole, string nomContactUrgence, string prenomContactUrgence, string telContactUrgence)
        {
            this.nomActivite = nomActivite;
            this.dateAction = dateAction;
            this.heureDebut = heureDebut;
            this.minDebut = minDebut;
            this.heureFin = heureFin;
            this.minFin = minFin;
            this.materiel = materiel;
        }

        public ActionBenefChoisie()
        {
        }
        //Constructeur BDD

        public ActionBenefChoisie(SqlDataReader reader)
        {
            //Pour les valeurs toujours non null
            NomActivite = (string)reader["nom_activite"];
            DateAction = (DateTime)reader["date_action"];
            HeureDebut = (int)reader["valeur_heure_debut"];
            MinDebut = (int)reader["valeur_minute_debut"];
            HeureFin = (int)reader["valeur_heure_fin"];
            MinFin = (int)reader["valeur_minute_fin"];
            Materiel = (string)reader["libelle_materiel"];
        }
    }
}
