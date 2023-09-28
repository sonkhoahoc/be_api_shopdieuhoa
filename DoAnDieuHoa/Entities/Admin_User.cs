using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DADH.Entities
{
    [Table("admin_user")]
    public class Admin_User : IAuditableEntity
    {
        [StringLength(50)]
        public string username { get; set; } = string.Empty;
        [StringLength(50)]
        public string password { get; set; } = string.Empty;
        [StringLength(50)]
        public string pass_code { set; get; } = string.Empty;
        [StringLength(50)]
        public string email { get; set; } = string.Empty;
        [StringLength(12)]
        public string phone_number { get; set; } = string.Empty;

        [StringLength(50)]
        public string full_name { get; set; } = string.Empty;
        [StringLength(500)]
        public string address { get; set; } = string.Empty;
        public DateTime birthday { set; get; }
        public byte sex { set; get; }
        public bool is_active { set; get; }

    }
}
