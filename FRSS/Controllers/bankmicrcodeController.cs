using Business;
using FRSS.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FRSS.Controllers
{
    [ProjectSessionActionFilter]
    public class bankmicrcodeController : Controller
    {
        // GET: bankmicrcode
        public ActionResult Index()
        {
            return View();
        }

        [Authorize]
        public ActionResult ViewBankMicrCodeList()
        {
            try
            {
                ManageBankMICRCode bankmicrcode = new ManageBankMICRCode();
                var micrcodelist = bankmicrcode.ManageBankMICRCodeList;

                ViewBag.BankMICRCodeList = micrcodelist;

                return View();
            }
            catch
            {
                ViewBag.Error = "Sorry, Problem in getting Bank MICR Code list";
            }
            return View();
        }
    }
}