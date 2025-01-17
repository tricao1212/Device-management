using Device_management_software.Models.Commons;
using Device_management_software.Models.Enums;

namespace Device_management_software.Models.Dtos.Responses.User
{
    public class UserResponse : BaseEntity
    {
        public string UserName { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public Role Role { get; set; }
    }
}
