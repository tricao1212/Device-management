using Device_management_software.Models.Dtos.Requests.Category;
using Device_management_software.Models.Dtos.Responses.Category;
using Device_management_software.Models.Dtos.Responses.Device;
using Device_management_software.Models.Entities;
using Device_management_software.Repostiories.BaseRepository;
using Device_management_software.Services.Interfaces;

namespace Device_management_software.Services.Implements
{
    public class CategoryService : BaseService, ICategoryService
    {
        public CategoryService(IUnitOfWork _unitOfWork) : base(_unitOfWork)
        {
        }

        public async Task CreateAsync(CategoryRequest category)
        {
            var categoryReq = new Category
            {
                Name = category.Name,
            };
            await _unitOfWork.CategoryRepostiory.CreateAsync(categoryReq);
        }

        public async Task DeleteAsync(int Id)
        {
            var category = await _unitOfWork.CategoryRepostiory.GetByIdAsync(Id);
            await _unitOfWork.CategoryRepostiory.DeleteAsync(category);
        }

        public async Task<IEnumerable<CategoryResponse>> GetAll()
        {
            var categories = await _unitOfWork.CategoryRepostiory.GetAllAsync();

            return categories.Select(category => new CategoryResponse
            {
                Id = category.Id,
                Name = category.Name,
                CreatedAt = category.CreatedAt,
                UpdatedAt = category.UpdatedAt,
                CreatedBy = category.CreatedBy,
                UpdatedBy = category.UpdatedBy
            });
        }

        public async Task<CategoryResponse> GetById(int Id)
        {
            var category = await _unitOfWork.CategoryRepostiory.GetByIdAsync(Id);
            return new CategoryResponse
            {
                Id = category.Id,
                Name = category.Name,
                CreatedAt = category.CreatedAt,
                UpdatedAt = category.UpdatedAt,
                CreatedBy = category.CreatedBy,
                UpdatedBy = category.UpdatedBy
            };
        }

        public Task SoftDeleteAsync(int Id)
        {
            throw new NotImplementedException();
        }

        public async Task UpdateAsync(CategoryRequest category, int Id)
        {
            var categoryReq = await _unitOfWork.CategoryRepostiory.GetByIdAsync(Id);
            categoryReq.Name = category.Name;

            await _unitOfWork.CategoryRepostiory.UpdateAsync(categoryReq);
        }
    }
}
