using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DiamondBank.Models.Entity;

namespace DiamondBank.Controllers
{
    public class MusteriHavaleController : Controller
    {
        // GET: MusteriHavale
        DiamondBankEntities db = new DiamondBankEntities();
        [HttpGet]
        public ActionResult HavaleYap()
        {
            return View();
        }
        [HttpPost]
        public ActionResult HavaleYap(int id, decimal miktar)
        {
            var hesap = db.TBLHesap.Find(Convert.ToInt32(Session["Active User"]));
            return View();
        }
    }
}