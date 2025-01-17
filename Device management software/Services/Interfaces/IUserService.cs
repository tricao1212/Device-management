using Device_management_software.Models.Dtos.Requests.User;
using Device_management_software.Models.Dtos.Responses.User;

namespace Device_management_software.Services.Interfaces
{
    public interface IUserService
    {
        Task<IEnumerable<UserResponse>> GetAll();
        Task<UserResponse> GetById(int Id);
        Task UpdateAsync(UserRequest user, int id);
        Task Register(UserRequest user);
        Task SoftDeleteAsync(int Id);
        Task DeleteAsync(int Id);
    }
}
