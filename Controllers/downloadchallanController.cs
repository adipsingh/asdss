using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Business;
using FRSS.Utility;
namespace FRSS.Controllers
{
    public class downloadchallanController : Controller
    {
        // GET: downloadchallan
        public ActionResult Index()
        {
            try
            {
                ChallanForm chanllan = new ChallanForm();                
                var challanList = chanllan.ChallanFormList;

                ViewBag.ChallanList = challanList;

                var date = DateTime.Now;
                var monthDay1 = date.Day;
                var yearDay = date.DayOfYear - 1;
                var dd =  (monthDay1 - 1);
                var monthDate = date.AddDays(-dd);
                var yearDate = date.AddDays(-yearDay);


                ViewBag.Month = date.ToString() + ' ' + monthDate.DayOfWeek;
                ViewBag.Year = date.ToString() + ' ' + yearDate.DayOfWeek;

                return View();
            }
            catch
            {
                ViewBag.Error = "Sorry, Problem in getting Bank MICR Code list";
            }
            return View();
        }

        [HttpGet]
        public FileResult DownLoadFile(int id)
        {
            ChallanForm challan = new ChallanForm();

            mstchallandown ObjFiles = new mstchallandown();

            var challanForm = challan.ChallanFormById(id);

            return File(challanForm.fileimage, "application/pdf", challanForm.filename);

        }
    }
}