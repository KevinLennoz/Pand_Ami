using System;
using Pand_Ami.Models;

namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            UtilisateurDAO dao = new UtilisateurDAO();
            Utilisateur utilisateur = dao.UtilisateurFromBdd(2);
            Utilisateur util = new Utilisateur();
            util.NomUtil = "toto";
            util.IdDesinscription = null;

            if (utilisateur.IdDesinscription == null)
            {
                Console.WriteLine("L'id est null");

            }
           
        }
    }
}
