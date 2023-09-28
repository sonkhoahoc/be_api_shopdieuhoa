using DADH.Entities;

namespace DADH.Model.Product
{
    public class PartnerModel : IAuditableEntity
    {
        public long id_ecom { get; set; }
        public string? code { get; set; }
        public string? name { get; set; }
        public string? phone { set; get; }
        public int? province_code { get; set; }  // code tỉnh

        public string? website { set; get; }
        public string? email { get; set; } = string.Empty;
        public string? taxcode { get; set; } = string.Empty;
        public string? introduce { get; set; } = string.Empty;
    }
}
