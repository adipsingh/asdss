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
    public class usermasterController : Controller
    {
        // GET: usermaster
        public ActionResult Index()
        {
            return View();
        }

        [Authorize]
        public ActionResult UserViewList()
        {
            try
            {
                ManageUserMaster usermaster = new ManageUserMaster();
                ViewBag.usermasterList = usermaster.ManageUserMasterList;

                return View();
            }
            catch (Exception ex)
            {
                ViewBag.Error = "Sorry, Problem in getting User Master list";
            }

            return View();
        }

        [Authorize]
        [HttpGet]
        public ActionResult formusermaster(string id = "")
        {
            usermastermodel objmodel = new usermastermodel();
            ManageUserMaster manageuser = new ManageUserMaster();

            if (id != "")
            {
                usermaster usermst = manageuser.GetUserbyId(id, ProjectSession.custid);
                objmodel = new usermastermodel(usermst);

                objmodel.addrightsview = false;
                objmodel.editrightsview = false;
                objmodel.deleterightsview = false;
                objmodel.downloadrightsview = false;
                objmodel.uploadrightsview = false;
                objmodel.sendmailrightsview = false;

                if(objmodel.addrights== true)
                {
                    objmodel.addrightsview = true;
                }

                if (objmodel.editrights == true)
                {
                    objmodel.editrightsview = true;
                }

                if (objmodel.deleterights == true)
                {
                    objmodel.deleterightsview = true;
                }

                if (objmodel.downloadrights == true)
                {
                    objmodel.downloadrightsview = true;
                }

                if (objmodel.uploadrights == true)
                {
                    objmodel.uploadrightsview = true;
                }

                if (objmodel.sendmailrights == true)
                {
                    objmodel.sendmailrightsview = true;
                }
            }

            return View(objmodel);
        }

        [Authorize]
        [HttpPost]
        public ActionResult formusermaster(usermastermodel model)
        {
            try
            {

                ManageUserMaster manageuser = new ManageUserMaster();
                string strRet = "Please check entered details. Something wrong with that";

                if (ModelState.IsValid)
                {
                    model.addrights = false;
                    model.editrights = false;
                    model.deleterights = false;
                    model.downloadrights = false;
                    model.uploadrights = false;
                    model.sendmailrights = false;

                    if (model.addrightsview == true)
                    {
                        model.addrights = true;
                    }

                    if (model.editrightsview == true)
                    {
                        model.editrights = true;
                    }

                    if (model.deleterightsview == true)
                    {
                        model.deleterights = true;
                    }

                    if (model.downloadrightsview == true)
                    {
                        model.downloadrights = true;
                    }

                    if (model.uploadrightsview == true)
                    {
                        model.uploadrights = true;
                    }

                    if (model.sendmailrightsview == true)
                    {
                        model.sendmailrights = true;
                    }

                    if (String.IsNullOrEmpty(model.userid) == true)
                    {
                        bool ret = manageuser.UserNameExist(model.username, ProjectSession.custid);

                        if (ret == false)
                        {
                            bool ret1 = manageuser.UserEmailExist(model.useremail, ProjectSession.custid);

                            if (ret1 == false)
                            {
                                model.userstatus = "Active";

                                manageuser.AddUpdateUserMaster(true, model.userid, model.username, model.userpwd, model.usermobile, model.useremail, model.userstatus, ProjectSession.custid, model.addrights, model.editrights, model.deleterights, model.uploadrights, model.downloadrights, model.sendmailrights);
                            }
                            else
                            {
                                ViewBag.Error = "Email Id already exists.";
                                return View(model);
                            }
                        }
                        else
                        {
                            ViewBag.Error = "User Name already exists.";
                            return View(model);
                        }
                    }
                    else
                    {
                        model.userstatus = "Active";

                        manageuser.AddUpdateUserMaster(true, model.userid, model.username, model.userpwd, model.usermobile, model.useremail, model.userstatus, ProjectSession.custid, model.addrights, model.editrights, model.deleterights, model.uploadrights, model.downloadrights, model.sendmailrights);
                    }
                    ModelState.Clear();
                    usermastermodel model1 = new usermastermodel();
                    return RedirectToAction("UserViewList");
                }
            }
            catch
            {
                //return View(model);
                ViewBag.Error = "Sorry,Detail is not inserted";
            }
            return View(model);
        }

        [HttpGet]
        public ActionResult UserChangePassword()
        {
            userchangepasswordmodel objmodel = new userchangepasswordmodel();
            ManageUserMaster manageuser = new ManageUserMaster();

            usermaster usermst = manageuser.GetUserbyId(ProjectSession.UserId, ProjectSession.custid);
            objmodel = new userchangepasswordmodel(usermst);

            return View(objmodel);
        }

        [Authorize]
        [HttpPost]
        public ActionResult UserChangePassword(userchangepasswordmodel model)
        {
            try
            {
                ManageUserMaster manageuser = new ManageUserMaster();

                if(ModelState.IsValid)
                {
                    manageuser.Changepassword(ProjectSession.UserId, model.usernewpwd, ProjectSession.custid);
                    ModelState.Clear();
                    usermastermodel model1 = new usermastermodel();
                    return RedirectToAction("UserViewList");
                }
            }
            catch
            {
                //return View(model);
                ViewBag.Error = "Sorry,Detail is not updated";
            }
            return View(model);
        }

    }
}