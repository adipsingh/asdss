using Business;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FRSS.Models
{
    public class compfinyearmodel
    {
        public compfinyearmodel()
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

        public compfinyearmodel(compfinyear objcompmstfinyear) : this()
        {
            compfinid = objcompmstfinyear.compfinid;
            compid = objcompmstfinyear.compid;
            finstart = objcompmstfinyear.finyrstart;
            finend = objcompmstfinyear.finyrend;
        }

        public compfinyearmodel(compfinyearmodel objcompmstfinyear) : this()
        {
            compfinid = objcompmstfinyear.compfinid;
            compcode = objcompmstfinyear.compcode;
            compname = objcompmstfinyear.compname;
            finyear = objcompmstfinyear.finyear;
        }


        [Display(Name = "Company Financial Year Id")]
        public string compfinid { get; set; }

        [Display(Name = "Company Code")]
        public string compcode { get; set; }

        [Required(ErrorMessage = "Select Company Name")]
        [Display(Name = "Company Name")]
        public string compid { get; set; }

        [Display(Name = "Company Name")]
        public string compname { get; set; }

        [Required(ErrorMessage = "Enter Financial Start Year")]
        [Display(Name = "Financial Start Year")]
        public string finstart { get; set; }

        [Required(ErrorMessage = "Enter Financial End Year")]
        [Display(Name = "Financial End Year")]
        public string finend { get; set; }

        [Display(Name = "Company Financial Year")]
        public string finyear { get; set; }

        public List<compfinyearmodel> ShowallCompFinYearMaster { get; set; }

        public List<SelectListItem> complist { get; set; }

    }
}