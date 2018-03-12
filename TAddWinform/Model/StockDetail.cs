using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TAddWinform.Model
{
    class StockDetail
    {
        public string GoodsName { get; set; }
        public string GoodsFromName { get; set; }
        public string GoodsCategoryName { get; set; }
        public string StorehouseName { get; set; }
        public string InCount { get; set; }
        public string OutCount { get; set; }
        public bool BillTypeId { get; set; }
        public string LastCount { get; set; }
    }
}