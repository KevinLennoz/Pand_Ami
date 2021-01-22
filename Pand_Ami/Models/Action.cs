using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.SqlClient;

/*       connectionString="Data Source=IG-PF2A4GNN\SQLEXPRESS;Initial Catalog=bddEQL;
 *       Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False"*/
namespace Pand_Ami.Models
{
    public class Action

    {

        public int Id_action { get; set; }
		public int Id_util { get; set; }
		public int Id_ville { get; set; }
		public int Id_activite { get; set; }
		public int Id_gamme_heure_debut { get; set; }
		public int Id_gamme_minute_debut { get; set; }
		public int Id_gamme_heure_fin { get; set; }
		public int Id_gamme_minute_fin { get; set; }
		public int? Id_motif_annul { get; set; }
		public int Id_final { get; set; }
		public int? Id_pb { get; set; }
		public DateTime Date_action { get; set; }
		public string Voie_action { get; set; }
		public DateTime Date_soumission { get; set; }
		public DateTime? Date_annulation { get; set; }
		public DateTime? Date_cloture { get; set; }
		public int? Note_evaluation { get; set; }

		/*Public constructor*/
		public Action()
        {
        }
		/*full constructor*/

        public Action(int id_action, int id_util, int id_ville, int id_activite, int id_gamme_heure_debut, int id_gamme_minute_debut, 
            int id_gamme_heure_fin, int id_gamme_minute_fin, DateTime date_action, string voie_action, DateTime date_soumission, 
            int id_final, int? id_motif_annul, int? id_pb, DateTime? date_annulation, 
            DateTime? date_cloture, int? note_evaluation)
        {
            Id_action = id_action;
            Id_util = id_util;
            Id_ville = id_ville;
            Id_activite = id_activite;
            Id_gamme_heure_debut = id_gamme_heure_debut;
            Id_gamme_minute_debut = id_gamme_minute_debut;
            Id_gamme_heure_fin = id_gamme_heure_fin;
            Id_gamme_minute_fin = id_gamme_minute_fin;
            Id_motif_annul = id_motif_annul;
            Id_final = id_final;
            Id_pb = id_pb;
            Date_action = date_action;
            Voie_action = voie_action;
            Date_soumission = date_soumission;
            Date_annulation = date_annulation;
            Date_cloture = date_cloture;
            Note_evaluation = note_evaluation;
        }

        /*constructor pour base de données*/
        public Action(SqlDataReader reader)
        {
            Id_action = (int)reader["id_action"];
            Id_util = (int)reader["id_util"];
            Id_ville = (int)reader["id_ville"];
            Id_activite = (int)reader["id_activite"];
            Id_gamme_heure_debut = (int)reader["id_gamme_heure_debut"];
            Id_gamme_minute_debut = (int)reader["id_gamme_minute_debut"];
            Id_gamme_heure_fin = (int)reader["id_gamme_heure_fin"];
            Id_gamme_minute_fin = (int)reader["id_gamme_minute_fin"];

            Date_action = (DateTime)reader["date_action"];
            Voie_action = (string)reader["voie_action"];
            Date_soumission = (DateTime)reader["date_soumission"];
            Id_final = (int)reader["id_final"];

            /*Chargement des colonnes potentiellement Null*/
            if (!reader.IsDBNull(reader.GetOrdinal("id_motif_annul")))
                {
                Id_motif_annul = (int?)reader["id_motif_annul"];
            }
            if (!reader.IsDBNull(reader.GetOrdinal("id_pb")))
            {
                Id_pb = (int?)reader["id_pb"];
            }
            if (!reader.IsDBNull(reader.GetOrdinal("date_annulation")))
            {
                Date_annulation = (DateTime?)reader["date_annulation"];
            }
            if (!reader.IsDBNull(reader.GetOrdinal("date_cloture")))
            {
                Date_cloture = (DateTime?)reader["date_cloture"];
            }
            if (!reader.IsDBNull(reader.GetOrdinal("note_evaluation")))
            {
                Note_evaluation = (int?)reader["note_evaluation"];
            }
        }

        public override bool Equals(object obj)
        {
            return obj is Action action &&
                   Id_action == action.Id_action &&
                   Id_util == action.Id_util &&
                   Id_ville == action.Id_ville &&
                   Id_activite == action.Id_activite &&
                   Id_gamme_heure_debut == action.Id_gamme_heure_debut &&
                   Id_gamme_minute_debut == action.Id_gamme_minute_debut &&
                   Id_gamme_heure_fin == action.Id_gamme_heure_fin &&
                   Id_gamme_minute_fin == action.Id_gamme_minute_fin &&
                   Id_final == action.Id_final &&
                   Date_action == action.Date_action &&
                   Voie_action == action.Voie_action &&
                   Date_soumission == action.Date_soumission;

        }

        public override int GetHashCode()
        {
            HashCode hash = new HashCode();
            hash.Add(Id_action);
            hash.Add(Id_util);
            hash.Add(Id_ville);
            hash.Add(Id_activite);
            hash.Add(Id_gamme_heure_debut);
            hash.Add(Id_gamme_minute_debut);
            hash.Add(Id_gamme_heure_fin);
            hash.Add(Id_gamme_minute_fin);
            hash.Add(Id_final);
            hash.Add(Date_action);
            hash.Add(Voie_action);
            hash.Add(Date_soumission);
            return hash.ToHashCode();
        }

        public override string ToString()
        {
            string tot = "";
            tot += "Action : " + Id_action + ", par utilisateur " + Id_util + " au " + Voie_action + " de la ville" + Id_ville;
            tot += " le " + Date_action;

            return tot;
        }
    }
}
