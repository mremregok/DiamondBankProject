using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DiamondBank.Models.Entity;

namespace DiamondBank.Controllers
{
    public class MusteriHesapListeleController : Controller
    {
        // GET: MusteriHesapListele
        DiamondBankEntities db = new DiamondBankEntities();
        public ActionResult HesapListele()
        {
            var temp = db.TBLHesap.ToList();

            List<TBLHesap> hesaplar = new List<TBLHesap>();

            foreach(var i in temp)
            {
                if (i.MusteriID == Convert.ToInt32(Session["Active User"]) && i.Aktiflik == true)
                    hesaplar.Add(i);
            }

            return View(hesaplar);
        }
    }
}