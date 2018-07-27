using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using JobSearch.Models;

namespace JobSearch.Controllers
{
    public class CommunicationsController : Controller
    {
        private JobSearchContext db = new JobSearchContext();

        // GET: Communications
        public ActionResult Index()
        {
            return View(db.Communications.ToList());
        }

        // GET: Communications/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Communication communication = db.Communications.Find(id);
            if (communication == null)
            {
                return HttpNotFound();
            }
            return View(communication);
        }

        // GET: Communications/Create
        public ActionResult Create()
        {
            ViewBag.Companies = new JobSearchContext().Companies.ToList().Select(x =>
                new SelectListItem { Text = x.Name, Value = x.Id.ToString() });
            return View();
        }

        // POST: Communications/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(MakeNewCommunicationRequest communication)
        {
            if (ModelState.IsValid)
            {
                var newCommunication = new Communication
                {
                    JobTitle = communication.JobTitle,
                    FirstName = communication.FirstName,
                    LastName = communication.LastName,
                    StartDate = communication.StartDate,
                    Departments = db.Departments.Find(communication.DepartmentId)
                };
                db.Communications.Add(newCommunication);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(communication);
        }
        public ActionResult Create([Bind(Include = "Id,When,Company,Contact,Direction,Method,Details")] Communication communication)
        {
            if (ModelState.IsValid)
            {
                db.Communications.Add(communication);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(communication);
        }

        // GET: Communications/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Communication communication = db.Communications.Find(id);
            if (communication == null)
            {
                return HttpNotFound();
            }
            return View(communication);
        }

        // POST: Communications/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,When,Company,Contact,Direction,Method,Details")] Communication communication)
        {
            if (ModelState.IsValid)
            {
                db.Entry(communication).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(communication);
        }

        // GET: Communications/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Communication communication = db.Communications.Find(id);
            if (communication == null)
            {
                return HttpNotFound();
            }
            return View(communication);
        }

        // POST: Communications/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Communication communication = db.Communications.Find(id);
            db.Communications.Remove(communication);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
