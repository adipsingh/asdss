using Business;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FRSS.Models
{
    public class bankmicrcodemodel
    {
        public bankmicrcodemodel()
        {

        }

        public bankmicrcodemodel(bankmicrcode objbankmicrcode) : this()
        {
            codeid = objbankmicrcode.codeid;
            bankname = objbankmicrcode.bankname;
            ifsccode = objbankmicrcode.ifsccode;
            micrcode = objbankmicrcode.micrcode;
            branchname = objbankmicrcode.branchname;
            bankaddress = objbankmicrcode.bankaddress;
        }

        public bankmicrcodemodel(bankmicrcodemodel objbankmicrcode) : this()
        {
            codeid = objbankmicrcode.codeid;
            bankname = objbankmicrcode.bankname;
            ifsccode = objbankmicrcode.ifsccode;
            micrcode = objbankmicrcode.micrcode;
            branchname = objbankmicrcode.branchname;
            bankaddress = objbankmicrcode.bankaddress;
        }

        public long codeid { get; set; }
        public string bankname { get; set; }
        public string ifsccode { get; set; }
        public string micrcode { get; set; }
        public string branchname { get; set; }
        public string bankaddress { get; set; }
    }
}