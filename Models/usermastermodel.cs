using Business;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FRSS.Models
{
    public class usermastermodel
    {

        public usermastermodel()
        {
        }

        public usermastermodel(usermaster objusermst) : this()
        {
            userid = objusermst.userid;
            username = objusermst.username;
            userpwd = objusermst.userpwd;
            usermobile = objusermst.usermobile;
            useremail = objusermst.useremail;
            userstatus = objusermst.userstatus;
            addrights = objusermst.addrights;
            editrights = objusermst.editrights;
            deleterights = objusermst.deleterights;
            uploadrights = objusermst.uploadrights;
            downloadrights = objusermst.downloadrights;
            sendmailrights = objusermst.sendmailrights;
        }

        public usermastermodel(usermastermodel objusermst) : this()
        {
            userid = objusermst.userid;
            username = objusermst.username;
            usermobile = objusermst.usermobile;
            useremail = objusermst.useremail;
            userstatus = objusermst.userstatus;
        }

        [Display(Name = "User Id")]
        public string userid { get; set; }

        [Display(Name = "User Name")]
        [Required(ErrorMessage = "Enter User Name")]
        [RegularExpression(@"[a-zA-Z ]*$", ErrorMessage = "Use letters only please")]
        public string username { get; set; }

        [Display(Name = "User Password")]
        [Required(ErrorMessage = "Enter Password")]
        public string userpwd { get; set; }
        
        [Required(ErrorMessage = "Please Enter Mobile No")]
        [Display(Name = "Mobile No")]
        [StringLength(10, ErrorMessage = "The Mobile must contains 10 Digits", MinimumLength = 10)]
        public string usermobile { get; set; }

        [Required(ErrorMessage = "Please Enter Email Address")]
        [Display(Name = "Email Id")]
        [RegularExpression(@"^([a-zA-Z0-9_\.\-])+\@(([a-zA-Z0-9\-])+\.)+([a-zA-Z0-9]{2,4})+$",
        ErrorMessage = "Please Enter Correct Email Address")]
        public string useremail { get; set; }

        [Display(Name = "User Status")]
        public string userstatus { get; set; }

        [Display(Name = "Add Rights")]
        public bool? addrights { get; set; }
        public bool addrightsview { get; set; }

        [Display(Name = "Edit Rights")]
        public bool? editrights { get; set; }
        public bool editrightsview { get; set; }

        [Display(Name = "Delete Rights")]
        public bool? deleterights { get; set; }
        public bool deleterightsview { get; set; }

        [Display(Name = "Upload Rights")]
        public bool? uploadrights { get; set; }
        public bool uploadrightsview { get; set; }

        [Display(Name = "Download Rights")]
        public bool? downloadrights { get; set; }
        public bool downloadrightsview { get; set; }

        [Display(Name = "Send Email Rights")]
        public bool? sendmailrights { get; set; }
        public bool sendmailrightsview { get; set; }

        public List<usermastermodel> ShowallUserMaster { get; set; }

    }
}