using System.ComponentModel.DataAnnotations;

namespace Device_management_software.Models.Dtos.Requests.Category
{
    public class CategoryRequest
    {
        [Required]
        public string Name { get; set; } = null!;
    }
}
