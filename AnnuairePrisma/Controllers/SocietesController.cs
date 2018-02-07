using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AnnuairePrisma.Models;

namespace AnnuairePrisma.Controllers
{
    public class SocietesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Societes
        public ActionResult Index()
        {
            return View(db.Societe.ToList());
        }

        // GET: Societes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Societes societes = db.Societe.Find(id);
            if (societes == null)
            {
                return HttpNotFound();
            }
            return View(societes);
        }

        // GET: Societes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Societes/Create
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,nom,raisonSociale,adresse1,adresse2,codePostal,ville,standard")] Societes societes)
        {
            if (ModelState.IsValid)
            {
                db.Societe.Add(societes);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(societes);
        }

        // GET: Societes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Societes societes = db.Societe.Find(id);
            if (societes == null)
            {
                return HttpNotFound();
            }
            return View(societes);
        }

        // POST: Societes/Edit/5
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,nom,raisonSociale,adresse1,adresse2,codePostal,ville,standard")] Societes societes)
        {
            if (ModelState.IsValid)
            {
                db.Entry(societes).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(societes);
        }

        // GET: Societes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Societes societes = db.Societe.Find(id);
            if (societes == null)
            {
                return HttpNotFound();
            }
            return View(societes);
        }

        // POST: Societes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Societes societes = db.Societe.Find(id);
            db.Societe.Remove(societes);
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
