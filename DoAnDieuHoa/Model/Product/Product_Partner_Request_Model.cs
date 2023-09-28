﻿using DADH.Entities;

namespace DADH.Model.Product
{
    public class Product_Partner_Request_Model : IAuditableEntity
    {
        public long product_id { get; set; }
        public long partner_id { get; set; }
        public decimal price { get; set; }
        public string? unit_code { get; set; } // mã đon tính
        public string? packing_code { get; set; }// mã quy cách đóng gói
        public string note { get; set; } = "";
        public string product_name { get; set; } = "";
        public string partner_name { get; set; } = "";
        public double opening_stock { get; set; }
        public double during_import { get; set; }
        public double during_export { get; set; }


    }
}
