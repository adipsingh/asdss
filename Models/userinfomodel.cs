using Business;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FRSS.Models
{
    public class userinfomodel
    {
        public userinfomodel()
        {

        }

        public userinfomodel(userinfo objuserinfo) : this()
        {
            infoid = objuserinfo.infoid;
            compcode = objuserinfo.compcode;
            compname = objuserinfo.compname;
            compaddr1 = objuserinfo.compaddr1;
            compaddr2 = objuserinfo.compaddr2;
            compaddr3 = objuserinfo.compaddr3;
            compzip = objuserinfo.compzip;
            compcity = objuserinfo.compcity;
            compstate = objuserinfo.compstate;
            compstatecode = objuserinfo.compstatecode;
            compcontry = objuserinfo.compcontry;
            compstdcode = objuserinfo.compstdcode;
            compphone = objuserinfo.compphone;
            compmobile1 = objuserinfo.compmobile1;
            compmobile2 = objuserinfo.compmobile2;
            compemail = objuserinfo.compemail;
            compweb = objuserinfo.compweb;
            compgstno = objuserinfo.compgstno;
            comppanno = objuserinfo.comppanno;
            compdruglicno = objuserinfo.compdruglicno;
            compserialkey = objuserinfo.compserialkey;
        }

        public long? infoid { get; set; }
        public string compcode { get; set; }
        public string compname { get; set; }
        public string compaddr1 { get; set; }
        public string compaddr2 { get; set; }
        public string compaddr3 { get; set; }
        public long? compzip { get; set; }
        public string compcity { get; set; }
        public string compstate { get; set; }
        public long? compstatecode { get; set; }
        public string compcontry { get; set; }
        public long? compstdcode { get; set; }
        public long? compphone { get; set; }
        public long? compmobile1 { get; set; }
        public long? compmobile2 { get; set; }

        [Required(ErrorMessage = "Please Enter Email Address")]
        [RegularExpression(@"^([a-zA-Z0-9_\.\-])+\@(([a-zA-Z0-9\-])+\.)+([a-zA-Z0-9]{2,4})+$",
        ErrorMessage = "Please Enter Correct Email Address")]
        [Display(Name = "Email Id")]
        public string compemail { get; set; }
        public string compweb { get; set; }
        public string compgstno { get; set; }
        public string comppanno { get; set; }
        public string compdruglicno { get; set; }
        public string compserialkey { get; set; }

    }
}