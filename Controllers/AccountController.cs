using Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using FRSS.Models;
using System.Text.RegularExpressions;
using System.Web;
using System.Collections.Generic;
using System.Threading.Tasks;
using FRSS.Utility;
//using FRSS.App_Code;

namespace FRSS.Controllers
{
    public class AccountController : Controller
    {
        public bool IsAuthenticated = false;

        public SigninManager SigninManager = new SigninManager();

        [AllowAnonymous]
        public ActionResult Login(UserAuthentication model)
        {
            return View(model);
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<ActionResult> Login(UserAuthentication model, string retUrl)
        {
            SigninStatus result = await SigninManager.SigninUserAsync(model.username, model.userpwd, model.custid);
            switch (result)
            {
                case SigninStatus.Success:
                    IsAuthenticated = true;
                    return DoAuthentication(model.custid, model.username, retUrl);
                    break;

                case SigninStatus.Undefine:
                    ViewBag.Error = "UserName or Password is not valid... Please Check";
                    break;

            }
            model.userpwd = string.Empty;
            return View(model);
        }

        [HttpPost]
        [AllowAnonymous]
        public ActionResult DoAuthentication(string custid, string userName, string returnUrl)
        {
            if (IsAuthenticated)
            {
                Session.Clear();
                FormsAuthentication.SetAuthCookie(userName, false);

                string userid = SigninManager.GetUserIdByUserName(userName);

                Manageabcmmxyz manageabc = new Manageabcmmxyz();

                abcmmxyz abc1 = manageabc.getabcmmxyz(CommonMethod.Encrypt(custid.ToUpper()));

                ProjectSession.serialkey = CommonMethod.Decrypt(abc1.ijyskqop);
                ProjectSession.registerowner = CommonMethod.Decrypt(abc1.padsrownr);
                ProjectSession.expirydate = CommonMethod.Decrypt(abc1.sdgrexdtsgrg);
                ProjectSession.nocompactive = CommonMethod.Decrypt(abc1.ttdssdactubt);

                ProjectSession.UserId = userid;
                ProjectSession.UserName = userName;
                ProjectSession.distcontactno = "+91-8000838147";
                ProjectSession.distemailid = "support@infinitybitsolution";
                ProjectSession.custid = custid;

                //Check Registration Validation

                DateTime expdate_1;
                DateTime curdate_1;

                //expdate_1 = Convert.ToDateTime(Convert.ToDateTime(ProjectSession.expirydate).ToString("dd/MM/yyyy"));
                //curdate_1 = Convert.ToDateTime(DateTime.Now.ToString("dd/MM/yyyy"));

                //if (expdate_1 < curdate_1)
                //{
                //    UserAuthentication model1 = new UserAuthentication();
                //    ViewBag.Error = "License is expired, Kindly contact your administrator.";
                //    return View(model1);
                //    //return RedirectToAction("Login");
                //}

                if (userid == "0")
                {
                    ProjectSession.addrights = true;
                    ProjectSession.editrights = true;
                    ProjectSession.deleterights = true;
                    ProjectSession.uploadrights = true;
                    ProjectSession.downloadrights = true;
                    ProjectSession.sendmailrights = true;
                }

                if (Url.IsLocalUrl(returnUrl) && returnUrl.Length > 1 && returnUrl.StartsWith("/")
            && !returnUrl.StartsWith("//") && !returnUrl.StartsWith("/\\"))
                {
                    return Redirect(returnUrl);
                }
                return RedirectToAction("AdminDashboard", "Home");
            }
            return RedirectToAction("Login");
        }

        [AllowAnonymous]
        public ActionResult Logout()
        {
            //AppHelper.LogOut();
            ProjectSession.UserId = "";
            ProjectSession.UserName = "";
            return RedirectToAction("Login");
        }

    }
}