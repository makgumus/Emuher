using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Emuher.Models;
using Emuher.DAL;
using System.Data.Entity;
using System.Net;
using PagedList;
using PagedList.Mvc;
using System.Globalization;

namespace Emuher.Controllers
{
    public class HomeController : Controller
    {
        private EmuherContext db = new EmuherContext();

        public ActionResult Index(string siralama = "Marka_Artan", int page = 1)
        {
            ViewBag.NameSortParameter = siralama == "Marka_Artan" ? "Marka_Azalan" : "Marka_Artan";
            ViewBag.DateSortParameter = siralama == "Fiyat_Artan" ? "Fiyat_Azalan" : "Fiyat_Artan";
            ViewBag.PageIndexParameter = page;
            ViewBag.SiralamaParameter = siralama;
            ViewBag.siralama = siralama;
            var Araba = from s in db.Araba.Include(s => s.Model)
                        select s;
            int pageIndex = page;
            var result = db.Araba.OrderBy(s => s.ArabaID).ToPagedList(pageIndex, 6);
            switch (siralama)
            {
                case "Marka_Artan":
                    ViewBag.SiralamaParameter = "Marka_Artan";
                    result = db.Araba.OrderBy(s => s.Model.Marka.MarkaAdi).ThenBy(s => s.Model.ModelAdi).ToPagedList(pageIndex, 6);
                    break;
                case "Marka_Azalan":
                    ViewBag.SiralamaParameter = "Marka_Azalan";
                    result = db.Araba.OrderByDescending(s => s.Model.Marka.MarkaAdi).ThenBy(s => s.Model.ModelAdi).ToPagedList(pageIndex, 6);
                    break;
                case "Fiyat_Artan":
                    ViewBag.SiralamaParameter = "Fiyat_Artan";
                    result = db.Araba.OrderBy(s => s.Fiyat).ToPagedList(pageIndex, 6);
                    break;
                case "Fiyat_Azalan":
                    ViewBag.SiralamaParameter = "Fiyat_Azalan";
                    result = db.Araba.OrderByDescending(s => s.Fiyat).ToPagedList(pageIndex, 6);
                    break;
                default:
                    result = db.Araba.OrderBy(s => s.Model.Marka.MarkaAdi).ThenBy(s => s.Model.ModelAdi).ToPagedList(pageIndex, 6);
                    break;
            }

            ViewBag.baslik = "EMUHER";
            ViewBag.baslik2 = Resources.lang.aracsatisplatformu;
            return View(result);
        }
        public ActionResult About()
        {
            ViewBag.baslik = "EMUHER";
            ViewBag.baslik2 = "Hakkımızda";
            ViewBag.Message = "Bu kısma resim, firma bilgileri, iletişim bilgileri filam girilcek";

            return View();
        }

        public ActionResult Plazas()
        {
            ViewBag.baslik = "EMUHER";
            ViewBag.baslik2 = "Plazalarımız";
            ViewBag.Message = "SANIRIM BU KISMI PLAZA MODELİYLE BİRLİKLE OLUŞTURULMAK KAYDIYLA BAŞTAN OLUŞTURCAZ GİBİ :s";
            var plaza = db.Plaza;
            return View(plaza.ToList());
        }
        public ActionResult Register()
        {
            ViewBag.baslik = "EMUHER";
            ViewBag.baslik2 = "Kaydol";
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register([Bind(Include = "MusteriID,Adsoy,KullaniciAdi,Sifre,Telefon,Email,Adres")] Musteri musteri)
        {
            if (ModelState.IsValid)
            {
                musteri.KayitTarihi = DateTime.Now;
                db.Musteri.Add(musteri);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(musteri);
        }
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login([Bind(Include = "KullaniciAdi,Sifre")]Musteri musteri)
        {
            if (ModelState.IsValid)
            {
                foreach(var item in Model.Musteri)
                {
                    if (musteri.KullaniciAdi =="erkan" && musteri.Sifre =="1234")
                    {
                        ViewBag.Mesaj = "Başarıyla giriş yaptınız sayın" + musteri.KullaniciAdi+" !!!";
                        return RedirectToAction("Login");
                    }
                    else
                    {

                    }

                }
                
            }
            return View();
        }
        [Authorize]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Araba araba = db.Araba.Find(id);
            if (araba == null)
            {
                return HttpNotFound();
            }
            return View(araba);
        }
        public ActionResult ChangeCulture(string lang, string returnUrl)
        {
            Session["Culture"] = new CultureInfo(lang);
            return Redirect(returnUrl);
        }
    }
}