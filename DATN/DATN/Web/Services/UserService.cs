using Datn.Application.DataTransferObj;

namespace Web.Services
{
    public class UserService : IUserService
    {
        private readonly HttpClient httpClient;

        public UserService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }
        public async Task<bool> Create(UserCreateRequest userCreateRequest)
        {
            var userDto = await httpClient.PostAsJsonAsync("api/User/create", userCreateRequest);
            return userDto.IsSuccessStatusCode;
        }

        public async Task<bool> Delete(Guid id)
        {
            var userDto = await httpClient.DeleteAsync($"api/User/delete?id={id}");
            return userDto.IsSuccessStatusCode;
        }

        public async Task<IEnumerable<UserDto>> GetAll()
        {
            var userDto = await httpClient.GetFromJsonAsync<IEnumerable<UserDto>>("api/User");
            return userDto;
        }

        public async Task<UserDto> GetById(Guid id)
        {
            var userDto = await httpClient.GetFromJsonAsync<UserDto>($"api/User/{id}");
            return userDto;
        }

        public async Task<bool> Login(LoginRequest loginRequest)
        {
            var login = await httpClient.PostAsJsonAsync("api/Login/login", loginRequest);
            return login.IsSuccessStatusCode;
        }

        public async Task<bool> Update(Guid id, UserUpdateRequest userUpdateRequest)
        {
            var userDto = await httpClient.PutAsJsonAsync($"api/User/update?id={id}", userUpdateRequest);
            return userDto.IsSuccessStatusCode;
        }
    }
}
