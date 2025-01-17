using Device_management_software.Repostiories.Interfaces;

namespace Device_management_software.Repostiories.BaseRepository
{
    public interface IUnitOfWork
    {
        IDeviceRepository DeviceRepository { get; }
        IUserRepository UserRepository { get; }
        ICategoryRepostiory CategoryRepostiory { get; }
    }
}
