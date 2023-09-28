using System.ComponentModel.DataAnnotations;

namespace DADH.Model.User
{
    public class UserModel
    {
        public long id { set; get; }

        [StringLength(50)]
        public string username { get; set; } = string.Empty;


        [StringLength(50)]
        public string email { get; set; } = string.Empty;
        [StringLength(12)]
        public string phone_number { get; set; } = string.Empty;
        [StringLength(50)]
        public string full_name { get; set; } = string.Empty;

        [StringLength(250)]
        public string address { get; set; } = string.Empty;
        public DateTime birthday { set; get; }
        public byte sex { set; get; }
        public bool is_active { set; get; }
        public long userAdded { set; get; }
        public long? userUpdated { set; get; }

    }
}
