using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DiamondBank.Models.Entity;

namespace DiamondBank.Controllers
{
    public class MusteriHesapEkleController : Controller
    {
        // GET: MusteriHesapEkle
        DiamondBankEntities db = new DiamondBankEntities();
        public ActionResult HesapIslemleri()
        {
            
            if(Session["Active User"] == null)
            {
                var id = TempData["ID"];
                Session.Add("Active User", id);
            }

            var degerler = db.TBLMusteri.ToList();

            foreach (var m in degerler)
            {
                if (Session["Active User"].ToString() == m.MusteriID.ToString())
                {
                    Session["Username"] = m.MusteriAdi;
                }
            }


            return View();
        }

        [HttpGet]
        public ActionResult HesapEkle()
        {
            return View();
        }

        [HttpPost]
        public ActionResult HesapEkle(TBLHesap hesap)
        {
            if(hesap.MevduatMiktari > 10000)
            {
                ViewBag.Message = "Başlangıçta yatırabileceğiniz mevduat miktarını aştınız...";
                return View();
            }
            hesap.HesapAcilisTarihi = DateTime.Now;
            hesap.MusteriID = Convert.ToInt32(Session["Active User"]);
            hesap.Aktiflik = true;
            db.TBLHesap.Add(hesap);
            db.SaveChanges();
            ViewBag.Onay = "İşlem Tamamlandı!!!";
            return View();
        }

        public ActionResult BilgilerimiGetir()
        {
            var musteri = db.TBLMusteri.Find(Convert.ToInt32(Session["Active User"]));
            return View("BilgilerimiGetir", musteri);
        }

        public ActionResult Guncelle(TBLMusteri m)
        {
            m.MusteriID = Convert.ToInt32(Session["Active User"]);
            var musteri = db.TBLMusteri.Find(m.MusteriID);
            musteri.MusteriAdi = m.MusteriAdi;
            musteri.MusteriSoyadi = m.MusteriSoyadi;
            musteri.Cinsiyet = m.Cinsiyet;
            musteri.DogumTarihi = m.DogumTarihi;
            musteri.Sifre = m.Sifre;
            db.SaveChanges();
            return RedirectToAction("BilgilerimiGetir", "MusteriHesapEkle");
        }

        public ActionResult HesapSil(int id)
        {
            var hesap = db.TBLHesap.Find(id);
            db.TBLHesap.Remove(hesap);
            db.SaveChanges();
            return RedirectToAction("HesapListele", "MusteriHesapListele");
        }

        public ActionResult HesabaParaYatir(int id)
        {
            h.HesapID = C0,onvert.ToInt32(Session["Active User"]);
            var hesap = db.,TBLHesap.Find(h.HesapID);
            hesap.MevduatM,0i
                ktari += h.MevduatMiktari;
            db.SaveChanges();
            return View();
        }
    }
}

