using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ClinicsRegistry.Models;

namespace ClinicsRegistry.Controllers
{
    public class CardsController : Controller
    {
        private RegistryDBContext db;

        public CardsController(RegistryDBContext context)
        {
            db = context;
        }

        // GET: Cards
        public ActionResult Index()
        {
            return View(db.Cards.ToList());
        }

        // GET: Cards/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var diagnoses = (from d in db.Diseases
                          select d).ToList();
            ClientCard clientCard = db.Cards.Find(id);
            if (clientCard == null)
            {
                return HttpNotFound();
            }
            return View(clientCard);
        }

        // GET: Cards/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Cards/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Surname,BirthDate,IsEmployee")] ClientCard clientCard)
        {
            if (ModelState.IsValid)
            {
                clientCard.Id = Guid.NewGuid();
                db.Cards.Add(clientCard);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(clientCard);
        }

        // GET: Cards/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ClientCard clientCard = db.Cards.Find(id);
            if (clientCard == null)
            {
                return HttpNotFound();
            }
            return View(clientCard);
        }

        // POST: Cards/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Surname,BirthDate,IsEmployee")] ClientCard clientCard)
        {
            if (ModelState.IsValid)
            {
                db.Entry(clientCard).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(clientCard);
        }

        // GET: Cards/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ClientCard clientCard = db.Cards.Find(id);
            if (clientCard == null)
            {
                return HttpNotFound();
            }
            return View(clientCard);
        }

        // POST: Cards/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            ClientCard clientCard = db.Cards.Find(id);
            db.Cards.Remove(clientCard);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
