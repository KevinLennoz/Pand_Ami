using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pand_Ami.Models
{
    public class Utilisateur
    {
        private int idUtil;
        private int idGenre;
        private int idVille;
        private int idDesinscription;
        private string nomUtil;
        private string prenomUtil;
        private DateTime dateNaissance;
        private string emailUtil;
        private string telUtil;
        private string voieUtil;
        private string mdpUtil;
        private DateTime dateInscription;
        private string nomContactUrgence;
        private string prenomContactUrgence;
        private string telContactUrgence;
        private DateTime dateDesinscription;


        //constructeur vide
        public Utilisateur()
        {

        }
        
        //constructeur surchargé
        public Utilisateur(int idUtil, int idGenre, int idVille, int idDesinscription, string nomUtil, string prenomUtil, DateTime dateNaissance, string emailUtil, string telUtil, string voieUtil, string mdpUtil, DateTime dateInscription, string nomContactUrgence, string prenomContactUrgence, string telContactUrgence, DateTime dateDesinscription)
        {
            this.IdUtil = idUtil;
            this.IdGenre = idGenre;
            this.IdVille = idVille;
            this.IdDesinscription = idDesinscription;
            this.NomUtil = nomUtil;
            this.PrenomUtil = prenomUtil;
            this.DateNaissance = dateNaissance;
            this.EmailUtil = emailUtil;
            this.TelUtil = telUtil;
            this.VoieUtil = voieUtil;
            this.MdpUtil = mdpUtil;
            this.DateInscription = dateInscription;
            this.NomContactUrgence = nomContactUrgence;
            this.PrenomContactUrgence = prenomContactUrgence;
            this.TelContactUrgence = telContactUrgence;
            this.DateDesinscription = dateDesinscription;
        }

        //getter setter
        public int IdUtil { get => idUtil; set => idUtil = value; }
        public int IdGenre { get => idGenre; set => idGenre = value; }
        public int IdVille { get => idVille; set => idVille = value; }
        public int IdDesinscription { get => idDesinscription; set => idDesinscription = value; }
        public string NomUtil { get => nomUtil; set => nomUtil = value; }
        public string PrenomUtil { get => prenomUtil; set => prenomUtil = value; }
        public DateTime DateNaissance { get => dateNaissance; set => dateNaissance = value; }
        public string EmailUtil { get => emailUtil; set => emailUtil = value; }
        public string TelUtil { get => telUtil; set => telUtil = value; }
        public string VoieUtil { get => voieUtil; set => voieUtil = value; }
        public string MdpUtil { get => mdpUtil; set => mdpUtil = value; }
        public DateTime DateInscription { get => dateInscription; set => dateInscription = value; }
        public string NomContactUrgence { get => nomContactUrgence; set => nomContactUrgence = value; }
        public string PrenomContactUrgence { get => prenomContactUrgence; set => prenomContactUrgence = value; }
        public string TelContactUrgence { get => telContactUrgence; set => telContactUrgence = value; }
        public DateTime DateDesinscription { get => dateDesinscription; set => dateDesinscription = value; }


        //equals et hashcode
        public override bool Equals(object obj)
        {
            return obj is Utilisateur utilisateur &&
                   idUtil == utilisateur.idUtil &&
                   idGenre == utilisateur.idGenre &&
                   idVille == utilisateur.idVille &&
                   idDesinscription == utilisateur.idDesinscription &&
                   nomUtil == utilisateur.nomUtil &&
                   prenomUtil == utilisateur.prenomUtil &&
                   dateNaissance == utilisateur.dateNaissance &&
                   emailUtil == utilisateur.emailUtil &&
                   telUtil == utilisateur.telUtil &&
                   voieUtil == utilisateur.voieUtil &&
                   mdpUtil == utilisateur.mdpUtil &&
                   dateInscription == utilisateur.dateInscription &&
                   nomContactUrgence == utilisateur.nomContactUrgence &&
                   prenomContactUrgence == utilisateur.prenomContactUrgence &&
                   telContactUrgence == utilisateur.telContactUrgence &&
                   dateDesinscription == utilisateur.dateDesinscription;
        }

        public override int GetHashCode()
        {
            HashCode hash = new HashCode();
            hash.Add(idUtil);
            hash.Add(idGenre);
            hash.Add(idVille);
            hash.Add(idDesinscription);
            hash.Add(nomUtil);
            hash.Add(prenomUtil);
            hash.Add(dateNaissance);
            hash.Add(emailUtil);
            hash.Add(telUtil);
            hash.Add(voieUtil);
            hash.Add(mdpUtil);
            hash.Add(dateInscription);
            hash.Add(nomContactUrgence);
            hash.Add(prenomContactUrgence);
            hash.Add(telContactUrgence);
            hash.Add(dateDesinscription);
            return hash.ToHashCode();
        }
    }
}
