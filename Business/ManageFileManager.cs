using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public class ManageFileManager
    {
        public IList<filemanagercomplist> ManageFileManagerList
        {
            get
            {
                using (frssdbEntities entities = new frssdbEntities())
                {
                    return entities.filemanagercomplists.AsEnumerable()
                        .Select(s => new filemanagercomplist
                        {
                            fileid = s.fileid,
                            filecode = s.filecode,
                            filedate = s.filedate,
                            compname = s.compname,
                            finyear=s.finyear,
                            filetitle=s.filetitle,
                            catname=s.catname,
                            subcatname=s.subcatname,
                            compid=s.compid,
                            compfinid=s.compfinid
                        }).ToList();
                }
            }
        }

        public filemanager GetFileManagerById(string fileid, string custid)
        {
            frssdbEntities entities = new frssdbEntities();
            filemanager filemgr = entities.filemanagers.FirstOrDefault(s => s.fileid == fileid && s.custid == custid);
            if (filemgr == null) return null;
            return filemgr;
        }

        public filemanagerdtl GetFileDetailsById(string fileid, string custid)
        {
            frssdbEntities entities = new frssdbEntities();
            filemanagerdtl filemgr = entities.filemanagerdtls.FirstOrDefault(s => s.fileid == fileid && s.custid == custid);
            if (filemgr == null) return null;
            return filemgr;
        }

        public IList<mstfilecategory> FileCatList
        {
            get
            {
                using (frssdbEntities entities = new frssdbEntities())
                {
                    return entities.mstfilecategories.OrderBy(s => s.catname).ToList();
                }
            }
        }
        
        public List<mstfilesubcategory> GetFileSubCategory(int catid)
        {
            frssdbEntities entities = new frssdbEntities();
            var data = entities.mstfilesubcategories.Where(cat => cat.catid == catid).ToList();
            return data;
        }

        public IList<compmaster> CompList
        {
            get
            {
                using (frssdbEntities entities = new frssdbEntities())
                {
                    return entities.compmasters.OrderBy(s => s.compname).ToList();
                }
            }
        }

        public List<mstfilecategory> GetFileCategory()
        {
            frssdbEntities entities = new frssdbEntities();
            var data = entities.mstfilecategories.ToList();
            return data;
        }


        public List<compmaster> GetCompany()
        {
            frssdbEntities entities = new frssdbEntities();
            var data = entities.compmasters.ToList();
            return data;
        }

        public List<compfinyearlist> GetCompFinYear(string compid)
            {
            frssdbEntities entities = new frssdbEntities();
            var compcode = entities.compmasters.FirstOrDefault(c => c.compid == compid).compcode;
            var data = entities.compfinyearlists.Where(cat => cat.compcode == compcode).ToList();
            return data;
        }

        public long GetLastFileId()
        {
            long lastFieldId = 0;
            string value = string.Empty;
            using (frssdbEntities entities = new frssdbEntities())
            {
                filemanager lastRecord = entities.filemanagers.OrderByDescending(fm => fm.fileid1).FirstOrDefault();
                
                if (lastRecord != null)
                {
                    lastFieldId = lastRecord.fileid1.Value;
                }
               
            }
            return lastFieldId;
        }

        public void UpdateFile(filemanager record)
        {
            frssdbEntities entities = new frssdbEntities();
            var data = entities.Entry(record).State=System.Data.Entity.EntityState.Modified;
            entities.SaveChanges();
        }

        public void AddFile(filemanager record)
        {
            frssdbEntities entities = new frssdbEntities();
            var data = entities.filemanagers.Add(record);
            entities.SaveChanges();
        }

        public long GetLastFiledtlId()
        {
            long lastFieldId = 0;
            string value = string.Empty;
            using (frssdbEntities entities = new frssdbEntities())
            {
                filemanagerdtl lastRecord = entities.filemanagerdtls.OrderByDescending(fm => fm.filedtlid1).FirstOrDefault();

                if (lastRecord != null)
                {
                    lastFieldId = lastRecord.filedtlid1.Value;
                }
            }
            return lastFieldId;
        }

        public void AddFiledtl(filemanagerdtl record)
        {
            frssdbEntities entities = new frssdbEntities();
            var data = entities.filemanagerdtls.Add(record);
            entities.SaveChanges();
        }
        public void UpdateFiledtl(filemanagerdtl record)
        {
            frssdbEntities entities = new frssdbEntities();
            entities.Entry(record).State = System.Data.Entity.EntityState.Modified;
            entities.SaveChanges();
        }

    }
}
 