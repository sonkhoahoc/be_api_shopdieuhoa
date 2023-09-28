using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DADH.Entities
{
    [Table("category_product")]
    public class Category_Product : IAuditableEntity
    {
        [StringLength(20)]
        public string code { get; set; } = string.Empty;
        [StringLength(250)]
        public string name { set; get; } = string.Empty;
        [StringLength(1500)]
        public string note { set; get; } = string.Empty;
        public long parent_id { get; set; }                         //Chuyên mục cha
        public int order { set; get; }
        public byte status_id { set; get; }
    }
}
    