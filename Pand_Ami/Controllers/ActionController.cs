using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Pand_Ami.Models;
using Action = Pand_Ami.Models.Action;

namespace Pand_Ami.Controllers
{
    public class ActionController : Controller
    {
        // GET: HomeController2
        public ActionResult listeActions()
        {
            Action act1 = new Action(1,1,1,1,12,1,13,2,new DateTime(), "ma super rue lolz", new DateTime());
            ViewBag.rue = act1.Voie_action;
            ViewBag.dateAction = act1.Date_action;
            ActionDAO myDAO = new ActionDAO();
            //ViewBag.ouv = myDAO.OuvreConnection();
            //myDAO.FermetureBDD();
            ViewBag.test = myDAO.GetPremierString();


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
