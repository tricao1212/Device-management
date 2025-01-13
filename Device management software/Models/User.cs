using System.ComponentModel.DataAnnotations;

namespace Device_management_software.Models
{
    public class User : BaseEntity
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Phone { get; set; }
        [Required]
        public Role Role { get; set; }
    }
}
