using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ClinicsRegistry.Models;

namespace ClinicsRegistry.Controllers
{
    public class CardsController : Controller
    {
        RegistryDBContext _context;

        public CardsController(RegistryDBContext context)
        {
            _context = context;
        }

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

        // GET: Cards/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Cards/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                ClientCard card = new ClientCard
                {
                    Id = new Guid(),
                    Name = collection.Get("Name"),
                    Surname = collection.Get("Surname"),
                    BirthDate = DateTime.Parse(collection.Get("BirthDate")),
                    IsEmployee = bool.Parse(collection.Get("IsEmployee"))
                };

                _context.Cards.Add(card);
                _context.SaveChanges();

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Cards/Edit/5
        public ActionResult Edit(Guid id)
        {
            return View();
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
