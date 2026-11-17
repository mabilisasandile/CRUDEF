using System.ComponentModel.DataAnnotations;

namespace CRUDEF.Entities
{
    public class Staff
    {
        public int Id { get; set; }
        [StringLength(300)]
        public string Name { get; set; }
        [MaxLength(10)]
        public int StaffNumber { get; set; }
        [StringLength(255)]
        public string JobTitle { get; set; }
        [StringLength(255)]
        public string Email { get; set; }
        [StringLength(25)]
        public string Phone { get; set; }
        [StringLength(255)]
        public string Address { get; set; }
    }
}
