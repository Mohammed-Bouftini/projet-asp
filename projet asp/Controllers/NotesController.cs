using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using projet_asp.Data;
using projet_asp.Models;

namespace projet_asp.Controllers
{
    public class NotesController : Controller
    {
        private projet_aspContext db = new projet_aspContext();

        // GET: Notes
        public ActionResult Index()
        {
            var notes = db.Notes.Include(n => n.Etudiant).Include(n => n.Matiere);
            return View(notes.ToList());
        }
        public ActionResult NoteEtudiant()
        {
            var notes = db.Notes.Include(n => n.Etudiant).Include(n => n.Matiere);
            return View(notes.ToList());
        }

        // GET: Notes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Note note = db.Notes.Find(id);
            if (note == null)
            {
                return HttpNotFound();
            }
            return View(note);
        }

        // GET: Notes/Create
        public ActionResult Create()
        {
            ViewBag.EtudiantId = new SelectList(db.Etudiants, "Id", "Nom");
            ViewBag.MatiereId = new SelectList(db.Matière, "Id", "matiere");
            return View();
        }

        // POST: Notes/Create
        // Afin de déjouer les attaques par survalidation, activez les propriétés spécifiques auxquelles vous voulez établir une liaison. Pour 
        // plus de détails, consultez https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,moyenne,MatiereId,EtudiantId")] Note note)
        {
            if (ModelState.IsValid)
            {
                db.Notes.Add(note);
                db.SaveChanges();
                return RedirectToAction("Index","Enseignants");
            }

            ViewBag.EtudiantId = new SelectList(db.Etudiants, "Id", "Nom", note.EtudiantId);
            ViewBag.MatiereId = new SelectList(db.Matière, "Id", "matiere", note.MatiereId);
            return View(note);
        }

        // GET: Notes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Note note = db.Notes.Find(id);
            if (note == null)
            {
                return HttpNotFound();
            }
            ViewBag.EtudiantId = new SelectList(db.Etudiants, "Id", "Nom", note.EtudiantId);
            ViewBag.MatiereId = new SelectList(db.Matière, "Id", "matiere", note.MatiereId);
            return View(note);
        }

        // POST: Notes/Edit/5
        // Afin de déjouer les attaques par survalidation, activez les propriétés spécifiques auxquelles vous voulez établir une liaison. Pour 
        // plus de détails, consultez https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,moyenne,MatiereId,EtudiantId")] Note note)
        {
            if (ModelState.IsValid)
            {
                db.Entry(note).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.EtudiantId = new SelectList(db.Etudiants, "Id", "Nom", note.EtudiantId);
            ViewBag.MatiereId = new SelectList(db.Matière, "Id", "matiere", note.MatiereId);
            return View(note);
        }

        // GET: Notes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Note note = db.Notes.Find(id);
            if (note == null)
            {
                return HttpNotFound();
            }
            return View(note);
        }

        // POST: Notes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Note note = db.Notes.Find(id);
            db.Notes.Remove(note);
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
        public ActionResult CultureFr()
        {
            Resources.ModelsResources.Account.ResourceAccount.Culture = Resources.ModelsResources.Etudiant.ResourceEtudiant.Culture = Resources.MyResource.Culture = new System.Globalization.CultureInfo("fr-FR");
            
            return RedirectToAction("Index");
        }

        public ActionResult CultureEn()
        {
            Resources.ModelsResources.Account.ResourceAccount.Culture = Resources.ModelsResources.Etudiant.ResourceEtudiant.Culture = Resources.MyResource.Culture = new System.Globalization.CultureInfo("en-US");
            return RedirectToAction("Index");
        }
        public ActionResult CultureAr()
        {
            Resources.ModelsResources.Account.ResourceAccount.Culture = Resources.ModelsResources.Etudiant.ResourceEtudiant.Culture = Resources.MyResource.Culture = new System.Globalization.CultureInfo("ar-MA");
            return RedirectToAction("Index");
        }
    }
}
