using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace Business
{
    public class SigninManager
    {
        public bool IsAuthenticated { get; private set; }
        public SigninStatus SigninStatus { get; private set; }

        public usermaster User { get; set; }

        public SigninManager()
        {
            IsAuthenticated = false;
            SigninStatus = SigninStatus.Undefine;
            User = new usermaster();
        }

        public async Task<SigninStatus> SigninUserAsync(string userName, string password, string custid)
        {
            usermaster user;
            using (frssdbEntities entities = new frssdbEntities())
            {
                Task<usermaster> objlogin = entities.usermasters.FirstOrDefaultAsync(s => s.username == userName && s.userpwd == password && s.custid == custid);

                user = await objlogin;
                if (user != null)
                {
                    user.lockuser = "1";
                    await entities.SaveChangesAsync();
                }
            }

            if (user == null) return SigninStatus;
            else
            {
                SigninStatus = SigninStatus.Success;
            }
            User = user;
            User.userpwd = string.Empty;
            return SigninStatus;
        }

        public string GetUserIdByUserName(string userName)
        {
            using (frssdbEntities entity = new frssdbEntities())
            {
                return entity.usermasters.FirstOrDefault(s => s.username == userName).userid;
            }
        }

        public SigninStatus SigninUser(string userName, string password)
        {
            usermaster user;
            using (frssdbEntities entities = new frssdbEntities())
            {
                //password = CryptograpyHelper.ToSha256(password);
                user = entities.usermasters.FirstOrDefault(s => s.username == userName && s.userpwd == password);
                if (user != null)
                {
                    user.lockuser = "1";
                    entities.SaveChanges();
                }
                if (user == null) return SigninStatus;
                else
                {
                    SigninStatus = SigninStatus.Success;
                }
                User = user;
                User.userpwd = string.Empty;

                return SigninStatus;
            }
        }



    }
}
