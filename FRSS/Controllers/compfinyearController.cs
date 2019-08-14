using Business;
using FRSS.DataAccessLayer;
using FRSS.Models;
using FRSS.Utility;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FRSS.Controllers
{
    [ProjectSessionActionFilter]
    public class compfinyearController : Controller
    {
        // GET: compfinyear
        public ActionResult Index()
        {
            return View();
        }

        [Authorize]
        public ActionResult ViewCompFinYearList()
        {
            try
            {
                ManageCompFinYear compfinyear = new ManageCompFinYear();
                ViewBag.CompFinYearList = compfinyear.ManageCompFinYearList;

                return View();
            }
            catch
            {
                ViewBag.Error = "Sorry, Problem in getting Company Financial Year list";
            }
            return View();
        }

        [Authorize]
        [HttpGet]
        public ActionResult formcompfinyear(string id = "")
        {
            compfinyearmodel objmodel = new compfinyearmodel();
            ManageCompFinYear managecompfinyr = new ManageCompFinYear();

            if (id != "")
            {
                compfinyear compfinyr = managecompfinyr.GetFinYearbyId(id, ProjectSession.custid);
                objmodel = new compfinyearmodel(compfinyr);
            }

            return View(objmodel);
        }

        [Authorize]
        [HttpPost]
        public ActionResult formcompfinyear(compfinyearmodel model)
        {
            try
            {
                ManageCompFinYear compfinyear = new ManageCompFinYear();
                string strRet = "Please check entered details. Something wrong with that";

                if (ModelState.IsValid)
                {
                    if (String.IsNullOrEmpty(model.compfinid) == true)
                    {
                        bool ret = compfinyear.GetFinYearByCompYear(model.compid, model.finstart, model.finend, ProjectSession.custid);

                        if (ret == false)
                        {
                            compfinyear.AddUpdateCompfinYear(true, model.compfinid, model.compid, model.finstart, model.finend, ProjectSession.custid, ProjectSession.UserId);
                        }
                        else
                        {
                            ViewBag.Error = "Financial Year already created for company.";
                            return View(model);
                        }
                    }
                    else
                    {
                        compfinyear.AddUpdateCompfinYear(false, model.compfinid, model.compid, model.finstart, model.finend, ProjectSession.custid, ProjectSession.UserId);
                    }
                    ModelState.Clear();
                    compfinyearmodel model1 = new compfinyearmodel();
                    return View(model1);
                }
            }
            catch
            {
                //return View(model);
                ViewBag.Error = "Sorry,Detail is not inserted";
            }
            return View(model);
        }
    }
}