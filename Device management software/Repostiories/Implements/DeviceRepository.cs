using Device_management_software.Models.Dtos.Responses.Device;
using Device_management_software.Models.Entities;
using Device_management_software.Models.Enums;
using Device_management_software.Repostiories.BaseRepository;
using Device_management_software.Repostiories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Device_management_software.Repostiories.Implements
{
    public class DeviceRepository : Repository<Device>, IDeviceRepository
    {
        public DeviceRepository(DbContext dbContext) : base(dbContext)
        {
        }

        public async Task<IEnumerable<Device>> FilterByCategory(int CategoryId)
        {
            return await _dbSet.Where(x => x.CategoryId == CategoryId).ToListAsync();
        }

        public async Task<IEnumerable<Device>> FilterByStatus(int StatusValue)
        {
            var status = (Status)StatusValue;
            return await _dbSet.Where(x => x.Status == status).ToListAsync();
        }

        public override async Task<IEnumerable<Device>> GetAllAsync()
        {
            return await _dbSet.Include(x => x.Category).ToListAsync();
        }

        public override async Task<Device> GetByIdAsync(int id)
        {
            return await _dbSet.Include(x => x.Category)
                               .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<IEnumerable<Device>> SearchByNameOrCode(string SearchTerm)
        {
            return await _dbSet.Include(x => x.Category).Where(x => x.Name.Contains(SearchTerm) || x.Code.Contains(SearchTerm))
                               .ToListAsync();
        }
    }
}
