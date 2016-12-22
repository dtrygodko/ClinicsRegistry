using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ClinicsRegistry.Models;

namespace ClinicsRegistry.Controllers
{
    public class ScheduleController : Controller
    {
        RegistryDBContext _context;

        public ScheduleController(RegistryDBContext context)
        {
            _context = context;
        }

        // GET: Schedule
        public ActionResult Index()
        {
            return View(from i in _context.Visits
                        join c in _context.Cards
                            on i.ClientId equals c.Id
                        select new ScheduleItemViewModel {
                            Id = i.Id,
                            StartDate = i.StartDate,
                            EndDate = i.EndDate,
                            Patient = string.Concat(c.Name, " ", c.Surname)
                        });
        }

        // GET: Schedule/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Schedule/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Schedule/Create
        [HttpPost]
        public ActionResult Create(ScheduleItem item)
        {
            try
            {
                
                _context.Visits.Add(item);
                _context.SaveChanges();

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Schedule/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Schedule/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
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

        // GET: Schedule/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }
    }
}
