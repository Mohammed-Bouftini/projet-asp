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
    public class MatièreController : Controller
    {
        private projet_aspContext db = new projet_aspContext();

        // GET: Matière
        public ActionResult Index()
        {
            var matière = db.Matière.Include(m => m.Enseignant);
            return View(matière.ToList());
        }

        // GET: Matière/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Matière matière = db.Matière.Find(id);
            if (matière == null)
            {
                return HttpNotFound();
            }
            return View(matière);
        }

        // GET: Matière/Create
        public ActionResult Create()
        {
            ViewBag.EnseignantId = new SelectList(db.Enseignants, "Id", "Nom");
            return View();
        }

        // POST: Matière/Create
        // Afin de déjouer les attaques par survalidation, activez les propriétés spécifiques auxquelles vous voulez établir une liaison. Pour 
        // plus de détails, consultez https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,matiere,EnseignantId")] Matière matière)
        {
            if (ModelState.IsValid)
            {
                db.Matière.Add(matière);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.EnseignantId = new SelectList(db.Enseignants, "Id", "Nom", matière.EnseignantId);
            return View(matière);
        }

        // GET: Matière/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Matière matière = db.Matière.Find(id);
            if (matière == null)
            {
                return HttpNotFound();
            }
            ViewBag.EnseignantId = new SelectList(db.Enseignants, "Id", "Nom", matière.EnseignantId);
            return View(matière);
        }

        // POST: Matière/Edit/5
        // Afin de déjouer les attaques par survalidation, activez les propriétés spécifiques auxquelles vous voulez établir une liaison. Pour 
        // plus de détails, consultez https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,matiere,EnseignantId")] Matière matière)
        {
            if (ModelState.IsValid)
            {
                db.Entry(matière).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.EnseignantId = new SelectList(db.Enseignants, "Id", "Nom", matière.EnseignantId);
            return View(matière);
        }

        // GET: Matière/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Matière matière = db.Matière.Find(id);
            if (matière == null)
            {
                return HttpNotFound();
            }
            return View(matière);
        }

        // POST: Matière/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Matière matière = db.Matière.Find(id);
            db.Matière.Remove(matière);
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
            return RedirectToAction("Create");
        }

        public ActionResult CultureEn()
        {
            Resources.ModelsResources.Account.ResourceAccount.Culture = Resources.ModelsResources.Etudiant.ResourceEtudiant.Culture = Resources.MyResource.Culture = new System.Globalization.CultureInfo("en-US");
            return RedirectToAction("Create");
        }
        public ActionResult CultureAr()
        {
            Resources.ModelsResources.Account.ResourceAccount.Culture = Resources.ModelsResources.Etudiant.ResourceEtudiant.Culture = Resources.MyResource.Culture = new System.Globalization.CultureInfo("ar-MA");
            return RedirectToAction("Create");
        }
    }
}
