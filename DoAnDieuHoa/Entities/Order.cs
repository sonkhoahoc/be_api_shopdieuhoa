using System.ComponentModel.DataAnnotations.Schema;

namespace DADH.Entities
{
    [Table("order")]
    public class Order : IAuditableEntity
    {
        public string note { get; set; }   // mã đơn hàng
        public string code { get; set; }   // mã đơn hàng
        public string customer_adress { get; set; }
        public string customer_name { get; set; }
        public string customer_phone { get; set; }
        public byte status_id { get; set; }   // 1 la moi tao, 2 la hoan thanh, 3  la huy
        public double total_amount { get; set; }  //tổng tiền cần thanh toán 
        public string? bank_account { get; set; }
        public string? transaction_code { get; set; }
    }
}
