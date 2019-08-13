using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public class ManageCompMaster
    {


        #region Add-Edit-Delete Event

        public long? GetMaxNo(string custid )
        {
            long? getmaxno = 0;

            frssdbEntities entities = new frssdbEntities();
            //getmaxno = entities.compmasters.Max(s => s.compid1);
            getmaxno = (from c in entities.compmasters
                        where c.custid == custid
                        select c.compid1).Max();

            return getmaxno + 1;
        }

        public string AddNewEvent(string compid, long compid1, string compcode, string compname, string compaddr1, string compaddr2, string compaddr3,
                                string compcity, long? compzip, string compstate, string compcontry, long? compstdcode, long? compphone,
                                long? compmobile1, long? compmobile2, string compweb, string compemail, long? compstatecode, string compgstno,
                                string comppanno, long syncflg, string custid, string area, string tanno, DateTime? regdate, string regno, long? faxno)
        {
            string ip = Common.GetUserIp;
            string result = string.Empty;
            long? compid1_1 = 0;
            string compid_1 = "";

            compid1_1 = GetMaxNo(custid);
            compid_1 = custid + "-" + compid1_1.ToString();

            using (frssdbEntities entities = new frssdbEntities())
            {
                compmaster entry = new compmaster
                {
                    compid = compid_1,
                    compid1 = compid1_1,
                    compcode = compcode,
                    compname = compname,
                    compaddr1 = compaddr1,
                    compaddr2 = compaddr2,
                    compaddr3 = compaddr3,
                    compcity = compcity,
                    compzip = compzip,
                    compstate = compstate,
                    compcontry = compcontry,
                    compstdcode = compstdcode,
                    compphone = compphone,
                    compmobile1 = compmobile1,
                    compmobile2 = compmobile2,
                    compweb = compweb,
                    compemail = compemail,
                    compstatecode = compstatecode,
                    compgstno = compgstno,
                    comppanno = comppanno,
                    syncflg = syncflg,
                    custid = custid,
                    area = area,
                    tanno = tanno,
                    regdate = regdate,
                    regno = regno,
                    faxno = faxno,
                    adddatetime = System.DateTime.Now
                };
                entities.compmasters.Add(entry);
                entities.SaveChanges();
                return entry.compid;
            }
        }

        public void UpdateEvent(string compid, long compid1, string compcode, string compname, string compaddr1, string compaddr2, string compaddr3,
                                string compcity, long? compzip, string compstate, string compcontry, long? compstdcode, long? compphone,
                                long? compmobile1, long? compmobile2, string compweb, string compemail, long? compstatecode, string compgstno,
                                string comppanno, long syncflg, string custid, string area, string tanno, DateTime? regdate, string regno, long? faxno)
        {
            using (frssdbEntities entities = new frssdbEntities())
            {
                compmaster entry = entities.compmasters.FirstOrDefault(p => p.compid == compid && p.custid==custid);

                if (entry != null)
                {
                    entry.compid = compid;
                    entry.compid1 = compid1;
                    entry.compcode = compcode;
                    entry.compname = compname;
                    entry.compaddr1 = compaddr1;
                    entry.compaddr2 = compaddr2;
                    entry.compaddr3 = compaddr3;
                    entry.compcity = compcity;
                    entry.compzip = compzip;
                    entry.compstate = compstate;
                    entry.compcontry = compcontry;
                    entry.compstdcode = compstdcode;
                    entry.compphone = compphone;
                    entry.compmobile1 = compmobile1;
                    entry.compmobile2 = compmobile2;
                    entry.compweb = compweb;
                    entry.compemail = compemail;
                    entry.compstatecode = compstatecode;
                    entry.compgstno = compgstno;
                    entry.comppanno = comppanno;
                    entry.syncflg = syncflg;
                    entry.custid = custid;
                    entry.area = area;
                    entry.tanno = tanno;
                    entry.regdate = regdate;
                    entry.regno = regno;
                    entry.faxno = faxno;

                    entities.SaveChanges();
                }
            }
        }

        public compmaster GetCompMasterbyId(string compid, string custid)
        {
            frssdbEntities entities = new frssdbEntities();
            compmaster compmst = entities.compmasters.FirstOrDefault(s => s.compid == compid && s.custid==custid);
            if (compmst == null) return null;

            return compmst;
        }

        public IList<compmaster> compmastersList
        {
            get
            {
                using (frssdbEntities entities = new frssdbEntities())
                {
                    return entities.compmasters.AsEnumerable().
                        Where(s => s.deletedflg == null ? false : (s.deletedflg == 0 || s.deletedby == null))
                        .Select(s => new compmaster
                        {
                            compid = s.compid,
                            compid1 = s.compid1,
                            compcode = s.compcode,
                            compname = s.compname,
                            compaddr1 = s.compaddr1,
                            compaddr2 = s.compaddr2,
                            compaddr3 = s.compaddr3,
                            compcity = s.compcity,
                            compzip = s.compzip,
                            compstate = s.compstate,
                            compcontry = s.compcontry,
                            compstdcode = s.compstdcode,
                            compphone = s.compphone,
                            compmobile1 = s.compmobile1,
                            compmobile2 = s.compmobile2,
                            compweb = s.compweb,
                            compemail = s.compemail,
                            compstatecode = s.compstatecode,
                            compgstno = s.compgstno,
                            comppanno = s.comppanno,
                            syncflg = s.syncflg,
                            custid = s.custid,
                            area = s.area,
                            tanno = s.tanno,
                            regdate = s.regdate,
                            regno = s.regno,
                            faxno = s.faxno,
                        }).ToList();
                }
            }
        }

        public IList<compmaster> compmastersListByCustId (string custId)
        {            
                using (frssdbEntities entities = new frssdbEntities())
                {
                    return entities.compmasters.AsEnumerable().
                        Where(s => s.custid==custId &&(  s.deletedflg == null ? false : (s.deletedflg == 0 || s.deletedby == null)))
                        .Select(s => new compmaster
                        {
                            compid = s.compid,
                            compid1 = s.compid1,
                            compcode = s.compcode,
                            compname = s.compname,
                            compaddr1 = s.compaddr1,
                            compaddr2 = s.compaddr2,
                            compaddr3 = s.compaddr3,
                            compcity = s.compcity,
                            compzip = s.compzip,
                            compstate = s.compstate,
                            compcontry = s.compcontry,
                            compstdcode = s.compstdcode,
                            compphone = s.compphone,
                            compmobile1 = s.compmobile1,
                            compmobile2 = s.compmobile2,
                            compweb = s.compweb,
                            compemail = s.compemail,
                            compstatecode = s.compstatecode,
                            compgstno = s.compgstno,
                            comppanno = s.comppanno,
                            syncflg = s.syncflg,
                            custid = s.custid,
                            area = s.area,
                            tanno = s.tanno,
                            regdate = s.regdate,
                            regno = s.regno,
                            faxno = s.faxno,
                        }).ToList();
                }
            
        }
        #endregion    

    }
}
