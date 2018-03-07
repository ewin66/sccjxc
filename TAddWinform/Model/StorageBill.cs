using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TAddWinform.Model {
    public class StorageBill {

        public string Id { get; set; } //入库单号
        public DateTime MakeDate { get; set; } //入库日期
        public int StorehouseId { get; set; } //仓库Id
        public string StorehouseName { get; set; } //仓库名称
        public int CompanyId { get; set; }  //关联单位Id
        public string CompanyName { get; set; } //关联单位名称
        public int BillTypeId { get; set; } //单据类型id
        public bool IsOut { get; set; } //是否为出库
        public string Maker { get; set; }   //制单人
        public string GoodsCode { get; set; }   //商品编码
        public string GoodsName { get; set; }   //商品名称
        public string GoodsFromName { get; set; }   //商品产地
        public string GoodsCategoryName  { get; set; }//商品种类
        public decimal UnitPrice { get; set; }  //当品单价
        public decimal Total { get; set; }  //采购总价
    }
}
