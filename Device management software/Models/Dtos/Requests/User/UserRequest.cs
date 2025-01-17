using Device_management_software.Models.Enums;
using System.ComponentModel.DataAnnotations;

namespace Device_management_software.Models.Dtos.Requests.User
{
    public class UserRequest
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; } = null!;

        [Required]
        public string Name { get; set; } = null!;

        [Required]
        [Phone]
        public string Phone { get; set; } = null!;

        [Required]
        public Role Role { get; set; }
    }
}
