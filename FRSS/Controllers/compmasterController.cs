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
    public class compmasterController : Controller
    {
        public DataTable dtmainlist;

        [Authorize]
        public ActionResult ViewCompList()
        {
            try
            {
                ManageCompMaster compmst = new ManageCompMaster();
                ViewBag.CompList = compmst.compmastersList;

                return View();
            }
            catch
            {
                ViewBag.Error = "Sorry, Problem in getting Staff list";
            }
            return View();
        }

        [HttpGet]
        public ActionResult formcompmaster(string id = "")
        {
            compmastermodel objcom = new compmastermodel();
            ManageCompMaster compmst = new ManageCompMaster();


            if (Convert.ToString(id) != "")
            {
                compmaster compmast = compmst.GetCompMasterbyId(id, ProjectSession.custid);
                objcom = new compmastermodel(compmast);
            }
            else
            {
                ViewBag.CompList = compmst.compmastersList;
                var count = ViewBag.CompList.Count;

                if (Convert.ToInt32(count) >= Convert.ToInt32(ProjectSession.nocompactive))
                {
                    TempData["DangerMessage"] = "Can not create more company. Kindly contact your administrator.";
                    return RedirectToAction("ViewCompList");
                }
            }
            return View(objcom);
        }

        [HttpPost]
        public ActionResult formcompmaster(Models.compmastermodel compmst)
        {
            ManageCompMaster mngcompmst = new ManageCompMaster();

            if (ModelState.IsValid)
            {
                if (Convert.ToString(compmst.compid) == "")
                {
                    mngcompmst.AddNewEvent(compmst.compid, compmst.compid1, compmst.compcode, compmst.compname,
                        compmst.compaddr1, compmst.compaddr2, compmst.compaddr3, compmst.compcity, compmst.compzip, compmst.compstate,
                        compmst.compcontry, compmst.compstdcode, compmst.compphone, compmst.compmobile1, compmst.compmobile2, compmst.compweb,
                        compmst.compemail, compmst.compstatecode, compmst.compgstno, compmst.comppanno, 0, ProjectSession.custid, compmst.area,
                        compmst.tanno, compmst.regdate, compmst.regno, compmst.faxno);
                }
                else
                {
                    mngcompmst.UpdateEvent(compmst.compid, compmst.compid1, compmst.compcode, compmst.compname,
                        compmst.compaddr1, compmst.compaddr2, compmst.compaddr3, compmst.compcity, compmst.compzip, compmst.compstate,
                        compmst.compcontry, compmst.compstdcode, compmst.compphone, compmst.compmobile1, compmst.compmobile2, compmst.compweb,
                        compmst.compemail, compmst.compstatecode, compmst.compgstno, compmst.comppanno, 0, ProjectSession.custid, compmst.area,
                        compmst.tanno, compmst.regdate, compmst.regno, compmst.faxno);
                }
                return RedirectToAction("ViewCompList");
            }
            else
            {

                if (!ModelState.IsValid)
                {
                    var modelErrors = new List<string>();
                    foreach (var modelState in ModelState.Values)
                    {
                        foreach (var modelError in modelState.Errors)
                        {
                            modelErrors.Add(modelError.ErrorMessage);
                        }
                    }
                    // do something with the error list :)
                }

                ViewBag.Error = "Something .";
                TempData["DangerMessage"] = "Something wrong while save data.";
                return View(compmst);
            }
        }

        public DataTable ToDataTable<T>(List<T> items)
        {
            DataTable dataTable = new DataTable(typeof(T).Name);
            //Get all the properties by using reflection   
            PropertyInfo[] Props = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);
            foreach (PropertyInfo prop in Props)
            {
                //Setting column names as Property names  
                dataTable.Columns.Add(prop.Name);
            }
            foreach (T item in items)
            {
                var values = new object[Props.Length];
                for (int i = 0; i < Props.Length; i++)
                {

                    values[i] = Props[i].GetValue(item, null);
                }
                dataTable.Rows.Add(values);
            }

            return dataTable;
        }

        public ActionResult ExportToExcel(string formname)
        {
            //compmaster objcompmst = new compmaster();
            //compmasterdatalayer objcompdata = new compmasterdatalayer();

            //objcompmst.ShowallCompMaster = objcompdata.GetAllCompMasterData();

            //dtmainlist = ToDataTable(objcompmst.ShowallCompMaster);

            //var grid = new GridView();
            //grid.DataSource = dtmainlist;
            //grid.DataBind();

            //Response.ClearContent();
            //Response.Buffer = true;
            //Response.AddHeader("content-disposition", "attachment; filename=" + CommonMethod.ExcelFileName(formname) + "");
            //Response.ContentType = "application/ms-excel";

            //Response.Charset = "";
            //StringWriter sw = new StringWriter();
            //HtmlTextWriter htw = new HtmlTextWriter(sw);

            //grid.RenderControl(htw);

            //Response.Output.Write(sw.ToString());
            //Response.Flush();
            //Response.End();

            return RedirectToAction("CompMasterList");
        }

    }
}