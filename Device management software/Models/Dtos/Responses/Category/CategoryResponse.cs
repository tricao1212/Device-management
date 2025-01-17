using Device_management_software.Models.Commons;
using Device_management_software.Models.Dtos.Responses.Device;

namespace Device_management_software.Models.Dtos.Responses.Category
{
    public class CategoryResponse : BaseEntity
    {
        public string Name { get; set; }
        public List<DeviceResponse> Devices { get; set; } = new List<DeviceResponse>();
    }
}
