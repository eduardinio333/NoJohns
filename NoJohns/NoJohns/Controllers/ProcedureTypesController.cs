using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using NoJohns.Models;

namespace NoJohns.Controllers
{
    public class ProcedureTypesController : Controller
    {
        private NoJohnsEntities db = new NoJohnsEntities();

        // GET: ProcedureTypes
        public ActionResult Index()
        {
            return View(db.ProcedureTypes.ToList());
        }

        // GET: ProcedureTypes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProcedureType procedureType = db.ProcedureTypes.Find(id);
            if (procedureType == null)
            {
                return HttpNotFound();
            }
            return View(procedureType);
        }

        // GET: ProcedureTypes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ProcedureTypes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,ProcedureName")] ProcedureType procedureType)
        {
            if (ModelState.IsValid)
            {
                db.ProcedureTypes.Add(procedureType);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(procedureType);
        }

        // GET: ProcedureTypes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProcedureType procedureType = db.ProcedureTypes.Find(id);
            if (procedureType == null)
            {
                return HttpNotFound();
            }
            return View(procedureType);
        }

        // POST: ProcedureTypes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,ProcedureName")] ProcedureType procedureType)
        {
            if (ModelState.IsValid)
            {
                db.Entry(procedureType).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(procedureType);
        }

        // GET: ProcedureTypes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProcedureType procedureType = db.ProcedureTypes.Find(id);
            if (procedureType == null)
            {
                return HttpNotFound();
            }
            return View(procedureType);
        }

        // POST: ProcedureTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ProcedureType procedureType = db.ProcedureTypes.Find(id);
            db.ProcedureTypes.Remove(procedureType);
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
