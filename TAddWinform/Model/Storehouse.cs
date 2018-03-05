using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TAddWinform.Model {
    public class Storehouse {
        public int Id { get; set; }
        public string StorehouseCode { get; set; }
        public string StorehouseName { get; set; }
        public bool Actived { get; set; }
        public string Remark { get; set; }
    }
}
