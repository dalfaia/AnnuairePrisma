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
    public class ContactsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Contacts
        public ActionResult Index()
        {
            var contact = db.Contact.Include(c => c.Societes);
            return View(contact.ToList());
        }

        // GET: Contacts/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Contacts contacts = db.Contact.Find(id);
            if (contacts == null)
            {
                return HttpNotFound();
            }
            return View(contacts);
        }

        // GET: Contacts/Create
        public ActionResult Create()
        {
            ViewBag.idSociete = new SelectList(db.Societe, "idSociete", "nom");
            return View();
        }

        // POST: Contacts/Create
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idContact,civilite,nom,prenom,fonction,telportable,tel,mail,idSociete")] Contacts contacts)
        {
            if (ModelState.IsValid)
            {
                db.Contact.Add(contacts);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idSociete = new SelectList(db.Societe, "idSociete", "nom", contacts.idSociete);
            return View(contacts);
        }

        // GET: Contacts/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Contacts contacts = db.Contact.Find(id);
            if (contacts == null)
            {
                return HttpNotFound();
            }
            ViewBag.idSociete = new SelectList(db.Societe, "idSociete", "nom", contacts.idSociete);
            return View(contacts);
        }

        // POST: Contacts/Edit/5
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idContact,civilite,nom,prenom,fonction,telportable,tel,mail,idSociete")] Contacts contacts)
        {
            if (ModelState.IsValid)
            {
                db.Entry(contacts).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idSociete = new SelectList(db.Societe, "idSociete", "nom", contacts.idSociete);
            return View(contacts);
        }

        // GET: Contacts/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Contacts contacts = db.Contact.Find(id);
            if (contacts == null)
            {
                return HttpNotFound();
            }
            return View(contacts);
        }

        // POST: Contacts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Contacts contacts = db.Contact.Find(id);
            db.Contact.Remove(contacts);
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

        // GET: Liste contacts
        public ActionResult Liste(int idSociete)
        {
            var contact = db.Contact.Where(c => c.idSociete == idSociete);
            return View(contact.ToList());
        }
    }
}
