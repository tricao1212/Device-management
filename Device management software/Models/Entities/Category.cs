using System.ComponentModel.DataAnnotations;
using Device_management_software.Models.Commons;

namespace Device_management_software.Models.Entities
{
    public class Category : BaseEntity
    {
        public string Name { get; set; }
        public ICollection<Device> Devices { get; set; } = new List<Device>();
    }
}
