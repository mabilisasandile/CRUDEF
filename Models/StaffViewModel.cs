using System.ComponentModel.DataAnnotations;

namespace CRUDEF.Models
{
    public class StaffViewModel
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public int StaffNumber { get; set; }
        public string JobTitle { get; set; }
        [EmailAddress]
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
    }
}
