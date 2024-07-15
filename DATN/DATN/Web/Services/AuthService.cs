using Datn.Application.DataTransferObj;
using Microsoft.AspNetCore.Components.Authorization;
using System.Net.Http.Headers;
using System.Net.Http;
using System.Text.Json;
using Blazored.LocalStorage;

namespace Web.Services
{
    public class AuthService : IAuthService
    {
        private readonly HttpClient httpClient;
        private readonly AuthenticationStateProvider authenticationStateProvider;
        private readonly ILocalStorageService localStorage;

        public AuthService(HttpClient httpClient, AuthenticationStateProvider authenticationStateProvider,ILocalStorageService localStorage)
        {
            this.httpClient = httpClient;
            this.authenticationStateProvider = authenticationStateProvider;
            this.localStorage = localStorage;
        }
        public async Task<LoginResponse> Login(LoginRequest loginRequest)
        {
            var result = await httpClient.PostAsJsonAsync("api/Login/login", loginRequest);
            var content = await result.Content.ReadAsStringAsync();
            var loginResponse = JsonSerializer.Deserialize<LoginResponse>(content,
                new JsonSerializerOptions()
                {
                    PropertyNameCaseInsensitive = true
                });
            if (!result.IsSuccessStatusCode)
            {
                return loginResponse;
            }
            await localStorage.SetItemAsync("authToken", loginResponse.Token);
            ((ApiAuthenticationStateProvider)authenticationStateProvider).MarkUserAsAuthenticated(loginRequest.UserName);
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", loginResponse.Token);
            return loginResponse;
        }

        public Task Logout()
        {
            throw new NotImplementedException();
        }
    }
}
