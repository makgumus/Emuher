using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Emuher.DAL;
using System.Globalization;

namespace Emuher.Areas.Admin.Controllers
{
    public class HomeController : Controller
    {
        private EmuherContext db = new EmuherContext();

        [UserAuthorize]
        public ActionResult Index()
        {
            ViewBag.aktif0="active-menu";
            return View();
        }
        public ActionResult Login()
        {
            return View();
        }

        public bool CheckLogin(string userName, string passWord)
        {
            return db.Admin.Any(x => x.KullaniciAdi == userName && x.Sifre == passWord);
        }

        [HttpPost]
        public ActionResult Login(string userName, string passWord)
        {
            if (!CheckLogin(userName, passWord) || (userName == "" || passWord == ""))
            {
                ModelState.AddModelError("UserWrong", "Yanlış kullanıcı/şifre");
                return View();
            }
            FormsAuthentication.SetAuthCookie(userName, true);
            var userCookie = new HttpCookie("User") { Value = userName, Expires = DateTime.Now.AddYears(1) };
            Response.Cookies.Add(userCookie);
            return RedirectToAction("/Index");
        }
        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            var httpCookie = Response.Cookies["User"];
            httpCookie.Expires = DateTime.Now.AddMilliseconds(-1);
            return RedirectToAction("Login");
        }
        public ActionResult ChangeCulture(string lang, string returnUrl)
        {
            Session["Culture"] = new CultureInfo(lang);
            return Redirect(returnUrl);
        }
    }
}