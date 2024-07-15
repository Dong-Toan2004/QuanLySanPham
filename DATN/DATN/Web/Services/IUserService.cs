using Datn.Application.DataTransferObj;
using Datn.Domain.Database.Entities;

namespace Web.Services
{
    public interface IUserService 
    {
        Task<IEnumerable<UserDto>> GetAll();
        Task<UserDto> GetById(Guid id);
        Task<bool> Create(UserCreateRequest userCreateRequest);
        Task<bool> Update(Guid id,UserUpdateRequest userUpdateRequest);
        Task<bool> Delete(Guid id);
        Task<bool> Login(LoginRequest loginRequest);
    }
}
