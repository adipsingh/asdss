using Business;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FRSS.Models
{
    public class userchangepasswordmodel
    {

        public userchangepasswordmodel()
        {
        }

        public userchangepasswordmodel(usermaster objusermst) : this()
        {
            userid = objusermst.userid;
            username = objusermst.username;
        }

        public userchangepasswordmodel(userchangepasswordmodel objusermst) : this()
        {
            userid = objusermst.userid;
            username = objusermst.username;
        }

        [Display(Name = "User Id")]
        public string userid { get; set; }

        [Display(Name = "User Name")]
        [Required(ErrorMessage = "Enter User Name")]
        [RegularExpression(@"[a-zA-Z ]*$", ErrorMessage = "Use letters only please")]
        public string username { get; set; }

        [Display(Name = "New Password")]
        [Required(ErrorMessage = "Enter Password")]
        public string usernewpwd { get; set; }

        [Display(Name = "Re-Type Password")]
        [Required(ErrorMessage = "Enter Password")]
        [CompareAttribute("usernewpwd", ErrorMessage = "Password doesn't match.")]
        public string userretypepwd { get; set; }

    }
}