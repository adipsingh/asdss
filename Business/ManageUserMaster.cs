using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public class ManageUserMaster
    {
        public IList<usermasterlist> ManageUserMasterList
        {
            get
            {
                using (frssdbEntities entities = new frssdbEntities())
                {
                    return entities.usermasterlists.AsEnumerable()
                        .Select(s => new usermasterlist
                        {
                            userid = s.userid,
                            username = s.username,
                            usermobile = s.usermobile,
                            useremail = s.useremail,
                            userstatus = s.userstatus
                        }).ToList();
                }
            }
        }

        public usermaster GetUserbyId(string userid, string custid)
        {
            frssdbEntities entities = new frssdbEntities();
            usermaster usermstr = entities.usermasters.FirstOrDefault(s => s.userid == userid && s.custid == custid);
            if (usermstr == null) return null;
            return usermstr;
        }

        public bool UserNameExist(string username, string custid)
        {
            frssdbEntities entities = new frssdbEntities();
            usermaster usermstr = entities.usermasters.FirstOrDefault(s => s.username == username && s.custid == custid);
            if (usermstr == null) return false;
            return true;
        }

        public bool UserEmailExist(string useremail, string custid)
        {
            frssdbEntities entities = new frssdbEntities();
            usermaster usermstr = entities.usermasters.FirstOrDefault(s => s.useremail == useremail && s.custid == custid);
            if (usermstr == null) return false;
            return true;
        }

        #region Add-Edit-Delete Event

        public long? GetMaxNo(string custid)
        {
            long? getmaxno = 0;

            frssdbEntities entities = new frssdbEntities();
            //getmaxno = entities.usermasters.Max(s => s.userid1);
            getmaxno = (from c in entities.usermasters
                        where c.custid == custid
                        select c.userid1).Max();

            return getmaxno + 1;
        }

        public void AddUpdateUserMaster(bool addmode, string userid, string username, string userpwd, string usermobile, string useremail, string userstatus, string custid, bool? addrights, bool? editrights, bool? deleterights, bool? uploadrights, bool? downloadrights, bool? sendmailrights)
        {
            string result = string.Empty;
            string ip = Common.GetUserIp;
            long? userid1_1 = 0;
            string userid_1 = "";

            if (addmode == true)
            {

                userid1_1 = GetMaxNo(custid);
                userid_1 = custid + "-" + userid1_1.ToString();

                using (frssdbEntities entities = new frssdbEntities())
                {
                    usermaster entry = new usermaster
                    {
                        userid = userid_1,
                        userid1 = userid1_1,
                        username = username,
                        userpwd = userpwd,
                        usermobile = usermobile,
                        useremail = useremail,
                        userstatus = userstatus,
                        syncflg = '0',
                        addrights = addrights,
                        editrights = editrights,
                        deleterights = deleterights,
                        uploadrights = uploadrights,
                        downloadrights = downloadrights,
                        sendmailrights = sendmailrights,
                        custid = custid
                    };
                    entities.usermasters.Add(entry);
                    entities.SaveChanges();
                }
            }
            else
            {
                using (frssdbEntities entities = new frssdbEntities())
                {
                    usermaster entry = entities.usermasters.FirstOrDefault(p => p.userid == userid && p.custid==custid);

                    if (entry != null)
                    {
                        entry.username = username;
                        entry.userpwd = userpwd;
                        entry.usermobile = usermobile;
                        entry.useremail = useremail;
                        entry.userstatus = userstatus;
                        entry.syncflg = '1';
                        entry.addrights = addrights;
                        entry.editrights = editrights;
                        entry.deleterights = deleterights;
                        entry.uploadrights = uploadrights;
                        entry.downloadrights = downloadrights;
                        entry.sendmailrights = sendmailrights;
                        entry.custid = custid;
                    }
                    entities.SaveChanges();
                }
            }
        }

        public void Changepassword(string userid, string userpwd, string custid)
        {
            using (frssdbEntities entities = new frssdbEntities())
            {
                usermaster entry = entities.usermasters.FirstOrDefault(p => p.userid == userid && p.custid == custid);

                if (entry != null)
                {
                    entry.userpwd = userpwd;
                    entry.custid = custid;
                }
                entities.SaveChanges();
            }
        }

        #endregion

    }
}
