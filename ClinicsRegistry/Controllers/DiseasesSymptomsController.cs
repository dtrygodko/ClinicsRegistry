using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ClinicsRegistry.Models;

namespace ClinicsRegistry.Controllers
{
    public class DiseasesSymptomsController : Controller
    {
        private RegistryDBContext db;

        /// <summary>
        /// Constructor of controller
        /// </summary>
        /// <param name="context">Db context</param>
        public DiseasesSymptomsController(RegistryDBContext context)
        {
            db = context;
        }

        // GET: DiseasesSymptoms
        /// <summary>
        /// Opens "Index" view.
        /// </summary>
        /// <returns>View</returns>
        public ActionResult Index()
        {
            return View();
        }

        // GET: DiseasesSymptoms/Create
        /// <summary>
        /// Opens "Create" view.
        /// </summary>
        /// <returns>View</returns>
        public ActionResult Create()
        {
            DiseasesSymptomsViewModel viewModel = new DiseasesSymptomsViewModel();
            viewModel.Diseases = (from d in db.Diseases
                                  select new SelectListItem
                                  {
                                      Value = d.Id.ToString(),
                                      Text = d.Name
                                  }).ToList();
            viewModel.Symptoms = (from s in db.Symptoms
                                  select new SelectListItem
                                  {
                                      Value = s.Id.ToString(),
                                      Text = s.Name
                                  }).ToList();
            return View(viewModel);
        }

        // POST: DiseasesSymptoms/Create
        /// <summary>
        /// Converts ViewModel and saves new relation between Disease and Symptom.
        /// </summary>
        /// <param name="item">ViewModel</param>
        /// <returns>Index view</returns>
        [HttpPost]
        public ActionResult Create([Bind(Include = "Disease, Symptom")] DiseasesSymptomsViewModel item)
        {
            try
            {
                var symptoms = (from s in db.Symptoms
                                select s).ToList();
                var diseases = (from d in db.Diseases
                                select d).ToList();
                var symptom = db.Symptoms.Find(item.Symptom.Id);
                var disease = db.Diseases.Find(item.Disease.Id);
                symptom.Diseases.Add(disease);
                db.SaveChanges();
            }
            catch
            {
                
            }
            return RedirectToAction("Index");
        }
    }
}
