using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using test002.Models;

namespace test002.Controllers
{
    public class candidatsController : Controller
    {
        private oceanEntities db = new oceanEntities();

        // GET: candidats
       
        public ActionResult Index()
        {
           
            return View(db.candidats.ToList());
        }

        // GET: candidats/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            candidats candidats = db.candidats.Find(id);
            if (candidats == null)
            {
                return HttpNotFound();
            }
            return View(candidats);
        }

        // GET: candidats/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: candidats/Create
        // Pour vous protéger des attaques par survalidation, activez les propriétés spécifiques auxquelles vous souhaitez vous lier. Pour 
        // plus de détails, consultez https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "matricule,nom,prénom,mail,Téléphone,niveau,Expr,dernier_emp")] candidats candidats)
        {
            if (ModelState.IsValid)
            {
                db.candidats.Add(candidats);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(candidats);
        }

        // GET: candidats/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            candidats candidats = db.candidats.Find(id);
            if (candidats == null)
            {
                return HttpNotFound();
            }
            return View(candidats);
        }

        // POST: candidats/Edit/5
        // Pour vous protéger des attaques par survalidation, activez les propriétés spécifiques auxquelles vous souhaitez vous lier. Pour 
        // plus de détails, consultez https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "matricule,nom,prénom,mail,Téléphone,niveau,Expr,dernier_emp")] candidats candidats)
        {
            if (ModelState.IsValid)
            {
                db.Entry(candidats).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(candidats);
        }

        // GET: candidats/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            candidats candidats = db.candidats.Find(id);
            if (candidats == null)
            {
                return HttpNotFound();
            }
            return View(candidats);
        }

        // POST: candidats/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            candidats candidats = db.candidats.Find(id);
            db.candidats.Remove(candidats);
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
