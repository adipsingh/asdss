using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public class ManageBankMICRCode
    {
        public IList<bankmicrcode> ManageBankMICRCodeList
        {
            get
            {
                using (frssdbEntities entities = new frssdbEntities())
                {
                    return entities.bankmicrcodes.AsEnumerable()
                        .Select(s => new bankmicrcode
                        {
                            codeid= s.codeid,
                            bankname = s.bankname,
                            ifsccode = s.ifsccode,
                            micrcode = s.micrcode,
                            branchname=s.branchname,
                            bankaddress=s.bankaddress
                        }).ToList();
                }
            }
        }

    }
}
