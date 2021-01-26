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
            ViewBag.villes = ville.recupererVilles();
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
