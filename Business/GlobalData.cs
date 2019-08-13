using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public class GlobalData
    {
        public IList<compmasterlist> CompanyList
        {
            get
            {
                using (frssdbEntities entities = new frssdbEntities())
                {
                    return entities.compmasterlists.OrderBy(s => s.compname).ToList();
                }
            }
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
    }
}
