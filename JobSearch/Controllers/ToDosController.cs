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
    public class ToDosController : Controller
    {
        private JobSearchContext db = new JobSearchContext();

        // GET: ToDos
        public ActionResult Index()
        {
            return View(db.ToDos.ToList());
        }

        // GET: ToDos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ToDos toDos = db.ToDos.Find(id);
            if (toDos == null)
            {
                return HttpNotFound();
            }
            return View(toDos);
        }

        // GET: ToDos/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ToDos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Created,Action,Note,Status,Due")] ToDos toDos)
        {
            if (ModelState.IsValid)
            {
                db.ToDos.Add(toDos);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(toDos);
        }

        // GET: ToDos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ToDos toDos = db.ToDos.Find(id);
            if (toDos == null)
            {
                return HttpNotFound();
            }
            return View(toDos);
        }

        // POST: ToDos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Created,Action,Note,Status,Due")] ToDos toDos)
        {
            if (ModelState.IsValid)
            {
                db.Entry(toDos).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(toDos);
        }

        // GET: ToDos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ToDos toDos = db.ToDos.Find(id);
            if (toDos == null)
            {
                return HttpNotFound();
            }
            return View(toDos);
        }

        // POST: ToDos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ToDos toDos = db.ToDos.Find(id);
            db.ToDos.Remove(toDos);
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
