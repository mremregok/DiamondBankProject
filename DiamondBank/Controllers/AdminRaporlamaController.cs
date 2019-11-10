using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DiamondBank.Models.Entity;

namespace DiamondBank.Controllers
{
    public class AdminRaporlamaController : Controller
    {
        // GET: AdminRaporlama
        DiamondBankEntities db = new DiamondBankEntities();
        public ActionResult Index()
        {
            var rapor = db.TBLRaporlama.ToList();
            return View(rapor);
        }
    }
}