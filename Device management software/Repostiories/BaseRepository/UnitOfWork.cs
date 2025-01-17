using Device_management_software.Data;
using Device_management_software.Repostiories.Implements;
using Device_management_software.Repostiories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Device_management_software.Repostiories.BaseRepository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DbContext _context;
        public UnitOfWork(DeviceManagementContext context)
        {
            _context = context;

        }
        private DeviceRepository _deviceRepository;
        private UserRepository _userRepository;
        private CategoryRepository _categoryRepository;

        public IDeviceRepository DeviceRepository
        {
            get
            {
                return _deviceRepository ??= new(_context);
            }
        }

        public IUserRepository UserRepository
        {
            get
            {
                return _userRepository ??= new(_context);
            }
        }

        public ICategoryRepostiory CategoryRepostiory
        {
            get
            {
                return _categoryRepository ??= new(_context);
            }
        }
    }
}
