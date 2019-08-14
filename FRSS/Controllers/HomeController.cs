using FRSS.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FRSS.Controllers
{
    [ProjectSessionActionFilter]
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult AdminDashboard()
        {
            ViewBag.totaldocs = "0";
            ViewBag.totainctaxdoc = "0";
            ViewBag.totagstdoc = "0";
            ViewBag.tottaxauditdoc = "0";

            return View();
        }
    }
}