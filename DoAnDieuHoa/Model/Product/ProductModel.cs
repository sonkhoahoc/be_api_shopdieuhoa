using DADH.Entities;

namespace DADH.Model.Product
{
    public class ProductViewModel
    {
        public long id { set; get; }
        public long userAdded { set; get; }
        public long? userUpdated { set; get; }
        public DateTime dateAdded { get; set; }
        public string code { get; set; } = string.Empty;
        public string avata { get; set; } = string.Empty;
        public string? name { get; set; }
        public string? note { get; set; }
        public bool is_active { get; set; }
        public double price { get; set; } = 0;
        public string? barcode { get; set; }
        public string? unit_code { get; set; } // mã đon tính
        public string? packing_code { get; set; }// mã quy cách đóng gói
    }

    public class ProductModel
    {
        public long id { set; get; }
        public long userAdded { set; get; }
        public long? userUpdated { set; get; }
        public DateTime dateAdded { get; set; }
        public DateTime? dateUpdated { get; set; }
        public bool is_delete { get; set; } = false;
        public string code { get; set; } = string.Empty;
        public string avata { get; set; } = string.Empty;
        public string? name { get; set; }
        public string? note { get; set; }
        public bool is_active { get; set; }
        public string? unit_code { get; set; } // mã đon tính
        public string? packing_code { get; set; }// mã quy cách đóng gói
        public double price { get; set; } = 0;
        public string? barcode { get; set; }
    }

    public class ProductSearchModel
    {
        public string? keyword { set; get; }
        public DateTime? start_date { set; get; }
        public DateTime? end_date { set; get; }
        public int page_size { set; get; }
        public int page_number { set; get; }

    }
}
