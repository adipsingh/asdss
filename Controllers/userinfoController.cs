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
    public class userinfoController : Controller
    {
        // GET: userinfo
        public ActionResult Index()
        {
            return View();
        }

        [Authorize]
        [HttpGet]
        public ActionResult formuserinfo()
        {
            userinfomodel objmodel = new userinfomodel();
            ManageUserInfo manageuserinfo = new ManageUserInfo();

            userinfo usrinfo = manageuserinfo.GetUserInfoById(ProjectSession.custid);
            objmodel = new userinfomodel(usrinfo);

            return View(objmodel);
        }


        [Authorize]
        [HttpPost]
        public ActionResult formuserinfo(userinfomodel model)
        {
            try
            {
                ManageUserInfo manageuserinfo = new ManageUserInfo();
                string strRet = "Please check entered details. Something wrong with that";

                if (ModelState.IsValid)
                {
                    if (Convert.ToInt16(model.infoid) == 0)
                    {
                        manageuserinfo.AddUpdatemanageuserinfo(true, model.infoid, model.compcode, model.compname, model.compaddr1,model.compaddr2,model.compaddr3,model.compzip,model.compcity,model.compstate, model.compstatecode,model.compcontry,model.compstdcode,model.compphone,model.compmobile1,model.compmobile2,model.compemail,model.compweb,model.compgstno,model.comppanno,model.compdruglicno,ProjectSession.serialkey,ProjectSession.custid);
                    }
                    else
                    {
                        manageuserinfo.AddUpdatemanageuserinfo(false, model.infoid, model.compcode, model.compname, model.compaddr1, model.compaddr2, model.compaddr3, model.compzip, model.compcity, model.compstate, model.compstatecode, model.compcontry, model.compstdcode, model.compphone, model.compmobile1, model.compmobile2, model.compemail, model.compweb, model.compgstno, model.comppanno, model.compdruglicno, ProjectSession.serialkey, ProjectSession.custid);
                    }
                    ModelState.Clear();
                    userinfomodel model1 = new userinfomodel();
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