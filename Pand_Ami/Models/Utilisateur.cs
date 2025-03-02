﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Pand_Ami.Models
{
    public class Utilisateur
    {
        private int? idUtil;
        private int? idGenre;
        private int? idVille;
        private int? idDesinscription;
        private string nomUtil;
        private string prenomUtil;
        private DateTime? dateNaissance;
        private string emailUtil;
        private string telUtil;
        private string voieUtil;
        private string mdpUtil;
        private DateTime? dateInscription;
        private string nomContactUrgence;
        private string prenomContactUrgence;
        private string telContactUrgence;
        private DateTime? dateDesinscription;

        public int? IdUtil { get => idUtil; set => idUtil = value; }
        public int? IdGenre { get => idGenre; set => idGenre = value; }
        public int? IdVille { get => idVille; set => idVille = value; }
        public int? IdDesinscription { get => idDesinscription; set => idDesinscription = value; }
        public string NomUtil { get => nomUtil; set => nomUtil = value; }
        public string PrenomUtil { get => prenomUtil; set => prenomUtil = value; }
        public DateTime? DateNaissance { get => dateNaissance; set => dateNaissance = value; }
        public string EmailUtil { get => emailUtil; set => emailUtil = value; }
        public string TelUtil { get => telUtil; set => telUtil = value; }
        public string VoieUtil { get => voieUtil; set => voieUtil = value; }
        public string MdpUtil { get => mdpUtil; set => mdpUtil = value; }
        public DateTime? DateInscription { get => dateInscription; set => dateInscription = value; }
        public string NomContactUrgence { get => nomContactUrgence; set => nomContactUrgence = value; }
        public string PrenomContactUrgence { get => prenomContactUrgence; set => prenomContactUrgence = value; }
        public string TelContactUrgence { get => telContactUrgence; set => telContactUrgence = value; }
        public DateTime? DateDesinscription { get => dateDesinscription; set => dateDesinscription = value; }


        //constructeur vide
        public Utilisateur()
        {

        }

        //constructeur surchargé tous les paramètres

        public Utilisateur(int idUtil, int idGenre, int idVille, int idDesinscription, string nomUtil, string prenomUtil, DateTime dateNaissance,
            string emailUtil, string telUtil, string voieUtil, string mdpUtil, DateTime dateInscription, string nomContactUrgence,
            string prenomContactUrgence, string telContactUrgence, DateTime dateDesinscription)
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

        //constructeur surchargé BDD : 
        public Utilisateur(SqlDataReader dr)
        {

            if (!dr.IsDBNull(dr.GetOrdinal("id_util")))
            {
                IdUtil = (int?)dr["id_util"];
            }
            if (!dr.IsDBNull(dr.GetOrdinal("id_ville")))
            {
                IdVille = (int?)dr["id_ville"];
            }
            if (!dr.IsDBNull(dr.GetOrdinal("id_genre")))
            {
                IdGenre = (int)dr["id_genre"];
            }
            if (!dr.IsDBNull(dr.GetOrdinal("id_desinscription")))
            {
                IdDesinscription = (int)dr["id_desinscription"];
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
            if (!dr.IsDBNull(dr.GetOrdinal("mdp_util")))
            {
                MdpUtil = (string)dr["mdp_util"];
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
            if (!dr.IsDBNull(dr.GetOrdinal("date_desinscription")))
            {
                DateDesinscription = (DateTime)dr["date_desinscription"];
            }

            ////syntaxe équivalente pour le test de nullité, avec un if : 
            //if (!dr.IsDBNull(3))
            //{  utilisateur.IdDesinscription = (int)dr["id_desinscription"]; }
        }

        //equals et hashcode
        public override bool Equals(object obj)
        {
            return obj is Utilisateur utilisateur &&
                   emailUtil == utilisateur.emailUtil;
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
