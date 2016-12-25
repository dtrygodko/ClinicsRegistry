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
    public class DiseasesController : Controller
    {
        private RegistryDBContext db;

        /// <summary>
        /// Constructor of controller
        /// </summary>
        /// <param name="context">Db context</param>
        public DiseasesController(RegistryDBContext context)
        {
            db = context;
        }

        // GET: Diseases
        /// <summary>
        /// Returns diseases.
        /// </summary>
        /// <returns>View</returns>
        public ActionResult Index()
        {
            return View(db.Diseases.ToList());
        }

        // GET: Diseases/Details/5
        /// <summary>
        /// Opens "Details" view.
        /// </summary>
        /// <param name="id">Id of Disease</param>
        /// <returns>View</returns>
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Disease disease = db.Diseases.Find(id);
            if (disease == null)
            {
                return HttpNotFound();
            }
            return View(disease);
        }

        // GET: Diseases/Create
        /// <summary>
        /// Opens "Create" view.
        /// </summary>
        /// <returns>View</returns>
        public ActionResult Create()
        {
            return View();
        }

        // POST: Diseases/Create
        /// <summary>
        /// Creates new disease.
        /// </summary>
        /// <param name="disease">Disease</param>
        /// <returns>Index view</returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Description")] Disease disease)
        {
            if (ModelState.IsValid)
            {
                disease.Id = Guid.NewGuid();
                db.Diseases.Add(disease);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(disease);
        }

        // GET: Diseases/Edit/5
        /// <summary>
        /// Opens "Edit" view.
        /// </summary>
        /// <param name="id">Id of Disease</param>
        /// <returns>View</returns>
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Disease disease = db.Diseases.Find(id);
            if (disease == null)
            {
                return HttpNotFound();
            }
            return View(disease);
        }

        // POST: Diseases/Edit/5
        /// <summary>
        /// Updates Disease.
        /// </summary>
        /// <param name="disease">Disease</param>
        /// <returns>Index view</returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Description")] Disease disease)
        {
            if (ModelState.IsValid)
            {
                db.Entry(disease).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(disease);
        }

        // GET: Diseases/Delete/5
        /// <summary>
        /// Opens "Delete" view
        /// </summary>
        /// <param name="id">Id of Disease</param>
        /// <returns>View</returns>
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Disease disease = db.Diseases.Find(id);
            if (disease == null)
            {
                return HttpNotFound();
            }
            return View(disease);
        }

        // POST: Diseases/Delete/5
        /// <summary>
        /// Detetes Disease
        /// </summary>
        /// <param name="id">Id of Disease</param>
        /// <returns>Index view</returns>
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            Disease disease = db.Diseases.Find(id);
            db.Diseases.Remove(disease);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
