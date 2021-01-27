using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Pand_Ami.Models
{
    public class ActionsBenef
    {
        /*classe pour afficher les actions d'un bénéficiare dans une liste déroulante*/
        private int idAction;
        private DateTime? dateAction;
        private string nomActivite;

        public ActionsBenef(int idAction, DateTime? dateAction, string nomActivite)
        {
            this.idAction = idAction;
            this.dateAction = dateAction;
            this.nomActivite = nomActivite;
        }

        public int? IdAction { get => idAction; set => idAction = (int)value; }
        public DateTime? DateAction { get => dateAction; set => dateAction = value; }
        public string NomActivite { get => nomActivite; set => nomActivite = value; }

        public ActionsBenef(SqlDataReader reader)
        {
            IdAction = (int)reader["id_action"];
            DateAction = (DateTime)reader["Date_action"];
            NomActivite = (string)reader["nomActivite"];
        }
    }
}
