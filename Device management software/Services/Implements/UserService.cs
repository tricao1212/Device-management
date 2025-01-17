using Device_management_software.Models.Dtos.Requests.User;
using Device_management_software.Models.Dtos.Responses.User;
using Device_management_software.Models.Entities;
using Device_management_software.Repostiories.BaseRepository;
using Device_management_software.Services.Interfaces;

namespace Device_management_software.Services.Implements
{
    public class UserService : BaseService, IUserService
    {
        public UserService(IUnitOfWork _unitOfWork) : base(_unitOfWork)
        {
        }
        public async Task DeleteAsync(int Id)
        {
            var user = await _unitOfWork.UserRepository.GetByIdAsync(Id);
            await _unitOfWork.UserRepository.DeleteAsync(user);
        }

        public async Task<IEnumerable<UserResponse>> GetAll()
        {
            var users = await _unitOfWork.UserRepository.GetAllAsync();
            return users.Select(p => new UserResponse
            {
                Id = p.Id,
                Name = p.Name,
                Email = p.Email,
                Phone = p.Phone,
                Role = p.Role,
                CreatedAt = p.CreatedAt,
                UpdatedAt = p.UpdatedAt,
                CreatedBy = p.CreatedBy,
                UpdatedBy = p.UpdatedBy
            });
        }

        public async Task<UserResponse> GetById(int Id)
        {
            var user = await _unitOfWork.UserRepository.GetByIdAsync(Id);
            return new UserResponse
            {
                Id = user.Id,
                Name = user.Name,
                Email = user.Email,
                Phone = user.Phone,
                Role = user.Role,
                CreatedAt = user.CreatedAt,
                UpdatedAt = user.UpdatedAt,
                CreatedBy = user.CreatedBy,
                UpdatedBy = user.UpdatedBy
            };
        }

        public async Task Register(UserRequest user)
        {
            var userReq = new User
            {
                Name = user.Name,
                Email = user.Email,
                Phone = user.Phone,
                Role = user.Role
            };
            await _unitOfWork.UserRepository.CreateAsync(userReq);
        }

        public Task SoftDeleteAsync(int Id)
        {
            throw new NotImplementedException();
        }

        public async Task UpdateAsync(UserRequest user, int id)
        {
            var userReq = await _unitOfWork.UserRepository.GetByIdAsync(id);
            userReq.Name = user.Name;
            userReq.Email = user.Email;
            userReq.Phone = user.Phone;
            userReq.Role = user.Role;

            await _unitOfWork.UserRepository.UpdateAsync(userReq);
        }
    }
}
