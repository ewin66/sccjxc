using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TAddWinform.Model
{
    public class Company
    {
        public int Id { get; set; }
        public string CompanyCode { get; set; }
        public string CompanyName1 { get; set; }
        public int CompanyType { get; set; }
        public bool Actived { get; set; }public string Remark { get; set; }
    }
}