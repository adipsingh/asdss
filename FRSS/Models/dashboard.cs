using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FRSS.Models
{
    public class dashboard
    {
        public dashboard()
        {
        }

        public class BoxDashboard
        {
            public int totaldocs { get; set; }
            public int totalincometaxdocs { get; set; }
            public int totalgstdocs { get; set; }
            public int totaltaxaudidocs { get; set; }
        }
    }
}