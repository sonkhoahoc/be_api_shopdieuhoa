namespace DADH.Model.Product
{
    public class ProductRequestWarehouseModel
    {
        public long warehouse_id { get; set; }
        public long id { get; set; }
        public long product_id { get; set; }
        public string product_name { get; set; }
        public string barcode { get; set; }
        public double price { get; set; }
        public long partner_id { get; set; } = 0;
        public string? partner_name { get; set; }
        public long? product_warehouse_id { get; set; } = 0;
        public string? unit_code { get; set; } // mã đon tính
        public string? packing_code { get; set; }// mã quy cách đóng gói
        public double quantity_stock { set; get; } = 0;// số lượng trong kho

    } 
    public class ProductRequestWarehouseModel2
    {
        public long warehouse_id { get; set; }
        public long id { get; set; }
        public long product_id { get; set; }
        public string product_name { get; set; }
        public string barcode { get; set; }
        public double price { get; set; }
        public decimal import_price { get; set; }
        public long partner_id { get; set; } = 0;
        public string? partner_name { get; set; }
        public long? product_warehouse_id { get; set; } = 0;
        public string? unit_code { get; set; } // mã đon tính
        public string? packing_code { get; set; }// mã quy cách đóng gói
        public double quantity_stock { set; get; } = 0;// số lượng trong kho

    }
}
