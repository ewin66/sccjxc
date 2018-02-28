using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TAddWinform
{
    public class CurrentStockModel
    {
        public string WareCode { get; set; }
        public string WareName { get; set; }
        public string InvCode { get; set; }
        public string InvName { get; set; }
        public string UnitName { get; set; }
        public string InvStd { get; set; }
        public string ItemName { get; set; }

        public string Materials { get; set; }
        public string Color { get; set; }
        public string Dimension { get; set; }
        public string COO { get; set; }

        public decimal cCost { get; set; }
        public decimal cSalePrice { get; set; }
        public decimal Qty { get; set; }
        public decimal r { get; set; }
        public decimal c { get; set; }
        public decimal k { get; set; }
        public byte[] Photo { get; set; }
    }
}
