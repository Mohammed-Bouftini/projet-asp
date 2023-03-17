using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using projet_asp.Data;
using projet_asp.Models;

namespace projet_asp.Controllers

{
  // [Authorize(Roles = "Directeur")]
    public class AccountsController : Controller
    {
        private projet_aspContext db = new projet_aspContext();
        [AllowAnonymous]

        // GET: logout
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home");
        }

        [AllowAnonymous]

        // GET: login
        public ActionResult Login()
        {
            return View();
        }
        [AllowAnonymous]
        [HttpPost]
        public ActionResult Login(Account log)
        {
            bool a = false;
            foreach (var item in db.Enseignants)
            {
                if (item.Email == log.Email && item.MotDePasse == log.Password)
                {
                    FormsAuthentication.SetAuthCookie(log.Email, false);
                    //  Session["pass"] = item.Id;
                    return RedirectToAction("Index", "Enseignants");
                }
                a = true;
            }

            foreach (var item in db.Admins)
            {
                if (item.Email == log.Email && item.MotDePasse == log.Password)//&& item.Isresp == true
                {
                    FormsAuthentication.SetAuthCookie(log.Email, false);
                    // Session["pass"] = item.Id;
                    return RedirectToAction("Index", "Admins");
                }
                a = true;
            }

            foreach (var item in db.Etudiants)
            {
                if (item.Email == log.Email && item.MotDePasse == log.Password && item.Validé == true)
                {
                    FormsAuthentication.SetAuthCookie(log.Email, false);
                    // Session["pass"] = item.Id;
                    return RedirectToAction("Index", "Etudiants");
                }
                else if (item.Email == log.Email && item.MotDePasse == log.Password && item.Validé == false)
                {
                    FormsAuthentication.SetAuthCookie(log.Email, false);
                    return RedirectToAction("Index_No_Validé", "Etudiants");
                }
                    a = true;
            }
            foreach (var item in db.Directeurs)
            {
                if (item.Email == log.Email && item.MotDePasse == log.Password)
                {
                    FormsAuthentication.SetAuthCookie(log.Email, false);
                    return RedirectToAction("Index", "Directeurs");
                }
                a = true;
            }
            if (a == true)
            {
                ViewBag.message = Resources.ModelsResources.Account.ResourceAccount.email_pwd;
            }
            return View();
        }
        // GET: Accounts
        public ActionResult Index()
        {
            return View(db.Accounts.ToList());
        }

        // GET: Accounts/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Account account = db.Accounts.Find(id);
            if (account == null)
            {
                return HttpNotFound();
            }
            return View(account);
        }

        // GET: Accounts/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Accounts/Create
        // Afin de déjouer les attaques par survalidation, activez les propriétés spécifiques auxquelles vous voulez établir une liaison. Pour 
        // plus de détails, consultez https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,UserName,Password,Role")] Account account)
        {
            if (ModelState.IsValid)
            {
                db.Accounts.Add(account);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(account);
        }

        // GET: Accounts/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Account account = db.Accounts.Find(id);
            if (account == null)
            {
                return HttpNotFound();
            }
            return View(account);
        }

        // POST: Accounts/Edit/5
        // Afin de déjouer les attaques par survalidation, activez les propriétés spécifiques auxquelles vous voulez établir une liaison. Pour 
        // plus de détails, consultez https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,UserName,Password,Role")] Account account)
        {
            if (ModelState.IsValid)
            {
                db.Entry(account).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(account);
        }

        // GET: Accounts/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Account account = db.Accounts.Find(id);
            if (account == null)
            {
                return HttpNotFound();
            }
            return View(account);
        }

        // POST: Accounts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Account account = db.Accounts.Find(id);
            db.Accounts.Remove(account);
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
            return RedirectToAction("Login");
        }

        public ActionResult CultureEn()
        {
            Resources.ModelsResources.Account.ResourceAccount.Culture = Resources.ModelsResources.Etudiant.ResourceEtudiant.Culture = Resources.MyResource.Culture = new System.Globalization.CultureInfo("en-US");
            return RedirectToAction("Login");
        }
        public ActionResult CultureAr()
        {
            Resources.ModelsResources.Account.ResourceAccount.Culture = Resources.ModelsResources.Etudiant.ResourceEtudiant.Culture = Resources.MyResource.Culture = new System.Globalization.CultureInfo("ar-MA");
            return RedirectToAction("Login");
        }
    }
}
