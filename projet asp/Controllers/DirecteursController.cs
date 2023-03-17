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
    public class DirecteursController : Controller
    {
        private projet_aspContext db = new projet_aspContext();

        // GET: Directeurs
        public ActionResult Index()
        {
            return View(db.Directeurs.ToList());
        }

        // GET: Directeurs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Directeur directeur = db.Directeurs.Find(id);
            if (directeur == null)
            {
                return HttpNotFound();
            }
            return View(directeur);
        }

        // GET: Directeurs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Directeurs/Create
        // Afin de déjouer les attaques par survalidation, activez les propriétés spécifiques auxquelles vous voulez établir une liaison. Pour 
        // plus de détails, consultez https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Nom,Prenom,Email,MotDePasse,Role")] Directeur directeur)
        {
            if (ModelState.IsValid)
            {
                db.Directeurs.Add(directeur);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(directeur);
        }

        // GET: Directeurs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Directeur directeur = db.Directeurs.Find(id);
            if (directeur == null)
            {
                return HttpNotFound();
            }
            return View(directeur);
        }

        // POST: Directeurs/Edit/5
        // Afin de déjouer les attaques par survalidation, activez les propriétés spécifiques auxquelles vous voulez établir une liaison. Pour 
        // plus de détails, consultez https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Nom,Prenom,Email,MotDePasse,Role")] Directeur directeur)
        {
            if (ModelState.IsValid)
            {
                db.Entry(directeur).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(directeur);
        }

        // GET: Directeurs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Directeur directeur = db.Directeurs.Find(id);
            if (directeur == null)
            {
                return HttpNotFound();
            }
            return View(directeur);
        }

        // POST: Directeurs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Directeur directeur = db.Directeurs.Find(id);
            db.Directeurs.Remove(directeur);
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
        public ActionResult ListeCompte()
        {
            return View(db.Directeurs.ToList());
        }
        public ActionResult CultureFr()
        {
            Resources.ModelsResources.Account.ResourceAccount.Culture = Resources.ModelsResources.Admin.ResourceAdmin.Culture = Resources.ModelsResources.Etudiant.ResourceEtudiant.Culture = Resources.MyResource.Culture = new System.Globalization.CultureInfo("fr-FR");
            return RedirectToAction("Index");
        }

        public ActionResult CultureEn()
        {
            Resources.ModelsResources.Account.ResourceAccount.Culture = Resources.ModelsResources.Admin.ResourceAdmin.Culture = Resources.ModelsResources.Etudiant.ResourceEtudiant.Culture = Resources.MyResource.Culture = new System.Globalization.CultureInfo("en-US");
            return RedirectToAction("Index");
        }
        public ActionResult CultureAr()
        {
            Resources.ModelsResources.Account.ResourceAccount.Culture = Resources.ModelsResources.Admin.ResourceAdmin.Culture = Resources.ModelsResources.Etudiant.ResourceEtudiant.Culture = Resources.MyResource.Culture = new System.Globalization.CultureInfo("ar-MA");
            return RedirectToAction("Index");
        }
    }
}
