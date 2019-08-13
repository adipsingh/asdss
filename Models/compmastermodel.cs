using Business;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FRSS.Models
{

    public class compmastermodel
    {
        public compmastermodel()
        {
            #region Drop down in company view

            GlobalData globalData = new GlobalData();
            complist = globalData.CompanyList.Select(p => new SelectListItem
            {
                Text = p.compname,
                Value = p.compid.ToString()
            }).ToList();

            #endregion
        }

        public compmastermodel(compmaster objcompmst) : this()
        {
            compid = objcompmst.compid;
            compcode = objcompmst.compcode;
            compname = objcompmst.compname;
            compaddr1 = objcompmst.compaddr1;
            compaddr2 = objcompmst.compaddr2;
            compaddr3 = objcompmst.compaddr3;
            compcity = objcompmst.compcity;
            compzip = objcompmst.compzip;
            compstate = objcompmst.compstate;
            compcontry = objcompmst.compcontry;
            compstdcode = objcompmst.compstdcode;
            compphone = objcompmst.compphone;
            compmobile1 = objcompmst.compmobile1;
            compmobile2 = objcompmst.compmobile2;
            compweb = objcompmst.compweb;
            compemail = objcompmst.compemail;
            compstatecode = objcompmst.compstatecode;
            compgstno = objcompmst.compgstno;
            comppanno = objcompmst.comppanno;
            area = objcompmst.area;
            tanno = objcompmst.tanno;
            regdate = objcompmst.regdate;
            regno = objcompmst.regno;
            faxno = objcompmst.faxno;
        }

        public compmastermodel(compmastermodel objcompmst) : this()
        {
            compid = objcompmst.compid;
            compcode = objcompmst.compcode;
            compname = objcompmst.compname;
            compcity = objcompmst.compcity;
            compstate = objcompmst.compstate;
            compmobile1 = objcompmst.compmobile1;
            compemail = objcompmst.compemail;
            compweb = objcompmst.compweb;
        }

        public string compid { get; set; }
        public long compid1 { get; set; }

        [Required(ErrorMessage = "Enter Company Code")]
        [Display(Name = "Company Code")]
        public string compcode { get; set; }

        [Required(ErrorMessage = "Enter Company Name")]
        [Display(Name = "Company Name")]
        [RegularExpression(@"[a-zA-Z ]*$", ErrorMessage = "Use letters only please")]
        public string compname { get; set; }

        public string compaddr1 { get; set; }
        public string compaddr2 { get; set; }
        public string compaddr3 { get; set; }

        [Display(Name = "City Name")]
        public string compcity { get; set; }

        //[RegularExpression("^[0-9]", ErrorMessage = "Value must be numeric.")]
        public long? compzip { get; set; }

        [Display(Name = "State Name")]
        public string compstate { get; set; }
        public string compcontry { get; set; }
        //[RegularExpression("^[0-9]", ErrorMessage = "Value must be numeric.")]
        public long? compstdcode { get; set; }

        //[RegularExpression("^[0-9]", ErrorMessage = "Value must be numeric.")]
        public long? compphone { get; set; }

        //[RegularExpression("^[0-9]", ErrorMessage = "Value must be numeric.")]

        [Display(Name = "Mobile No")]
        public long? compmobile1 { get; set; }

        //[RegularExpression("^[0-9]", ErrorMessage = "Value must be numeric.")]
        public long? compmobile2 { get; set; }

        [Display(Name = "Web Address")]
        public string compweb { get; set; }

        [Required(ErrorMessage = "Please Enter Email Address")]
        [RegularExpression(@"^([a-zA-Z0-9_\.\-])+\@(([a-zA-Z0-9\-])+\.)+([a-zA-Z0-9]{2,4})+$",
        ErrorMessage = "Please Enter Correct Email Address")]
        [Display(Name = "Email Id")]
        public string compemail { get; set; }

        //[RegularExpression("^[0-9]", ErrorMessage = "Value must be numeric.")]
        public long? compstatecode { get; set; }
        public string compgstno { get; set; }
        public string comppanno { get; set; }
        public string custid { get; set; }
        public string area { get; set; }
        public string tanno { get; set; }

        [DataType(DataType.Date)]
        public DateTime? regdate { get; set; }

        public string regno { get; set; }
        public long? faxno { get; set; }

        public List<compmastermodel> ShowallCompMaster { get; set; }
        public List<SelectListItem> complist { get; set; }

    }
}