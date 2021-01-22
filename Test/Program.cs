using System;
using Pand_Ami.Models;
using System.Collections;
using System.Collections.Generic;


namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            UtilisateurDAO dao = new UtilisateurDAO();
            List<Utilisateur> utilisateurs = dao.UtilisateursFromBdd();
            for (int i = 0; i < utilisateurs.Count; i++)
            {
                Console.WriteLine("nom de l'utilisateur n°" + i + " : " + utilisateurs[i].NomUtil);
                Console.WriteLine("Date desinscription de l'utilisateur n°" + i + " : " + utilisateurs[i].DateDesinscription);
            }
        }
    }
}
