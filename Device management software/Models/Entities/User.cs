using System.ComponentModel.DataAnnotations;
using Device_management_software.Models.Commons;
using Device_management_software.Models.Enums;

namespace Device_management_software.Models.Entities
{
    public class User : BaseEntity
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public Role Role { get; set; }
    }
}
