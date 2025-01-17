using Device_management_software.Models.Dtos.Requests.Category;
using Device_management_software.Models.Dtos.Requests.User;
using Device_management_software.Models.Dtos.Responses.Category;
using Device_management_software.Models.Dtos.Responses.User;

namespace Device_management_software.Services.Interfaces
{
    public interface ICategoryService
    {
        Task<IEnumerable<CategoryResponse>> GetAll();
        Task<CategoryResponse> GetById(int Id);
        Task CreateAsync(CategoryRequest category);
        Task UpdateAsync(CategoryRequest category, int Id);
        Task SoftDeleteAsync(int Id);
        Task DeleteAsync(int Id);
    }
}
