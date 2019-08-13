using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public class ManageUserInfo
    {

        public userinfo GetUserInfoById(string custid)
        {
            frssdbEntities entities = new frssdbEntities();
            userinfo userinfo1 = entities.userinfoes.FirstOrDefault(s => s.custid == custid);
            if (userinfo1 == null) return null;
            return userinfo1;
        }


        public long? GetMaxNo(string custid)
        {
            long? getmaxno = 0;

            frssdbEntities entities = new frssdbEntities();
            getmaxno = (from c in entities.userinfoes
                        where c.custid == custid
                        select c.infoid).Max();

            return getmaxno + 1;
        }

        public void AddUpdatemanageuserinfo(bool formmode, long? infoid, string compcode, string compname, string compaddr1, string compaddr2, string compaddr3, long? compzip, string compcity, string compstate, long? compstatecode, string compcontry, long? compstdcode, long? compphone, long? compmobile1, long? compmobile2, string compemail, string compweb, string compgstno, string comppanno, string compdruglicno, string compserialkey, string custid)
        {
            string result = string.Empty;
            string ip = Common.GetUserIp;
            long infoid1_1 = 0;

            if (formmode == true)
            {
                infoid1_1 = Convert.ToInt32(GetMaxNo(custid));

                using (frssdbEntities entities = new frssdbEntities())
                {
                    userinfo entry = new userinfo
                    {
                        infoid = infoid1_1,
                        compcode = compcode,
                        compname = compname,
                        compaddr1 = compaddr1,
                        compaddr2 = compaddr2,
                        compaddr3 = compaddr3,
                        compzip = compzip,
                        compcity = compcity,
                        compstate = compstate,
                        compstatecode = compstatecode,
                        compcontry = compcontry,
                        compstdcode = compstdcode,
                        compphone = compphone,
                        compmobile1 = compmobile1,
                        compmobile2 = compmobile2,
                        compemail = compemail,
                        compweb = compweb,
                        compgstno = compgstno,
                        comppanno = comppanno,
                        compdruglicno = compdruglicno,
                        compserialkey = compserialkey,
                        syncflg = '0',
                        custid = custid,

                    };
                    entities.userinfoes.Add(entry);
                    entities.SaveChanges();
                }
            }
            else
            {
                using (frssdbEntities entities = new frssdbEntities())
                {
                    userinfo entry = entities.userinfoes.FirstOrDefault(p => p.infoid == infoid && p.custid == custid);

                    if (entry != null)
                    {
                        entry.compcode = compcode;
                        entry.compname = compname;
                        entry.compaddr1 = compaddr1;
                        entry.compaddr2 = compaddr2;
                        entry.compaddr3 = compaddr3;
                        entry.compzip = compzip;
                        entry.compcity = compcity;
                        entry.compstate = compstate;
                        entry.compstatecode = compstatecode;
                        entry.compcontry = compcontry;
                        entry.compstdcode = compstdcode;
                        entry.compphone = compphone;
                        entry.compmobile1 = compmobile1;
                        entry.compmobile2 = compmobile2;
                        entry.compemail = compemail;
                        entry.compweb = compweb;
                        entry.compgstno = compgstno;
                        entry.comppanno = comppanno;
                        entry.compdruglicno = compdruglicno;
                        entry.compserialkey = compserialkey;
                        entry.syncflg = '1';
                        entry.custid = custid;

                    }
                    entities.SaveChanges();
                }
            }
        }

    }
}
