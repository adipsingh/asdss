using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public class ManageCompFinYear
    {

        public IList<compfinyearlist> ManageCompFinYearList
        {
            get
            {
                using (frssdbEntities entities = new frssdbEntities())
                {
                    return entities.compfinyearlists.AsEnumerable()
                        .Select(s => new compfinyearlist
                        {
                            compfinid = s.compfinid,
                            compcode = s.compcode,
                            compname = s.compname,
                            finyear = s.finyear
                        }).ToList();
                }
            }
        }

        public compfinyear GetFinYearbyId(string compfinyrid, string custid)
        {
            frssdbEntities entities = new frssdbEntities();
            compfinyear compfinyr = entities.compfinyears.FirstOrDefault(s => s.compfinid == compfinyrid && s.custid == custid);
            if (compfinyr == null) return null;
            return compfinyr;
        }

        public bool GetFinYearByCompYear(string compid, string finyrstart, string finyrend, string custid)
        {
            frssdbEntities entities = new frssdbEntities();
            compfinyear compfinyrlist = entities.compfinyears.FirstOrDefault(s => s.compid == compid && s.finyrstart == finyrstart && s.finyrend == finyrend && s.custid== custid);
            if (compfinyrlist == null) return false;
            return true;
        }

        #region Add-Edit-Delete Event

        public long? GetMaxNo(string custid)
        {
            long? getmaxno = 0;

            frssdbEntities entities = new frssdbEntities();
            //getmaxno = entities.compfinyears.Max(s => s.compfinid1);
            getmaxno = (from c in entities.compfinyears
                        where c.custid == custid
                        select c.compfinid1).Max();

            return getmaxno + 1;
        }

        public void AddUpdateCompfinYear(bool addmode, string compfinid, string compid, string finyearstart, string finyearend, string custid, string addedby)
        {
            string result = string.Empty;
            string ip = Common.GetUserIp;
            long? compfinyearid1_1 = 0;
            string compfinyearid_1 = "";

            if (addmode == true)
            {

                compfinyearid1_1 = GetMaxNo(custid);
                compfinyearid_1 = custid + "-" + compfinyearid1_1.ToString();

                using (frssdbEntities entities = new frssdbEntities())
                {
                    compfinyear entry = new compfinyear
                    {
                        compfinid = compfinyearid_1,
                        compfinid1 = compfinyearid1_1,
                        compid = compid,
                        finyrstart = finyearstart,
                        finyrend = finyearend,
                        custid = custid,
                        syncflg = '0',
                        addedby = addedby,
                        adddatetime = DateTime.Now
                    };
                    entities.compfinyears.Add(entry);
                    entities.SaveChanges();
                }
            }
            else
            {
                using (frssdbEntities entities = new frssdbEntities())
                {
                    compfinyear entry = entities.compfinyears.FirstOrDefault(p => p.compfinid == compfinid && p.custid == custid);

                    if (entry != null)
                    {
                        entry.compfinid = compfinid;
                        entry.compid = compid;
                        entry.finyrstart = finyearstart;
                        entry.finyrend = finyearend;
                        entry.custid = custid;
                        entry.syncflg = '0';
                        entry.addedby = addedby;
                        entry.adddatetime = DateTime.Now;
                    }
                    entities.SaveChanges();
                }
            }
        }

        #endregion

    }
}
