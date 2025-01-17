using Device_management_software.Models.Commons;

namespace Device_management_software.Repostiories.BaseRepository
{
    public interface IRepository<T> where T : BaseEntity
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task<T?> GetByIdAsync(int id);
        Task CreateAsync(params T[] entities);
        Task UpdateAsync(params T[] entities);
        Task DeleteAsync(params T[] entities);
        Task SoftDeleteAsync(params T[] entities);
    }
}
