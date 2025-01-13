using System.ComponentModel.DataAnnotations;

namespace Device_management_software.Models
{
    public class Category : BaseEntity
    {
        [Required]
        public string Name { get; set; }
        public ICollection<Device> Devices { get; set; }
    }
}
