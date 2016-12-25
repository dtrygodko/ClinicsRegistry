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

        /// <summary>
        /// Constructor of controller
        /// </summary>
        /// <param name="context">Db context</param>
        public CardsController(RegistryDBContext context)
        {
            db = context;
        }

        // GET: Cards
        /// <summary>
        /// Returns cards.
        /// </summary>
        /// <returns>View</returns>
        public ActionResult Index()
        {
            return View(db.Cards.ToList());
        }

        // GET: Cards/Details/5
        /// <summary>
        /// Opens "Details" view.
        /// </summary>
        /// <param name="id">Id of ClientCard</param>
        /// <returns>View</returns>
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
        /// <summary>
        /// Opens "Create" view.
        /// </summary>
        /// <returns>View</returns>
        public ActionResult Create()
        {
            return View();
        }

        // POST: Cards/Create
        /// <summary>
        /// Saves new ClientCard.
        /// </summary>
        /// <param name="clientCard">New card</param>
        /// <returns>Index view</returns>
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
        /// <summary>
        /// Opens "Edit" view.
        /// </summary>
        /// <param name="id">Id of ClientCard</param>
        /// <returns>View</returns>
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
        /// <summary>
        /// Updates ClientCard.
        /// </summary>
        /// <param name="clientCard">Card</param>
        /// <returns>Index view</returns>
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
        /// <summary>
        /// Opens "Delete" view
        /// </summary>
        /// <param name="id">Id of ClientCard</param>
        /// <returns>View</returns>
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
        /// <summary>
        /// Detetes ClientCard
        /// </summary>
        /// <param name="id">Id of ClientCard</param>
        /// <returns>Index view</returns>
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
