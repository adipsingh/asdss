using Business;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FRSS.Models
{
    public class filemanagermodel
    {
        public filemanagermodel()
        {
            #region Drop down in company view

            GlobalData globalData = new GlobalData();
            complist = globalData.CompanyList.Select(p => new SelectListItem
            {
                Text = p.compname,
                Value = p.compid.ToString()
            }).ToList();

            #endregion 

            #region Drop down in File Category view

            filecatlist = globalData.FileCatList.Select(p => new SelectListItem
            {
                Text = p.catname,
                Value = p.catid.ToString()
            }).ToList();

            #endregion 


        }

        public filemanagermodel(filemanager objfilemanager) : this()
        {
            fileid = objfilemanager.fileid;
            filecode = objfilemanager.filecode;
            filecatid = objfilemanager.filecatid;
            filesubcatid = objfilemanager.filesubcatid;
            filetitle = objfilemanager.filetitle;
            filedate = objfilemanager.filedate;
            //uploadeddate = objfilemanager.uploadeddate;
            //filedescr = objfilemanager.filedescr;
            //compid = objfilemanager.compid;
            //compfinid = objfilemanager.compfinid;
            //compname = objfilemanager.compname;
            //finyear = objfilemanager.finyear;
            //catname = objfilemanager.catname;
            //subcatname = objfilemanager.subcatname;

        }

        public filemanagermodel(filemanagercomplist objfilemanager) : this()
        {
            fileid = objfilemanager.fileid;
            filecode = objfilemanager.filecode;
            filetitle = objfilemanager.filetitle;
            compid = objfilemanager.compid;
            compfinid = objfilemanager.compfinid;
            compname = objfilemanager.compname;
            finyear = objfilemanager.finyear;
            catname = objfilemanager.catname;
            subcatname = objfilemanager.subcatname;
        }

        public filemanagermodel(filemanagermodel objfilemanager) : this()
        {
            fileid = objfilemanager.fileid;
            filecode = objfilemanager.filecode;
            filecatid = objfilemanager.filecatid;
            filesubcatid = objfilemanager.filesubcatid;
            filetitle = objfilemanager.filetitle;
            filedate = objfilemanager.filedate;
            uploadeddate = objfilemanager.uploadeddate;
            filedescr = objfilemanager.filedescr;
            compid = objfilemanager.compid;
            compfinid = objfilemanager.compfinid;
            compname = objfilemanager.compname;
            finyear = objfilemanager.finyear;
            catname = objfilemanager.catname;
            subcatname = objfilemanager.subcatname;

        }

        [Display(Name = "File Manager Id")]
        public string fileid { get; set; }

        [Display(Name = "File Manager Code")]
        [Required(ErrorMessage = "Enter File Manager Code")]
        public string filecode { get; set; }

        [Display(Name = "Category Id")]
        [Required(ErrorMessage = "Select File Category")]
        public string filecatid { get; set; }

        [Display(Name = "Category Name")]
        public string catname { get; set; }

        [Display(Name = "Sub Category Id")]
        public string filesubcatid { get; set; }

        [Display(Name = "Sub Category Name")]
        public string subcatname { get; set; }

        [Display(Name = "File Title")]
        [Required(ErrorMessage = "Enter File Title")]
        public string filetitle { get; set; }

        [Display(Name = "File Manager Date")]
        public DateTime? filedate { get; set; }

        [Required(ErrorMessage = "Enter File Manager Code")]
        public string filedate1 { get; set; }

        [Display(Name = "Uploaded Date")]
        public DateTime uploadeddate { get; set; }
        public string uploadeddate1 { get; set; }

        [Display(Name = "File Description")]
        public string filedescr { get; set; }

        [Display(Name = "Company Id")]
        [Required(ErrorMessage = "Select Company")]
        public string compid { get; set; }

        [Display(Name = "Company Name")]
        public string compname { get; set; }

        [Display(Name = "Financial Year Id")]
        [Required(ErrorMessage = "Select Financial Year")]
        public string compfinid { get; set; }

        [Display(Name = "Financial Year")]
        public string finyear { get; set; }


        public List<filemanagermodel> ShowallfileManagerData { get; set; }

        public List<SelectListItem> complist { get; set; }
        public List<SelectListItem> compfinyearlist { get; set; }
        public List<SelectListItem> filecatlist { get; set; }
        public List<SelectListItem> filesubcatlist { get; set; }

    }
}