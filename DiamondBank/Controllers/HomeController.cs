using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DiamondBank.Models.Entity;

namespace DiamondBank.Controllers
{
    public class HomeController : Controller
    {
        DiamondBankEntities db = new DiamondBankEntities();

        public ActionResult Index()
        {

            return View();
        }

        [HttpPost]
        public ActionResult Index(TBLMusteri musteri)
        {
            try
            {
                var degerler = db.TBLMusteri.ToList();

                foreach(var m in degerler)
                {
                    if (musteri.TCNO == m.TCNO)
                    {
                        TempData["ID"] = m.MusteriID;
                        if(m.UyelikTipi.Trim() == "Admin")
                        {
                            return RedirectToAction("Index", "Admin");
                        }
                        else
                        {
                            return RedirectToAction("HesapIslemleri", "MusteriHesapEkle");
                        }
                    }
                }
            }
            catch
            {
                ViewBag.Hata = "Login olurken bir hata oluştu!";
            }
            return View();
        }

        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(TBLMusteri musteri)
        {
            musteri.UyelikTipi = "Musteri";
            musteri.KayitTarihi = DateTime.Now;
            musteri.VerilebilecekKrediMiktari = 0;

            var degerler = db.TBLMusteri.ToList();

            int sayac = 0;

            foreach (var m in degerler)
            {
                if (musteri.TCNO == m.TCNO)
                {
                    sayac++;
                }
            }

            if (sayac > 0)
            {
                TempData["Message"] = "Böyle bir üyelik zaten var.";
                return RedirectToAction("Index", "Home");
            }

            db.TBLMusteri.Add(musteri);

            db.SaveChanges();
            TempData["Message"] = "İşlem başarıyla tamamlandı.";
            return RedirectToAction("Index", "Home");
        }
    }
}