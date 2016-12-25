using System;
using System.Data;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using ClinicsRegistry.Models;

namespace ClinicsRegistry.Controllers
{
    public class ScheduleController : Controller
    {
        private RegistryDBContext db;

        /// <summary>
        /// Constructor of controller
        /// </summary>
        /// <param name="context">Db context</param>
        public ScheduleController(RegistryDBContext context)
        {
            db = context;
        }

        // GET: Schedule
        /// <summary>
        /// Returns schedule.
        /// </summary>
        /// <returns>View</returns>
        public ActionResult Index()
        {
            return View(from i in db.Visits
                        join c in db.Cards
                            on i.Client.Id equals c.Id
                        select new ScheduleItemViewModel
                        {
                            Id = i.Id,
                            StartDate = i.StartDate,
                            EndDate = i.EndDate,
                            Patient = string.Concat(c.Name, " ", c.Surname),
                            Diagnosis = i.Diagnosis,
                            Price = i.Price
                        });
        }

        // GET: Schedule/Create
        /// <summary>
        /// Opens "Create" view.
        /// </summary>
        /// <returns>View</returns>
        public ActionResult Create()
        {
            var viewModel = new ScheduleItemViewModel();
            viewModel.Patients = (from c in db.Cards
                                            select new SelectListItem
                                            {
                                                Value = c.Id.ToString(),
                                                Text = string.Concat(c.Name, " ", c.Surname)
                                            }).ToList();
            return View(viewModel);
        }

        // POST: Schedule/Create
        /// <summary>
        /// Converts ViewModel into Model and saves new ScheduleItem.
        /// </summary>
        /// <param name="itemViewModel">ViewModel of ScheduleItem</param>
        /// <returns>Index view</returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,StartDate,EndDate,Client")] ScheduleItemViewModel itemViewModel)
        {
            if (ModelState.IsValid)
            {
                ScheduleItem item = new ScheduleItem();
                item.Id = Guid.NewGuid();
                item.StartDate = itemViewModel.StartDate;
                item.EndDate = itemViewModel.EndDate;
                item.Client = db.Cards.Find(itemViewModel.Client.Id) as ClientCard;
                item.SetPrice();
                db.Visits.Add(item);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(itemViewModel);
        }

        // GET: Schedule/Edit/5
        /// <summary>
        /// Opens "Edit" view.
        /// </summary>
        /// <param name="id">Id of ScheduleItem</param>
        /// <returns>View</returns>
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ScheduleItem scheduleItem = db.Visits.Find(id);
            if (scheduleItem == null)
            {
                return HttpNotFound();
            }
            else
            {
                ScheduleItemViewModel viewModel = new ScheduleItemViewModel
                {
                    Id = scheduleItem.Id,
                    StartDate = scheduleItem.StartDate,
                    EndDate = scheduleItem.EndDate,
                    Client = scheduleItem.Client
                };
                viewModel.Diagnoses = (from c in db.Diseases
                                       select new SelectListItem
                                       {
                                           Value = c.Id.ToString(),
                                           Text = c.Name
                                       }).ToList();

                return View(viewModel);
            }
        }

        // POST: Schedule/Edit/5
        /// <summary>
        /// Converts ViewModel into Model and saves edited ScheduleItem.
        /// </summary>
        /// <param name="viewModel">ViewModel of ScheduleItem</param>
        /// <returns>Index view</returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,StartDate,EndDate,Diagnosis,Client")] ScheduleItemViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                ScheduleItem item = db.Visits.Include("Client").Where(v => v.Id == viewModel.Id).Single();
                item.StartDate = viewModel.StartDate;
                item.EndDate = viewModel.EndDate;
                item.Diagnosis = db.Diseases.Find(viewModel.Diagnosis.Id);
                item.SetPrice();
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(viewModel);
        }

        // GET: Schedule/Delete/5
        /// <summary>
        /// Opens "Delete" view
        /// </summary>
        /// <param name="id">Id of ScheduleItem</param>
        /// <returns>View</returns>
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ScheduleItem scheduleItem = db.Visits.Find(id);
            if (scheduleItem == null)
            {
                return HttpNotFound();
            }
            return View(scheduleItem);
        }

        // POST: Schedule/Delete/5
        /// <summary>
        /// Detetes ScheduleItem
        /// </summary>
        /// <param name="id">Id of ScheduleItem</param>
        /// <returns>Index view</returns>
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            ScheduleItem scheduleItem = db.Visits.Find(id);
            db.Visits.Remove(scheduleItem);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
