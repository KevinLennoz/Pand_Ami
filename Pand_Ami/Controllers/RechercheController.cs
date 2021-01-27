using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Pand_Ami.Models;
using Action = Pand_Ami.Models.Action;
using Utilisateur = Pand_Ami.Models.Utilisateur;
using Reponse = Pand_Ami.Models.Reponse;
using Ville = Pand_Ami.Models.Referentiels.Ville;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Pand_Ami.Controllers
{
    public class RechercheController : Controller
    {

        public ActionResult afficherActions()
        {
            ActionDAO daoAction = new ActionDAO();
            ViewBag.lesActionsAffichages = daoAction.ActionAffichagesFromBdd();
            ActiviteDAO daoActivite = new ActiviteDAO();
            ViewBag.listeActivites = daoActivite.RecupererListeActivites();
            Ville ville = new Ville();
            List<Ville> listeVilles = ville.recupererVilles();
            

            List<SelectListItem> listeVilleSelect = new List<SelectListItem>();
            foreach (var item in listeVilles)
            {
                listeVilleSelect.Add(new SelectListItem(item.NomVille.ToString() + "  " + item.CodePostal.ToString()
                , item.IdVille.ToString()));
            }
            ViewBag.villes = listeVilleSelect;

            return View("rechercherAction");
        }
        [HttpPost]
        public ActionResult afficherActions(int radioActivite, int lstVille, DateTime dateFrom, DateTime dateTo)
        {

            //l'id Utilisateur est codé en dur; c'est le numéro 4 dans la fonction ci-dessous
            ActionDAO daoAction = new ActionDAO();
            List<ActionAffichage>  maListeRecherchee = daoAction.ActionAffichagesRechercheFromBdd(radioActivite, lstVille, dateFrom, dateTo, 4);

            ViewBag.lesActionsAffichages = maListeRecherchee;
            ActiviteDAO daoActivite = new ActiviteDAO();
            ViewBag.listeActivites = daoActivite.RecupererListeActivites();
            Ville ville = new Ville();
            List<Ville> listeVilles = ville.recupererVilles();

            List<SelectListItem> listeVilleSelect = new List<SelectListItem>();
            foreach (var item in listeVilles)
            {
                listeVilleSelect.Add(new SelectListItem(item.NomVille.ToString() + "  " + item.CodePostal.ToString()
                , item.IdVille.ToString()));
            }
            ViewBag.villes = listeVilleSelect;

            return View("rechercherAction");
        }

            public ActionResult RechercherAction()
        {
            return View();
        }

        public IActionResult Recherche()
        {
            return View("rechercherAction");
        }

        // GET: HomeController1/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: HomeController1/Create
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Postuler(int idAction, int idUtilisateur = 3) //Indication de l'id utilisateur avec la valeur 3 à modifier une fois l'interface creation de profil implémentée
        {
            ReponseDao repDAO = new ReponseDao();
            repDAO.EnregistrerNouvelleReponse(idUtilisateur, idAction);

            return RedirectToAction("afficherActions");
        }

        // POST: HomeController1/Create
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

        // GET: HomeController1/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: HomeController1/Edit/5
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

        // GET: HomeController1/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: HomeController1/Delete/5
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
