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
            return View(from c in _context.Cards
                        select c);
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
        public ActionResult Create(ClientCard card)
        {
            try
            {
                card.Id = Guid.NewGuid();
                _context.Cards.Add(card);
                _context.SaveChanges();

                return RedirectToAction("Index");
            }
            catch (Exception e)
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
