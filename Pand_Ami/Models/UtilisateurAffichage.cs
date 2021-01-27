using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.SqlClient;


namespace Pand_Ami.Models
{
    public class UtilisateurAffichage
    {
        private int? idUtil;
        private string nomUtil;
        private string prenomUtil;
        private DateTime? dateNaissance;
        private string emailUtil;
        private string telUtil;
        private string voieUtil;
        private DateTime? dateInscription;
        private string nomContactUrgence;
        private string prenomContactUrgence;
        private string telContactUrgence;
        private int? idVille;
        private string nomVille;
        private int? codePostal;

        public UtilisateurAffichage()
        {

        }
        public UtilisateurAffichage(int? idUtil, string nomUtil, string prenomUtil, DateTime? dateNaissance, string emailUtil, string telUtil, string voieUtil, DateTime? dateInscription,
            string nomContactUrgence, string prenomContactUrgence, string telContactUrgence, int? idVille, string nomVille, int? codePostal)
        {
            this.idUtil = idUtil;
            this.nomUtil = nomUtil;
            this.prenomUtil = prenomUtil;
            this.dateNaissance = dateNaissance;
            this.emailUtil = emailUtil;
            this.telUtil = telUtil;
            this.voieUtil = voieUtil;
            this.dateInscription = dateInscription;
            this.nomContactUrgence = nomContactUrgence;
            this.prenomContactUrgence = prenomContactUrgence;
            this.telContactUrgence = telContactUrgence;
            this.idVille = idVille;
            this.nomVille = nomVille;
            this.codePostal = codePostal;
        }
        public UtilisateurAffichage(SqlDataReader dr)
        {

            if (!dr.IsDBNull(dr.GetOrdinal("id_util")))
            {
                IdUtil = (int?)dr["id_util"];
            }
            if (!dr.IsDBNull(dr.GetOrdinal("id_ville")))
            {
                IdVille = (int?)dr["id_ville"];
            }
            if (!dr.IsDBNull(dr.GetOrdinal("nom_util")))
            {
                NomUtil = (string)dr["nom_util"];
            }
            if (!dr.IsDBNull(dr.GetOrdinal("prenom_util")))
            {
                PrenomUtil = (string)dr["prenom_util"];
            }
            if (!dr.IsDBNull(dr.GetOrdinal("date_naissance")))
            {
                DateNaissance = (DateTime)dr["date_naissance"];
            }
            if (!dr.IsDBNull(dr.GetOrdinal("email_util")))
            {
                EmailUtil = (string)dr["email_util"];
            }
            if (!dr.IsDBNull(dr.GetOrdinal("tel_util")))
            {
                TelUtil = (string)dr["tel_util"];
            }
            if (!dr.IsDBNull(dr.GetOrdinal("voie_util")))
            {
                VoieUtil = (string)dr["voie_util"];
            }
            if (!dr.IsDBNull(dr.GetOrdinal("date_inscri_util")))
            {
                DateInscription = (DateTime)dr["date_inscri_util"];
            }
            if (!dr.IsDBNull(dr.GetOrdinal("nom_contact_urg")))
            {
                NomContactUrgence = (string)dr["nom_contact_urg"];
            }
            if (!dr.IsDBNull(dr.GetOrdinal("prenom_contact_urg")))
            {
                PrenomContactUrgence = (string)dr["prenom_contact_urg"];
            }
            if (!dr.IsDBNull(dr.GetOrdinal("tel_contact_urg")))
            {
                TelContactUrgence = (string)dr["tel_contact_urg"];
            }
            if (!dr.IsDBNull(dr.GetOrdinal("id_ville")))
            {
                IdVille = (int)dr["id_ville"];
            }
            if (!dr.IsDBNull(dr.GetOrdinal("cp")))
            {
                CodePostal = (int)dr["cp"];
            }
            if (!dr.IsDBNull(dr.GetOrdinal("nom_ville")))
            {
                NomVille = (string)dr["nom_ville"];
            }
        }

        public int? IdUtil { get => idUtil; set => idUtil = value; }
        public string NomUtil { get => nomUtil; set => nomUtil = value; }
        public string PrenomUtil { get => prenomUtil; set => prenomUtil = value; }
        public DateTime? DateNaissance { get => dateNaissance; set => dateNaissance = value; }
        public string EmailUtil { get => emailUtil; set => emailUtil = value; }
        public string TelUtil { get => telUtil; set => telUtil = value; }
        public string VoieUtil { get => voieUtil; set => voieUtil = value; }
        public DateTime? DateInscription { get => dateInscription; set => dateInscription = value; }
        public string NomContactUrgence { get => nomContactUrgence; set => nomContactUrgence = value; }
        public string PrenomContactUrgence { get => prenomContactUrgence; set => prenomContactUrgence = value; }
        public string TelContactUrgence { get => telContactUrgence; set => telContactUrgence = value; }
        public int? IdVille { get => idVille; set => idVille = value; }
        public string NomVille { get => nomVille; set => nomVille = value; }
        public int? CodePostal { get => codePostal; set => codePostal = value; }
    }
}
