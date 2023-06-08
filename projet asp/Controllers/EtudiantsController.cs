using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using projet_asp.Data;
using projet_asp.Models;

namespace projet_asp.Controllers
{
    public class EtudiantsController : Controller
    {
        private projet_aspContext db = new projet_aspContext();

        // GET: Etudiants
        public ActionResult Index()
        {
            return View(db.Etudiants.ToList());
        }
        public ActionResult Recher(string searchQuery)
        {
            var etudiants = db.Etudiants
                .Where(e => e.Nom.Contains(searchQuery))
                .ToList();

            return View("Validé", etudiants);
        }
        public ActionResult Rechercher(string searchQuery)
        {
            var etudiants = db.Etudiants
                .Where(e => e.Nom.Contains(searchQuery))
                .ToList();

            return View("No_Validé", etudiants);
        }

        public ActionResult No_Validé()
        {
            return View(db.Etudiants.ToList());
        }
        public ActionResult Index_No_Validé()
        {
            return View(db.Etudiants.ToList());
        }
        public ActionResult Validé()
        {
            return View(db.Etudiants.ToList());
        }
        public ActionResult ValidationCompte()
        {
            return View();
        }
        public ActionResult Profil(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Etudiant etudiant = db.Etudiants.Find(id);
            if (etudiant == null)
            {
                return HttpNotFound();
            }
            return View(etudiant);
        }
        // GET: Etudiants/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Etudiant etudiant = db.Etudiants.Find(id);
            if (etudiant == null)
            {
                return HttpNotFound();
            }
            return View(etudiant);
        }
        public ActionResult Detail(int? id)
        {
            int test = db.Database
                .ExecuteSqlCommand("Update Etudiants set Validé='1' where Id=@id", new SqlParameter("@id", id));
            return RedirectToAction("No_Validé", "Etudiants");
        }
        public ActionResult NoDetail(int? id)
        {
            int test = db.Database
                .ExecuteSqlCommand("Update Etudiants set Validé='0' where Id=@id", new SqlParameter("@id", id));
            return RedirectToAction("Validé", "Etudiants");
        }

        // GET: Etudiants/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Etudiants/Create
        // Pour vous protéger des attaques par survalidation, activez les propriétés spécifiques auxquelles vous souhaitez vous lier. Pour 
        // plus de détails, consultez https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Nom,Prenom,Adress,Tel,Email,MotDePasse,Role,Validé")] Etudiant etudiant)
        {
            if (ModelState.IsValid)
            {
                etudiant.SectionId = null;
                db.Etudiants.Add(etudiant);
                db.SaveChanges();
                return RedirectToAction("ValidationCompte");
            }

            return View(etudiant);
        }
        public ActionResult EditProfil(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Etudiant etudiant = db.Etudiants.Find(id);
            if (etudiant == null)
            {
                return HttpNotFound();
            }
            return View(etudiant);
        }
        public ActionResult EditProfil([Bind(Include = "Id,Nom,Prenom,Adress,Tel,Email,MotDePasse,Role,Validé")] Etudiant etudiant)
        {
            if (ModelState.IsValid)
            {
                db.Entry(etudiant).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(etudiant);
        }

        // GET: Etudiants/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Etudiant etudiant = db.Etudiants.Find(id);
            if (etudiant == null)
            {
                return HttpNotFound();
            }
            return View(etudiant);
        }

        // POST: Etudiants/Edit/5
        // Pour vous protéger des attaques par survalidation, activez les propriétés spécifiques auxquelles vous souhaitez vous lier. Pour 
        // plus de détails, consultez https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Nom,Prenom,Adress,Tel,Email,MotDePasse,Role,Validé")] Etudiant etudiant)
        {
            if (ModelState.IsValid)
            {
                db.Entry(etudiant).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(etudiant);
        }
        public ActionResult Dlt(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Etudiant etudiant = db.Etudiants.Find(id);
            if (etudiant == null)
            {
                return HttpNotFound();
            }
            return View(etudiant);
        }
        // GET: Etudiants/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Etudiant etudiant = db.Etudiants.Find(id);
            if (etudiant == null)
            {
                return HttpNotFound();
            }
            return View(etudiant);
        }

        // POST: Etudiants/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Etudiant etudiant = db.Etudiants.Find(id);
            db.Etudiants.Remove(etudiant);
            db.SaveChanges();
            return RedirectToAction("No_Validé");
        }
        [HttpPost, ActionName("Dlt")]
        [ValidateAntiForgeryToken]
        public ActionResult DltConfirmed(int id)
        {
            Etudiant etudiant = db.Etudiants.Find(id);
            db.Etudiants.Remove(etudiant);
            db.SaveChanges();
            return RedirectToAction("Validé");
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
            Resources.ModelsResources.Account.ResourceAccount.Culture = Resources.ModelsResources.Admin.ResourceAdmin.Culture = Resources.ModelsResources.Etudiant.ResourceEtudiant.Culture = Resources.MyResource.Culture = new System.Globalization.CultureInfo("fr-FR");
           
                foreach (var item in db.Etudiants)
                {
                if (User.Identity.IsAuthenticated)
                {
                    if (User.Identity.Name == item.Email == item.Validé == false)
                    {
                        return RedirectToAction("Index_No_Validé", "Etudiants");
                    }
                    else if (User.Identity.Name == item.Email == item.Validé == true)
                    {
                        return RedirectToAction("Index", "Etudiants");
                    }

                }

            }
            return RedirectToAction( "Create", "Etudiants");
        }

                public ActionResult CultureEn()
                {
                    Resources.ModelsResources.Account.ResourceAccount.Culture = Resources.MyResource.Culture = Resources.ModelsResources.Admin.ResourceAdmin.Culture = Resources.ModelsResources.Etudiant.ResourceEtudiant.Culture = new System.Globalization.CultureInfo("en-US");
            if (User.Identity.IsAuthenticated)
            {
                foreach (var item in db.Etudiants)
                {
                    if (User.Identity.IsAuthenticated)
                    {
                        if (User.Identity.Name == item.Email == item.Validé == false)
                        {
                            return RedirectToAction("Index_No_Validé", "Etudiants");
                        }
                        else if (User.Identity.Name == item.Email == item.Validé == true)
                        {
                            return RedirectToAction("Index", "Etudiants");
                        }

                    }

                }
            }
            return RedirectToAction("Create", "Etudiants");
        
          
                }
                public ActionResult CultureAr()
                {
                    Resources.ModelsResources.Account.ResourceAccount.Culture=Resources.ModelsResources.Admin.ResourceAdmin.Culture = Resources.MyResource.Culture=Resources.ModelsResources.Etudiant.ResourceEtudiant.Culture = new System.Globalization.CultureInfo("ar-MA");
            foreach (var item in db.Etudiants)
            {
                if (User.Identity.IsAuthenticated)
                {
                    if (User.Identity.Name == item.Email == item.Validé == false)
                    {
                        return RedirectToAction("Index_No_Validé", "Etudiants");
                    }
                    else if (User.Identity.Name == item.Email == item.Validé == true)
                    {
                        return RedirectToAction("Index", "Etudiants");
                    }

                }

            }
            return RedirectToAction("Create", "Etudiants");
            }
            }

}
