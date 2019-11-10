using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DiamondBank.Models.Entity;

namespace DiamondBank.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        DiamondBankEntities db = new DiamondBankEntities();
        public ActionResult Index()
        {
            var musteriler = db.TBLMusteri.ToList();
            return View(musteriler);
        }

        public ActionResult MusteriSil(int id)
        {
            var musteri = db.TBLMusteri.Find(id);
            db.TBLMusteri.Remove(musteri);
            db.SaveChanges();
            return RedirectToAction("Index", "Admin");
        }

        public ActionResult MusteriBilgileriniGetir(int id)
        {
            var mus = db.TBLMusteri.Find(id);
            return View("MusteriBilgileriniGetir", mus);
        }

        public ActionResult Guncelle(TBLMusteri m)
        {
            var musteri = db.TBLMusteri.Find(m.MusteriID);
            musteri.MusteriAdi = m.MusteriAdi;
            musteri.MusteriSoyadi = m.MusteriSoyadi;
            musteri.Cinsiyet = m.Cinsiyet;
            musteri.DogumTarihi = m.DogumTarihi;
            musteri.Sifre = m.Sifre;
            db.SaveChanges();
            return RedirectToAction("Index", "Admin");
        }
    }
}