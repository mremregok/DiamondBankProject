using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DiamondBank.Controllers
{
    public class MusteriCikisController : Controller
    {
        // GET: MusteriCikis
        public ActionResult Logout()
        {
            Session.Remove("Active User");
            Session.Clear();
            return RedirectToAction("Index", "Home");
        }
    }
}