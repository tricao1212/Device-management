using Device_management_software.Models.Entities;
using Device_management_software.Models.Enums;
using System.ComponentModel.DataAnnotations;

namespace Device_management_software.Models.Dtos.Requests.Device
{
    public class DeviceRequest
    {
        [Required]
        public string Name { get; set; } = null!;

        [Required]
        public string Code { get; set; } = null!;

        [Required]  
        public int CategoryId { get; set; }

        [Required]
        public Status Status { get; set; }
    }
}
