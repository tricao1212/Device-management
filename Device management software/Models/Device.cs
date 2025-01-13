using System.ComponentModel.DataAnnotations;

namespace Device_management_software.Models
{
    public class Device : BaseEntity
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Code { get; set; } 
        public int CategoryId { get; set; }
        public Category Category { get; set; }
        [Required]
        public Status Status { get; set; }
    }
}
