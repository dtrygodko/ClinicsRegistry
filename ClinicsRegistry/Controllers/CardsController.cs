using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ClinicsRegistry.Controllers
{
    public class CardsController : Controller
    {
        // GET: Cards
        public ActionResult Index()
        {
            return View();
        }

        // GET: Cards/Details/5
        public ActionResult Details(Guid id)
        {
            return View();
        }

        // POST: Cards/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // POST: Cards/Edit/5
        [HttpPost]
        public ActionResult Edit(Guid id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Cards/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }
    }
}
