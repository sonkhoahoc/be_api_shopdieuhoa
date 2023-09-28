using System.ComponentModel.DataAnnotations.Schema;

namespace DADH.Entities
{
    [Table("order_detail")]
    public class Order_Detail : IAuditableEntity
    {
        public long order_id { get; set; }
        public long product_id { get; set; }
        public string? unit_code { get; set; } // mã đon tính
        public string? packing_code { get; set; }// mã quy cách đóng gói
        public double price { get; set; }
        public double quantity { get; set; }
        
    }
}
