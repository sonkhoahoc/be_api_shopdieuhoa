﻿using DADH.Entities;

namespace DADH.Model.Product
{
    public class Combo_Model : IAuditableEntity
    {
        public string code { get; set; } = string.Empty;
        public string? name { get; set; }
        public string? note { get; set; }
        public string? category_code { get; set; }
        public bool is_active { get; set; }
        public string? barcode { get; set; }
        public string? unit_code { get; set; } // mã đon tính
        public string? packing_code { get; set; }// mã quy cách đóng gói
        public double price { get; set; } = 0;
        public List<Product_Combo_Model> childs { get; set; } = new List<Product_Combo_Model>();
    }
}
