using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Pand_Ami.Models
{
    public class Reponse
    {
        private int? idUtil;
        private int? idAction;
        private int? idMotifDesist;
        private DateTime? dateReponse;
        private DateTime? dateSelection;
        private DateTime? dateDesistement;
        private DateTime? dateRejet;

        //constructeurs
        public Reponse()
        {

        }

        public Reponse(int? idUtil, int? idAction, DateTime? dateReponse)
        {
            this.idUtil = idUtil;
            this.idAction = idAction;
            this.dateReponse = dateReponse;
        }

        public Reponse(int? idUtil, int? idAction, int? motifDesist, DateTime? dateReponse, DateTime? dateSelection, DateTime? dateDesistement, DateTime? dateRejet)
        {
            this.IdUtil = idUtil;
            this.IdAction = idAction;
            this.MotifDesist = motifDesist;
            this.DateReponse = dateReponse;
            this.DateSelection = dateSelection;
            this.DateDesistement = dateDesistement;
            this.DateRejet = dateRejet;
        }

        //constructeur surchargé BDD : 

        public Reponse(SqlDataReader dr)
        {
            IdUtil = (int?)dr["id_utilisateur"]; //0
            if(!dr.IsDBNull(dr.GetOrdinal("id_action")))
            {
                idAction = (int)dr["id_action"];
            }
            if (!dr.IsDBNull(dr.GetOrdinal("id_motif_desistement")))
            {
                idMotifDesist = (int)dr["id_motif_desistement"];
            }
            if (!dr.IsDBNull(dr.GetOrdinal("date_reponse")))
            {
                DateReponse = (DateTime)dr["date_reponse"];
            }
            if (!dr.IsDBNull(dr.GetOrdinal("date_selection")))
            {
                DateSelection = (DateTime)dr["date_selection"];
            }
            if (!dr.IsDBNull(dr.GetOrdinal("date_desistement")))
            {
                dateDesistement = (DateTime)dr["date_desistement"];
            }
            if (!dr.IsDBNull(dr.GetOrdinal("date_rejet")))
            {
                dateRejet = (DateTime)dr["date_rejet"];
            }

        }

        public int? IdUtil { get => idUtil; set => idUtil = value; }
        public int? IdAction { get => idAction; set => idAction = value; }
        public int? MotifDesist { get => idMotifDesist; set => idMotifDesist = value; }
        public DateTime? DateReponse { get => dateReponse; set => dateReponse = value; }
        public DateTime? DateSelection { get => dateSelection; set => dateSelection = value; }
        public DateTime? DateDesistement { get => dateDesistement; set => dateDesistement = value; }
        public DateTime? DateRejet { get => dateRejet; set => dateRejet = value; }

        public override bool Equals(object obj)
        {
            return obj is Reponse reponse &&
                   idUtil == reponse.idUtil;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(idUtil, idAction, idMotifDesist, dateReponse, dateSelection, dateDesistement, dateRejet);
        }
    }
}
