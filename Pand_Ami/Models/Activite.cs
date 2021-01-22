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

        public int Id_activite { get; set; }
        public int Id_domaine_activite { get; set; }
        public int Id_materiel { get; set; }
        public string Nom_activite { get; set; }
    }

}
