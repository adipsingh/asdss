using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
   public class ChallanForm
    {
        public IList<mstchallandown> ChallanFormList
        {
            get
            {
                using (frssdbEntities entities = new frssdbEntities())
                {
                    return entities.mstchallandowns.ToList();
                }
            }
        }

        public mstchallandown ChallanFormById(int id)
        {            
                using (frssdbEntities entities = new frssdbEntities())
                {
                    return entities.mstchallandowns.Where(ch=>ch.id==id) .FirstOrDefault();
                }
            
        }
    }
}
