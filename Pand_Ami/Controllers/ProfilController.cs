using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Pand_Ami.Models;
using Action = Pand_Ami.Models.Action;
using Ville = Pand_Ami.Models.Referentiels.Ville;
using Microsoft.AspNetCore.Mvc.Rendering;


namespace Pand_Ami.Controllers
{
    public class ProfilController : Controller
    {
        // GET: HomeController1

        public IActionResult Profil()
        {
            UtilisateurDAO daoUtil = new UtilisateurDAO();
            ViewBag.utilAffichage = daoUtil.UtilisateurVilleFromBdd(1);

            Ville uneVille= new Ville();
            List<Ville> listeVilles = uneVille.recupererVilles();

            List<SelectListItem> listeVilleSelect = new List<SelectListItem>();
            foreach (var item in listeVilles)
            {
                listeVilleSelect.Add(new SelectListItem(item.NomVille.ToString() + "  " + item.CodePostal.ToString()
                , item.IdVille.ToString()));
            }
            ViewBag.villes = listeVilleSelect;
            return View("gererProfil");
        }
        public IActionResult Demandes()
        {
            ActionDAO dao = new ActionDAO();
            ViewBag.listeActions = dao.RecupererListeActivitesEtDatesParUtil(1);
            return View("Demandes");
        }

        [HttpPost]
        public ActionResult Demandes(int actionChoisie)
        {
            ActionDAO dao = new ActionDAO();
            ViewBag.listeActions = dao.RecupererListeActivitesEtDatesParUtil(1);
            ReponseDao daoReponse = new ReponseDao();
            ViewBag.lesReponses = daoReponse.RecupererReponsesAffichage(actionChoisie);
            List<ReponseAffichage> lesReponses = daoReponse.RecupererReponsesAffichage(actionChoisie);
            
            List<DateTime> dateContact = new List<DateTime>();
            List<string> activiteContact = new List<string>();
            for(int i = 0; i < lesReponses.Count; i++)
            {
                int id_volontaire = (int)lesReponses[i].IdUtilisateur;
                var monTuple = dao.DernierService(1, id_volontaire);
                dateContact.Add(monTuple.Item1);
                activiteContact.Add(monTuple.Item2);
            }

            ViewBag.effectueDate = dateContact;
            ViewBag.effectueActivite = activiteContact;
            return View("Demandes");
        }

        [HttpPost]
        public ActionResult DemandesDeux(int idUtilisateur, int idAction)
        {
            int idDeLAction = idAction;
            int idDeLUtilisateur = idUtilisateur;
            return RedirectToAction("Demandes");
        }

            public ActionResult Index()
        {
            return View();
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
