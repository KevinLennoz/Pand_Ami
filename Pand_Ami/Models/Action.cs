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
		public int Id_motif_annul { get; set; }
		public int Id_final { get; set; }
		public int Id_pb { get; set; }
		public DateTime Date_action { get; set; }
		public string Voie_action { get; set; }
		public DateTime Date_soumission { get; set; }
		public DateTime Date_annulation { get; set; }
		public DateTime Date_cloture { get; set; }
		public int Note_evaluation { get; set; }

		/*Public constructor*/
		public Action()
        {
        }
		/*full constructor*/

        public Action(int id_action, int id_util, int id_ville, int id_activite, int id_gamme_heure_debut, int id_gamme_minute_debut, 
            int id_gamme_heure_fin, int id_gamme_minute_fin, DateTime date_action, string voie_action, DateTime date_soumission
            ,int id_motif_annul = -1, int id_final = 1, int id_pb = -1, DateTime date_annulation = new DateTime(), 
            DateTime date_cloture = new DateTime(), int note_evaluation = -1)
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


    }
}
