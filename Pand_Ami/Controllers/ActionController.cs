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
            List<SelectListItem> listeHeuresSelect = new List<SelectListItem>();

            for (int i = 1; i <= 24; i++)
            {
                if(i > 6 && i < 22)
                {
                    listeHeures.Add(new Heure(i));
                }
            }
            foreach (var item in listeHeures)
            {
                listeHeuresSelect.Add(new SelectListItem(item.ValeurHeure.ToString(), item.IdHeure.ToString()));
            }

            List<Minute> listeMinutes = new List<Minute>();
            List<SelectListItem> listeMinutesSelect = new List<SelectListItem>();

            for (int i = 1; i <= 2; i++)
            {
                listeMinutes.Add(new Minute(i));
            }
            foreach (var item in listeMinutes)
            {
                listeMinutesSelect.Add(new SelectListItem(item.ValeurMinute.ToString(), item.IdMinute.ToString()));
            }

            ViewBag.heures = listeHeuresSelect;
            ViewBag.minutes = listeMinutesSelect;

            //Chargement des villes et Adresses postales
            List<Ville> listeVilles = new List<Ville>();
            List<SelectListItem> listeVilleSelect = new List<SelectListItem>();

            for (int i = 1; i <= 3; i++)
            {
                Ville temp = new Ville(i);
                listeVilles.Add(temp);
            }

            foreach (var item in listeVilles)
            {
                listeVilleSelect.Add(new SelectListItem(item.NomVille.ToString() + "-" + item.CodePostal.ToString()
                , item.IdVille.ToString()));
            }
            ViewBag.Ville = listeVilleSelect;



            return View();
        }

        [HttpPost]
        public ActionResult posterDemande(int lstService, int idMateriel, DateTime dateRealisation, int lstHeureDebut,
            int lstMinuteDebut, int lstHeureFin, int lstMinuteFin, int lstVille, string txtAdresse, bool ckbRecurrence)
        {
            // enregistrer les infos en base
            ActionDAO myActionDao = new ActionDAO();
            int idAction = myActionDao.ObtenirProchainIdAction();
            Action action = new Action() {
            Id_action = idAction,
            Id_util = 4,
            Id_ville = lstVille,  
            Id_activite = lstService,
            Id_gamme_heure_debut = lstHeureDebut,
            Id_gamme_minute_debut = lstMinuteDebut,
            Id_gamme_heure_fin = lstHeureFin,
            Id_gamme_minute_fin = lstMinuteFin,
            Id_final = 1,
            Date_action = dateRealisation,
            Voie_action = txtAdresse,
            Date_soumission = DateTime.Now
        };
            try
            {
                myActionDao.EnregistrerNouvelleAction(action);
            } catch(Exception e)
            {
                return View();
            }


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
