using System.ComponentModel.DataAnnotations;

namespace DADH.Entities
{
    public class IAuditableEntity
    {
        [Key]
        public long id { set; get; }
        public long userAdded { set; get; }
        public long? userUpdated { set; get; }
        public DateTime dateAdded { get; set; }=DateTime.Now;
        public DateTime? dateUpdated { get; set; } = DateTime.Now;
        public bool is_delete { get; set; } = false;
    }

}
