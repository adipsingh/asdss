using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FRSS.Models
{
    public class UserAuthentication
    {
        [Required(ErrorMessage = "Please Enter UserName")]
        [Display(Name = "Username")]
        public string username { get; set; }

        [Required(ErrorMessage = "Please Enter Password")]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string userpwd { get; set; }

        [Required(ErrorMessage = "Please Enter Customer Id")]
        [Display(Name = "CustId")]
        public string custid { get; set; }

        public string userid { get; set; }

    }
}