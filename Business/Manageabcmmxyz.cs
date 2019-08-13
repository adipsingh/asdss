using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public class Manageabcmmxyz
    {
        public abcmmxyz getabcmmxyz(string custid)
        {
            frssdbEntities entities = new frssdbEntities();
            abcmmxyz abcmmxyzlist = entities.abcmmxyzs.FirstOrDefault(s => s.agdfgcidrttr == custid);
            if (abcmmxyzlist == null) return null;

            return abcmmxyzlist;
        }
    }
}
