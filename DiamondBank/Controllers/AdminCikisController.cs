using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DiamondBank.Controllers
{
    public class AdminCikisController : Controller
    {
        // GET: AdminCikis
        public ActionResult AdminCikis()
        {
            return RedirectToAction("Index", "Home");
        }
    }
}