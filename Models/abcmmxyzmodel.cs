using Business;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FRSS.Models
{
    public class abcmmxyzmodel
    {
        public abcmmxyzmodel()
        {
        }

        public abcmmxyzmodel(abcmmxyz objabc) : this()
        {
            ijyskqop = objabc.ijyskqop;
            padsrownr = objabc.padsrownr;
            sdgrexdtsgrg = objabc.sdgrexdtsgrg;
            rrggregdtgttd = objabc.rrggregdtgttd;
            ttdssdactubt = objabc.ttdssdactubt;
            uvadfdnusetbt = objabc.uvadfdnusetbt;
            vtggspnosg = objabc.vtggspnosg;
            hydfgshdnobb = objabc.hydfgshdnobb;
            fgewervrfkeysasf = objabc.fgewervrfkeysasf;
            agdfgcidrttr = objabc.agdfgcidrttr;
            id = objabc.id;
        }

        [Display(Name = "Serial key")]
        public string ijyskqop { get; set; }

        [Display(Name = "Register Owner Name")]
        public string padsrownr { get; set; }

        [Display(Name = "Expiry Date")]
        public string sdgrexdtsgrg { get; set; }

        [Display(Name = "Registration Date")]
        public string rrggregdtgttd { get; set; }

        [Display(Name = "Active User")]
        public string ttdssdactubt { get; set; }

        [Display(Name = "No Of user")]
        public string uvadfdnusetbt { get; set; }

        [Display(Name = "")]
        public string vtggspnosg { get; set; }

        [Display(Name = "HDD Serial No")]
        public string hydfgshdnobb { get; set; }

        [Display(Name = "Verification Key")]
        public string fgewervrfkeysasf { get; set; }

        [Display(Name = "Cust Id")]
        public string agdfgcidrttr { get; set; }

        [Display(Name = "Id")]
        public long id { get; set; }

    }
}