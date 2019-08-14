using Business;
using FRSS.Helpers;
using FRSS.Models;
using FRSS.Utility;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FRSS.Controllers
{
    [ProjectSessionActionFilter]

    public class filemanagerController : Controller
    {

        // GET: filemanager
        public ActionResult Index()
        {
            return View();
        }

        [Authorize]
        public ActionResult ViewFileManagerList()
        {
            try
            {
                ManageFileManager filemanager = new ManageFileManager();
                ViewBag.FileManagerList = filemanager.ManageFileManagerList;

                return View();
            }
            catch
            {
                ViewBag.Error = "Sorry, Problem in getting File Manager list";
            }
            return View();
        }

        public ActionResult OprFileManager(string id = "")
        {
            var istdate = TimeZoneInfo.ConvertTimeBySystemTimeZoneId(DateTime.Now, TimeZoneInfo.Local.Id, "India Standard Time");
            
            ManageCompMaster companyMaster = new ManageCompMaster();
            fileManagerAdd objmodel = new fileManagerAdd();
            ManageFileManager filemanager = new ManageFileManager();

            if (id == "")
            {
                var companyList = companyMaster.compmastersListByCustId(ProjectSession.custid);
                ViewBag.CompanyList = new SelectList(companyList, "compid", "compname");

                var categoryList = filemanager.GetFileCategory();
                ViewBag.CategoryList = new SelectList(categoryList, "catid", "catname");

                objmodel.uploadeddate = istdate;
                objmodel.filedate = istdate;
            }
            else
            {
                var fileMData = filemanager.GetFileManagerById(id, ProjectSession.custid);
                var fileDetails = filemanager.GetFileDetailsById(fileMData.fileid, ProjectSession.custid);
                objmodel.fileid = fileMData.fileid;
                objmodel.fileid1 = fileMData.fileid1.Value;
                objmodel.compid = fileMData.compid;
                objmodel.compfinid = fileMData.compfinid;
                objmodel.filecatid = fileMData.filecatid;
                objmodel.filesubcatid = fileMData.filesubcatid;
                objmodel.filetitle = fileMData.filetitle;
                objmodel.filedate = fileMData.filedate;
                objmodel.uploadeddate = fileMData.uploadeddate.Value;
                objmodel.filedescr = fileMData.filedescr;
                objmodel.filedtlid = fileDetails.filedtlid;
                objmodel.fileimageSaved = fileDetails.fileimage;
                objmodel.filetype = fileDetails.filetype;
                objmodel.filename = fileDetails.filename;
                objmodel.filedtlid1 = fileDetails.filedtlid1.Value;
                var imagetype = objmodel.filetype.Substring(1,objmodel.filetype.Length-1);

                var companyList = companyMaster.compmastersListByCustId(ProjectSession.custid);
                ViewBag.CompanyList = new SelectList(companyList, "compid", "compname", objmodel.compid);               

                var categoryList = filemanager.GetFileCategory();
                ViewBag.CategoryList = new SelectList(categoryList, "catid", "catname", objmodel.filecatid);
               
                ViewBag.Base64String = "data:image/"+imagetype +";base64," + Convert.ToBase64String(objmodel.fileimageSaved, 0, objmodel.fileimageSaved.Length);
            }
            return View(objmodel);
        }
        [HttpPost]
        public ActionResult OprFileManager(fileManagerAdd obj, HttpPostedFileBase fileimage)
        {
            if (string.IsNullOrEmpty(obj.fileid)  )
            {
                if (!(fileimage != null && fileimage.ContentLength > 0))
                {
                    ModelState.AddModelError("fileImage", "Please Select Image");                    
                }
            }
            if (ModelState.IsValid)
            {
                filemanager fm = new filemanager();
                filemanagerdtl fldtl = new filemanagerdtl();
                ManageFileManager filemanager = new ManageFileManager();
                fm.filetitle = obj.filetitle;
                fm.filecatid = obj.filecatid;
                fm.filesubcatid = obj.filesubcatid;
                fm.filedate = obj.filedate;
                fm.uploadeddate = obj.uploadeddate;
                fm.filedescr = obj.filedescr;
                //fm.syncflg
                fm.custid = ProjectSession.custid;
                fm.addedby = "0";
                fm.editedby = "0";
                fm.adddatetime = DateTime.Now;
                fm.editdatetime = DateTime.Now;
                fm.compid = obj.compid;
                fm.compfinid = obj.compfinid;

                if (string.IsNullOrEmpty(obj.fileid))
                {
                    long fileId = filemanager.GetLastFileId() + 1;
                    fm.fileid1 = fileId;
                    fm.fileid = ProjectSession.custid + "-" + fileId.ToString("0000");
                    fm.filecode = fileId.ToString();
                    filemanager.AddFile(fm);
                }
                else {
                    fm.fileid = obj.fileid;
                    fm.fileid1 = obj.filedtlid1;                   
                    fm.filecode = obj.fileid1.ToString();
                    filemanager.UpdateFile(fm);
                }
               


                if (fileimage != null && fileimage.ContentLength > 0)
                {
                    byte[] bytes;
                    using (BinaryReader br = new BinaryReader(fileimage.InputStream))
                    {
                        bytes = br.ReadBytes(fileimage.ContentLength);
                    }
                    string ContentType = fileimage.ContentType;
                    string typ = ContentType.Split('/')[1];
                    fldtl.addedby = "0";
                    fldtl.fileid = fm.fileid;
                    fldtl.custid = ProjectSession.custid;
                    fldtl.fileimage = bytes;
                    fldtl.filetype = "." + typ;
                    

                    long filedtlId = 0;
                    if (string.IsNullOrEmpty(obj.filedtlid))
                    {
                        filedtlId = filemanager.GetLastFiledtlId()+1;
                        fldtl.filedtlid = ProjectSession.custid + "-" + filedtlId.ToString("0000");
                        fldtl.filedtlid1 = filedtlId;                   
                        fldtl.adddatetime = DateTime.Now;
                        fldtl.filename = filedtlId + "." + typ;
                        filemanager.AddFiledtl(fldtl);
                    }
                    else
                    {                    
                        fldtl.filedtlid = obj.filedtlid; ;
                        fldtl.filedtlid1 = obj.filedtlid1;
                        fldtl.filename = obj.filedtlid + "." + typ;
                        filemanager.UpdateFiledtl(fldtl);
                    }
                    
                    
                }
                return RedirectToAction("ViewFileManagerList");

            }
            ManageCompMaster companyMaster = new ManageCompMaster();
            ManageFileManager filemanager1 = new ManageFileManager();

            var companyList = companyMaster.compmastersListByCustId(ProjectSession.custid);
            ViewBag.CompanyList = new SelectList(companyList, "compid", "compname", obj.compid);

            var categoryList = filemanager1.GetFileCategory();
            ViewBag.CategoryList = new SelectList(categoryList, "catid", "catname", obj.filecatid);
            return View(obj);
        }


        public ActionResult FileManager(string id = "")
        {
            var istdate = TimeZoneInfo.ConvertTimeBySystemTimeZoneId(DateTime.Now, TimeZoneInfo.Local.Id, "India Standard Time");

            filemanagermodel objmodel = new filemanagermodel();
            ManageFileManager filemanager = new ManageFileManager();

            if (id == "")
            {
                objmodel.uploadeddate1 = CommonMethod.ToDDMMYYYY(istdate);
                objmodel.filedate1 = CommonMethod.ToDDMMYYYY(istdate);

                //ViewBag.compid = new SelectList(filemanager.CompList, "compid", "compname");
                //ViewBag.compfinyr = new SelectList(new List<compfinyearlist>(), "compfinid", "finyear");

                //ViewBag.filecatlist = new SelectList(filemanager.FileCatList, "catid", "catname");
                //ViewBag.filesubcat = new SelectList(new List<mstfilesubcategory>(), "subcatid", "subcatname");
            }
            return View(objmodel);
        }

        [HttpGet]
        public ActionResult GetCompany()
        {
            try
            {
                ManageFileManager filemanager = new ManageFileManager();
                var data = filemanager.GetCompany();
                return new ReplyFormat().Success(Message.SUCCESS, data);
            }
            catch (Exception ex)
            {
                return new ReplyFormat().Error(ex.Message.ToString());
            }
        }

        [HttpGet]
        public ActionResult GetFinicialYearByCompanyId()
        {
            try
            {
                ManageFileManager filemanager = new ManageFileManager();
                var data = filemanager.GetCompany();
                return new ReplyFormat().Success(Message.SUCCESS, data);
            }
            catch (Exception ex)
            {
                return new ReplyFormat().Error(ex.Message.ToString());
            }
        }

        [HttpGet]
        public ActionResult GetFileCategory()
        {
            try
            {
                ManageFileManager filemanager = new ManageFileManager();
                var data = filemanager.GetFileCategory();
                return new ReplyFormat().Success(Message.SUCCESS, data);
            }
            catch (Exception ex)
            {
                return new ReplyFormat().Error(ex.Message.ToString());
            }
        }

        [HttpGet]
        public ActionResult GetFileSubCategory(int catid)
        {
            try
            {
                ManageFileManager filemanager = new ManageFileManager();
                var data = filemanager.GetFileSubCategory(catid);
                return new ReplyFormat().Success(Message.SUCCESS, data);
            }
            catch (Exception ex)
            {
                return new ReplyFormat().Error(ex.Message.ToString());
            }
        }

        [HttpPost]
        public ActionResult FileManager(filemanagermodel objmodel)
        {
            try
            {
                ManageFileManager filemanager = new ManageFileManager();
                string strRet = "Please check entered details. Something wrong with that";

                if (ModelState.IsValid)
                {

                }
                else
                {
                    var istdate = TimeZoneInfo.ConvertTimeBySystemTimeZoneId(DateTime.Now, TimeZoneInfo.Local.Id, "India Standard Time");

                    objmodel.uploadeddate1 = CommonMethod.ToDDMMYYYY(istdate);
                    objmodel.filedate1 = CommonMethod.ToDDMMYYYY(istdate);

                    ViewBag.compid = new SelectList(filemanager.CompList, "compid", "compname");
                    ViewBag.compfinyr = new SelectList(new List<compfinyearlist>(), "compfinid", "finyear");

                    ViewBag.filecatlist = new SelectList(filemanager.FileCatList, "catid", "catname");
                    ViewBag.filesubcat = new SelectList(new List<mstfilesubcategory>(), "subcatid", "subcatname");
                }
            }
            catch
            {
                ViewBag.Error = "Sorry,Detail is not inserted";
            }
            return View(objmodel);
        }

        [HttpPost]
        public ActionResult SaveFileManager(string fileid, string compid, string compfinid,
                string filecode,
                string filecatid,
                string filesubcatid,
                string filetitle,
                DateTime uploadeddate,
                DateTime filedate,
                string filedescr, string files)
        {
            try
            {


                return new ReplyFormat().Success(Message.SUCCESS, fileid);
            }
            catch (Exception ex)
            {
                return new ReplyFormat().Error(ex.Message.ToString());
            }
        }


        [HttpPost]
        public ActionResult SaveFile(string file, string filename, int fileId)
        {
            try
            {
                //fileManagerrepo.SaveFile(file, filename, fileId);
                return new ReplyFormat().Success(Message.SUCCESS);
            }
            catch (Exception ex)
            {
                return new ReplyFormat().Error(ex.Message.ToString());
            }
        }

        [HttpGet]
        public JsonResult GetJsonFileSubCategory(int id)
        {
            ManageFileManager filemanager = new ManageFileManager();
            var data = filemanager.GetFileSubCategory(id);
            var displlist = data.Select(m => new SelectListItem()
            {
                Text = m.subcatname,
                Value = m.subcatid.ToString()
            });

            return Json(displlist, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public JsonResult GetJsonCompFinYear(string id)
        {
            ManageFileManager filemanager = new ManageFileManager();
            var data = filemanager.GetCompFinYear(id);
            var displlist = data.Select(m => new SelectListItem()
            {
                Text = m.finyear,
                Value = m.compfinid.ToString()
            });

            return Json(displlist, JsonRequestBehavior.AllowGet);
        }
    }
}