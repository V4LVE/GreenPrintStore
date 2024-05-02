using GreenPrint.Blazor.Models;
using GreenPrint.Blazor.Service.Intefaces;
using System.Net.Http.Json;

namespace GreenPrint.Blazor.Service.Services
{
    public class UserService : IUserService
    {

        private readonly HttpClient _client;

        public UserService(HttpClient client)
        {
            _client = client;
        }

        public async Task<User> CreateUser(User user)
        {
            var response = await _client.PostAsJsonAsync("/User/create", user);

            response.EnsureSuccessStatusCode();

            return await response.Content.ReadFromJsonAsync<User>();
        }


    }
}
