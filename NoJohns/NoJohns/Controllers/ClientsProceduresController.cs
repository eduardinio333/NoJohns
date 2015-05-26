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
    public class ClientsProceduresController : Controller
    {
        private NoJohnsEntities db = new NoJohnsEntities();

        // GET: ClientsProcedures
        public ActionResult Index()
        {
            var clientsProcedures = db.ClientsProcedures.Include(c => c.Client).Include(c => c.Procedure);
            return View(clientsProcedures.ToList());
        }

        // GET: ClientsProcedures/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ClientsProcedures clientsProcedures = db.ClientsProcedures.Find(id);
            if (clientsProcedures == null)
            {
                return HttpNotFound();
            }
            return View(clientsProcedures);
        }

        // GET: ClientsProcedures/Create
        public ActionResult Create()
        {
            ViewBag.ClientId = new SelectList(db.Clients, "Id", "Password");
            ViewBag.ProcedureId = new SelectList(db.Procedures, "Id", "Comment");
            return View();
        }

        // POST: ClientsProcedures/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ClientId,ProcedureId,ClientType")] ClientsProcedures clientsProcedures)
        {
            if (ModelState.IsValid)
            {
                db.ClientsProcedures.Add(clientsProcedures);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ClientId = new SelectList(db.Clients, "Id", "Password", clientsProcedures.ClientId);
            ViewBag.ProcedureId = new SelectList(db.Procedures, "Id", "Comment", clientsProcedures.ProcedureId);
            return View(clientsProcedures);
        }

        // GET: ClientsProcedures/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ClientsProcedures clientsProcedures = db.ClientsProcedures.Find(id);
            if (clientsProcedures == null)
            {
                return HttpNotFound();
            }
            ViewBag.ClientId = new SelectList(db.Clients, "Id", "Password", clientsProcedures.ClientId);
            ViewBag.ProcedureId = new SelectList(db.Procedures, "Id", "Comment", clientsProcedures.ProcedureId);
            return View(clientsProcedures);
        }

        // POST: ClientsProcedures/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ClientId,ProcedureId,ClientType")] ClientsProcedures clientsProcedures)
        {
            if (ModelState.IsValid)
            {
                db.Entry(clientsProcedures).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ClientId = new SelectList(db.Clients, "Id", "Password", clientsProcedures.ClientId);
            ViewBag.ProcedureId = new SelectList(db.Procedures, "Id", "Comment", clientsProcedures.ProcedureId);
            return View(clientsProcedures);
        }

        // GET: ClientsProcedures/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ClientsProcedures clientsProcedures = db.ClientsProcedures.Find(id);
            if (clientsProcedures == null)
            {
                return HttpNotFound();
            }
            return View(clientsProcedures);
        }

        // POST: ClientsProcedures/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ClientsProcedures clientsProcedures = db.ClientsProcedures.Find(id);
            db.ClientsProcedures.Remove(clientsProcedures);
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
