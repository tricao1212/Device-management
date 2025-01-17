using System.ComponentModel.DataAnnotations;
using Device_management_software.Models.Commons;
using Device_management_software.Models.Enums;

namespace Device_management_software.Models.Entities
{
    public class Device : BaseEntity
    {
        public string Name { get; set; }
        public string Code { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
        public Status Status { get; set; }
    }
}
