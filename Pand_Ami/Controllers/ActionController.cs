using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Pand_Ami.Models;
using Action = Pand_Ami.Models.Action;
using Pand_Ami.Models.Referentiels;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Pand_Ami.Controllers
{
    public class ActionController : Controller
    {
        // GET: HomeController2

        public IActionResult Action()
        {
            return View("posterDemande");
        }
        public ActionResult listeActions()
        {
            ActionDAO myDAO = new ActionDAO();
            ViewBag.test = myDAO.GetPremierString();
            Action ActionResult = myDAO.LireAction(3);
            ViewBag.result = ActionResult.ToString();

            //List<Action> maListe = myDAO.RecupererListeActions();
            //ViewBag.data = maListe;
            ViewBag.data = myDAO.RecupererListeActionsParUtil(1);



            return View();
        }

        public ActionResult posterDemande()
        {
            /*creation de la liste d'activites*/
            ActiviteDAO myActiviteDAO = new ActiviteDAO();
            List<Activite> maListeActiv = myActiviteDAO.RecupererListeActivites();
            List<SelectListItem> listeLabelActivite = new List<SelectListItem>();
            /*Extraction de la liste de libellés d'activite pour les afficher*/
            foreach (var item in maListeActiv)
            {
                listeLabelActivite.Add(new SelectListItem(item.Nom_activite, item.Id_activite.ToString()));
            }
            ViewBag.Activite = listeLabelActivite;



            /*Chargement des minutes et heures*/

            List<Heure> listeHeures = new List<Heure>();
            List<int> listeHeuresLabel = new List<int>();

            for (int i = 1; i <= 24; i++)
            {
                if(i > 6 && i < 22)
                {
                    listeHeures.Add(new Heure(i));
                    listeHeuresLabel.Add(i);
                }
            }

            List<Minute> listeMinutes = new List<Minute>();
            List<int> listeMinutesLabel = new List<int>();

            for (int i = 1; i <= 2; i++)
            {
                listeMinutes.Add(new Minute(i));
                listeMinutesLabel.Add(new Minute(i).ValeurMinute);
            }

            ViewBag.heures = listeHeuresLabel;
            ViewBag.minutes = listeMinutesLabel;

            //Chargement des villes et Adresses postales
            List<Ville> listeVilles = new List<Ville>();
            List<int> listeCP = new List<int>();
            List<string> listeVilleLabel = new List<string>();

            for (int i = 1; i <= 3; i++)
            {
                Ville temp = new Ville(i);
                listeVilles.Add(temp);
                listeCP.Add(temp.CodePostal);
                listeVilleLabel.Add(temp.NomVille);
            }

            ViewBag.villeLabel = listeVilleLabel;
            ViewBag.CP = listeCP;





            return View();
        }


        [HttpPost]
        public ActionResult posterDemande(int idService, DateTime dateRealisation)
        {
            // enregistrer les infos en base

            return View();
        }

            // GET: HomeController2/Details/5
            public ActionResult Details(int id)
        {
            return View();
        }

        // GET: HomeController2/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: HomeController2/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: HomeController2/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: HomeController2/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: HomeController2/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: HomeController2/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
