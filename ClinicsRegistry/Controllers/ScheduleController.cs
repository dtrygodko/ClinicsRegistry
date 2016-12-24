﻿using System;
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
    public class ScheduleController : Controller
    {
        private RegistryDBContext db;

        public ScheduleController(RegistryDBContext context)
        {
            db = context;
        }

        // GET: Schedule
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
                            Patient = string.Concat(c.Name, " ", c.Surname)
                        });
        }

        // GET: Schedule/Details/5
        public ActionResult Details(Guid? id)
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

        // GET: Schedule/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Schedule/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,StartDate,EndDate")] ScheduleItem scheduleItem)
        {
            if (ModelState.IsValid)
            {
                scheduleItem.Id = Guid.NewGuid();
                db.Visits.Add(scheduleItem);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(scheduleItem);
        }

        // GET: Schedule/Edit/5
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
            return View(scheduleItem);
        }

        // POST: Schedule/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,StartDate,EndDate")] ScheduleItem scheduleItem)
        {
            if (ModelState.IsValid)
            {
                db.Entry(scheduleItem).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(scheduleItem);
        }

        // GET: Schedule/Delete/5
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
