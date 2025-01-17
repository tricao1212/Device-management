using Device_management_software.Models.Dtos.Requests.Category;
using Device_management_software.Models.Dtos.Requests.Device;
using Device_management_software.Models.Dtos.Responses.Category;
using Device_management_software.Models.Dtos.Responses.Device;

namespace Device_management_software.Services.Interfaces
{
    public interface IDeviceService
    {
        Task<IEnumerable<DeviceResponse>> GetAll();
        Task<IEnumerable<DeviceResponse>> SearchByNameOrCode(string SearchTerm);
        Task<IEnumerable<DeviceResponse>> FilterByCategory(int CategoryId);
        Task<IEnumerable<DeviceResponse>> FilterByStatus(int StatusValue);
        Task<DeviceResponse> GetById(int Id);
        Task UpdateAsync(DeviceRequest device, int Id);
        Task CreateAsync(DeviceRequest device);
        Task SoftDeleteAsync(int Id);
        Task DeleteAsync(int Id);
    }
}
