using DADH.Entities;

namespace DADH.Model.Product
{
    public class Product_Combo_Model : IAuditableEntity
    {
        public long combo_id { get; set; }
        public long product_id { get; set; }
        public double product_quantity { get; set; }
        public string note { get; set; } = "";
        public string? unit_code { get; set; } // mã đon tính 
        public string? product_name { get; set; } // mã đon tính 
        public string? packing_code { get; set; }// mã quy cách đóng gói
    }
}
