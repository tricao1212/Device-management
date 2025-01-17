using Device_management_software.Models.Dtos.Responses.Device;
using Device_management_software.Models.Entities;
using Device_management_software.Repostiories.BaseRepository;

namespace Device_management_software.Repostiories.Interfaces
{
    public interface IDeviceRepository : IRepository<Device>
    {
        Task<IEnumerable<Device>> SearchByNameOrCode(string SearchTerm);
        Task<IEnumerable<Device>> FilterByCategory(int CategoryId);
        Task<IEnumerable<Device>> FilterByStatus(int StatusValue);
    }
}
