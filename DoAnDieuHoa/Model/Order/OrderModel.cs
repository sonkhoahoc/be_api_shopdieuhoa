using DADH.Entities;
using DADH.Model.Order;

namespace DADH.Model
{
    public class OrderModel : IAuditableEntity
    {
        public string note { get; set; }   // mã đơn hàng
        public string code { get; set; }   // mã đơn hàng
        public string customer_adress { get; set; }
        public string customer_name { get; set; }
        public string customer_phone { get; set; }
        public byte status_id { get; set; }   // 1 la moi tao, 2 la hoan thanh, 3  la huy
        public double total_amount { get; set; }  //tổng tiền cần thanh toán = Tiền hàng + tiền ship + tiền lưu kho + tiền bảo hiểm - tiền discount voucher - tiền flashsale
        public string? bank_account { get; set; }
        public string? transaction_code { get; set; }
        public List<Order_Detail> order_lines { get; set; }
        public List<OrderProduct>? products { get; set; }
    }
}
