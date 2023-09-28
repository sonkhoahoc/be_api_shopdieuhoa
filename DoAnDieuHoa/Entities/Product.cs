using System.ComponentModel.DataAnnotations.Schema;

namespace DADH.Entities
{
    [Table("product")]
    public class Product : IAuditableEntity
    {
        public string code { get; set; } = string.Empty;
        public string avata { get; set; }
        public string? name { get; set; }
        public string? note { get; set; }
        public bool is_active { get; set; }
        public string? barcode { get; set; }
        public string? unit_code { get; set; } // mã đon tính
        public string? packing_code { get; set; }// mã quy cách đóng gói
        public double price { get; set; } = 0;

    }
}
