using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FRSS.Models
{
    public class fileManagerAdd
    {
        public string fileid { get; set; }

        [Display(Name = "Company Name")]
        public string compid { get; set; }

        [Display(Name = "Financial Year Id")]
        [Required(ErrorMessage = "Select Financial Year")]
        public string compfinid { get; set; }

        [Display(Name = "Category Id")]
        [Required(ErrorMessage = "Select File Category")]
        public string filecatid { get; set; }

        [Display(Name = "Sub Category Id")]
        public string filesubcatid { get; set; }

        [Display(Name = "File Title")]
        [Required(ErrorMessage = "Enter File Title")]
        public string filetitle { get; set; }

        [Display(Name = "File Manager Date")]
        public DateTime? filedate { get; set; }

        [Display(Name = "Uploaded Date")]
        public DateTime uploadeddate { get; set; }

        [Display(Name = "File Description")]
        public string filedescr { get; set; } 
        public string filedtlid { get; set; }
        [Display(Name = "File")]
        [Required(ErrorMessage = "Select File")]
        public byte[] fileimageSaved { get; set; }
        public string filetype { get; set; }
        public string filename { get; set; }

    }
}