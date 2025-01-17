using Device_management_software.Models.Commons;
using Device_management_software.Models.Enums;

namespace Device_management_software.Models.Dtos.Responses.Device
{
    public class DeviceResponse : BaseEntity
    {
        public string Name { get; set; }
        public string Code { get; set; }
        public CategoryDto Category {  get; set; } 
        public Status Status { get; set; }
    }
}
