using Device_management_software.Models.Dtos.Requests.Device;
using Device_management_software.Models.Dtos.Responses.Device;
using Device_management_software.Models.Entities;
using Device_management_software.Repostiories.BaseRepository;
using Device_management_software.Services.Interfaces;

namespace Device_management_software.Services.Implements
{
    public class DeviceService : BaseService, IDeviceService
    {
        public DeviceService(IUnitOfWork _unitOfWork) : base(_unitOfWork)
        {
        }

        public async Task CreateAsync(DeviceRequest device)
        {
            var deviceReq = new Device
            {
                Name = device.Name,
                CategoryId = device.CategoryId,
                Code = device.Code,
                Status = device.Status,
            };
            await _unitOfWork.DeviceRepository.CreateAsync(deviceReq);
        }

        public async Task DeleteAsync(int Id)
        {
            var device = await _unitOfWork.DeviceRepository.GetByIdAsync(Id);
            await _unitOfWork.DeviceRepository.DeleteAsync(device);
        }

        public async Task<IEnumerable<DeviceResponse>> FilterByCategory(int CategoryId)
        {
            var devices = await _unitOfWork.DeviceRepository.FilterByCategory(CategoryId);

            return devices.Select(p => new DeviceResponse
            {
                Id = p.Id,
                Name = p.Name,
                Code = p.Code,
                Category = new CategoryDto
                {
                    Id = p.CategoryId,
                    Name = p.Category.Name
                },
                Status = p.Status,
                CreatedAt = p.CreatedAt,
                CreatedBy = p.CreatedBy,
                UpdatedAt = p.UpdatedAt,
                UpdatedBy = p.UpdatedBy
            });
        }

        public async Task<IEnumerable<DeviceResponse>> FilterByStatus(int StatusValue)
        {
            var devices = await _unitOfWork.DeviceRepository.FilterByStatus(StatusValue);

            return devices.Select(p => new DeviceResponse
            {
                Id = p.Id,
                Name = p.Name,
                Code = p.Code,
                Category = new CategoryDto
                {
                    Id = p.CategoryId,
                    Name = p.Category.Name
                },
                Status = p.Status,
                CreatedAt = p.CreatedAt,
                CreatedBy = p.CreatedBy,
                UpdatedAt = p.UpdatedAt,
                UpdatedBy = p.UpdatedBy
            });
        }

        public async Task<IEnumerable<DeviceResponse>> GetAll()
        {
            var devices = await _unitOfWork.DeviceRepository.GetAllAsync();

            return devices.Select(p => new DeviceResponse
            {
                Id = p.Id,
                Name = p.Name,
                Code = p.Code,
                Category = new CategoryDto
                {
                    Id = p.CategoryId,
                    Name = p.Category.Name
                },
                Status = p.Status,
                CreatedAt = p.CreatedAt,
                CreatedBy = p.CreatedBy,
                UpdatedAt = p.UpdatedAt,
                UpdatedBy = p.UpdatedBy
            });
        }

        public async Task<DeviceResponse> GetById(int Id)
        {
            var deivce = await _unitOfWork.DeviceRepository.GetByIdAsync(Id);
            return new DeviceResponse
            {
                Id = deivce.Id,
                Name = deivce.Name,
                Code = deivce.Code,
                Category = new CategoryDto
                {
                    Id = deivce.Category.Id,
                    Name = deivce.Category.Name
                },
                Status = deivce.Status,
                CreatedAt = deivce.CreatedAt,
                CreatedBy = deivce.CreatedBy,
                UpdatedAt = deivce.UpdatedAt,
                UpdatedBy = deivce.UpdatedBy
            };
        }

        public async Task<IEnumerable<DeviceResponse>> SearchByNameOrCode(string SearchTerm)
        {
            var devices = await _unitOfWork.DeviceRepository.SearchByNameOrCode(SearchTerm);

            return devices.Select(p => new DeviceResponse
            {
                Id = p.Id,
                Name = p.Name,
                Code = p.Code,
                Category = new CategoryDto
                {
                    Id = p.CategoryId,
                    Name = p.Category.Name
                },
                Status = p.Status,
                CreatedAt = p.CreatedAt,
                CreatedBy = p.CreatedBy,
                UpdatedAt = p.UpdatedAt,
                UpdatedBy = p.UpdatedBy
            });
        }

        public Task SoftDeleteAsync(int Id)
        {
            throw new NotImplementedException();
        }

        public async Task UpdateAsync(DeviceRequest device, int Id)
        {
            var deviceReq = await _unitOfWork.DeviceRepository.GetByIdAsync(Id);

            deviceReq.Name = device.Name;
            deviceReq.CategoryId = device.CategoryId;
            deviceReq.Code = device.Code;
            deviceReq.Status = device.Status;

            await _unitOfWork.DeviceRepository.UpdateAsync(deviceReq);
        }
    }
}
