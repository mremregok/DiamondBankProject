using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DiamondBank.Models.Entity;

namespace DiamondBank.Controllers
{
    public class AdminHesapController : Controller
    {
        // GET: AdminHesap
        DiamondBankEntities db = new DiamondBankEntities();
        public ActionResult Index()
        {
            var hesaplar = db.TBLHesap.ToList();
            return View(hesaplar);
        }

        public ActionResult HesapSil(int id)
        {
            var hesap = db.TBLHesap.Find(id);
            db.TBLHesap.Remove(hesap);
            db.SaveChanges();
            return RedirectToAction("Index", "Admin");
        }

        public ActionResult HesapBilgileriniGetir(int id)
        {
            var hesap = db.TBLHesap.Find(id);
            return View("HesapBilgileriniGetir", hesap);
        }

        public ActionResult HesapGuncelle(TBLHesap h)
        {
            var hesap = db.TBLHesap.Find(h.HesapID);
            hesap.HesapID = h.HesapID;
            hesap.MusteriID = h.MusteriID;
            hesap.HesapAcilisTarihi = h.HesapAcilisTarihi;
            hesap.Aktiflik = h.Aktiflik;
            hesap.MevduatMiktari = h.MevduatMiktari;
            db.SaveChanges();
            return RedirectToAction("Index", "AdminHesap");
        }
    }
}