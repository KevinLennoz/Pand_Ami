using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Pand_Ami.Models
{
    public class Activite
    {
        //int Id_activite;
        //int Id_domaine_activite;
        //string Nom_activite;
        //int Id_materiel;

        //Constructeur sans les nullables
        public Activite(int id_activite, int id_domaine_activite, string nom_activite)
        {
            Id_activite = id_activite;
            Id_domaine_activite = id_domaine_activite;
            Nom_activite = nom_activite;
        }

        public Activite()
        {
        }

        public Activite(SqlDataReader dr)
        {
            if(!dr.IsDBNull(dr.GetOrdinal("id_activite")))
            {
                Id_activite = (int)dr["id_activite"];
            }
            if(!dr.IsDBNull(dr.GetOrdinal("id_domaine_activite")))
            {
                Id_domaine_activite = (int)dr["id_domaine_activite"];
            }
            if (!dr.IsDBNull(dr.GetOrdinal("id_materiel")))
            {
                Id_materiel = (int)dr["id_materiel"];
            }
            if (!dr.IsDBNull(dr.GetOrdinal("nom_activite")))
            {
                Nom_activite = (string)dr["nom_activite"];
            }
        }

        public int Id_activite { get; set; }
        public int Id_domaine_activite { get; set; }
        public int Id_materiel { get; set; }
        public string Nom_activite { get; set; }
    }

}
