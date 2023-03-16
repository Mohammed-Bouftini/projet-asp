using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace projet_asp.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public ActionResult CultureFr()
        {
            Resources.ModelsResources.Account.ResourceAccount.Culture = Resources.MyResource.Culture = new System.Globalization.CultureInfo("fr-FR");
            return RedirectToAction("Index");
        }

        public ActionResult CultureEn()
        {
            Resources.ModelsResources.Account.ResourceAccount.Culture = Resources.MyResource.Culture = new System.Globalization.CultureInfo("en-US");
            return RedirectToAction("Index");
        }
        public ActionResult CultureAr()
        {
            Resources.ModelsResources.Account.ResourceAccount.Culture = Resources.MyResource.Culture = new System.Globalization.CultureInfo("ar-MA");
            return RedirectToAction("Index");
        }
    }
}