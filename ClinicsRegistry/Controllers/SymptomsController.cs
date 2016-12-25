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
    public class SymptomsController : Controller
    {
        private RegistryDBContext db;

        /// <summary>
        /// Constructor of controller
        /// </summary>
        /// <param name="context">Db context</param>
        public SymptomsController(RegistryDBContext context)
        {
            db = context;
        }

        // GET: Symptoms
        /// <summary>
        /// Returns symptoms.
        /// </summary>
        /// <returns>View</returns>
        public ActionResult Index()
        {
            return View(db.Symptoms.ToList());
        }

        // GET: Symptoms/Details/5
        /// <summary>
        /// Opens "Details" view.
        /// </summary>
        /// <param name="id">Id of Symptom</param>
        /// <returns>View</returns>
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Symptom symptom = db.Symptoms.Find(id);
            if (symptom == null)
            {
                return HttpNotFound();
            }
            return View(symptom);
        }

        // GET: Symptoms/Create
        /// <summary>
        /// Opens "Create" view.
        /// </summary>
        /// <returns>View</returns>
        public ActionResult Create()
        {
            return View();
        }

        // POST: Symptoms/Create
        /// <summary>
        /// Creates new symptom.
        /// </summary>
        /// <param name="symptom">Symptom</param>
        /// <returns>Index view</returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name")] Symptom symptom)
        {
            if (ModelState.IsValid)
            {
                symptom.Id = Guid.NewGuid();
                db.Symptoms.Add(symptom);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(symptom);
        }

        // GET: Symptoms/Edit/5
        /// <summary>
        /// Opens "Edit" view.
        /// </summary>
        /// <param name="id">Id of Symptom</param>
        /// <returns>View</returns>
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Symptom symptom = db.Symptoms.Find(id);
            if (symptom == null)
            {
                return HttpNotFound();
            }
            return View(symptom);
        }

        // POST: Symptoms/Edit/5
        /// <summary>
        /// Updates Symptom.
        /// </summary>
        /// <param name="symptom">Symptom</param>
        /// <returns>Index view</returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name")] Symptom symptom)
        {
            if (ModelState.IsValid)
            {
                db.Entry(symptom).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(symptom);
        }

        // GET: Symptoms/Delete/5
        /// <summary>
        /// Opens "Delete" view
        /// </summary>
        /// <param name="id">Id of Symptom</param>
        /// <returns>View</returns>
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Symptom symptom = db.Symptoms.Find(id);
            if (symptom == null)
            {
                return HttpNotFound();
            }
            return View(symptom);
        }

        // POST: Symptoms/Delete/5
        /// <summary>
        /// Detetes Symptom
        /// </summary>
        /// <param name="id">Id of Symptom</param>
        /// <returns>Index view</returns>
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            Symptom symptom = db.Symptoms.Find(id);
            db.Symptoms.Remove(symptom);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
