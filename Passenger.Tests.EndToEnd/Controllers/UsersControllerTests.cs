using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Newtonsoft.Json;
using Passenger.API;
using Passenger.Infrastructure.Commands.Users;
using Passenger.Infrastructure.DTO;
using Xunit;

namespace Passenger.Tests.EndToEnd.Controllers
{
    public class UsersControllerTests
    {
        private readonly TestServer _server;
        private readonly HttpClient _client;

        public UsersControllerTests()
        {
            _server = new TestServer(new WebHostBuilder()
                .UseStartup<Startup>());
            _client = _server.CreateClient();
        }
        [Fact]
        public async Task given_valid_email_user_should_exist()
        {
            var email = "user1@gmail.com";
            var user = await GetUserAsync(email);
            user.Email.ShouldBeEquivalentTo(email);

        }

        [Fact]
        public async Task given_valid_email_user_should_not_exist()
        {
            var email = "user1000@gmail.com";
            var response = await _client.GetAsync($"users/{email}");
            response.StatusCode.ShouldBeEquivalentTo(HttpStatusCode.NotFound);

        }

        [Fact]
        public async Task given_unique_email_user_should_be_created()
        {
            
            var request = new CreateUser
            {
                Email = "test@email.com",
                Username = "test",
                Password = "secret"
            };

            var payload = GetPayLoad(request);
            var response = await _client.PostAsync("users", payload);
            response.StatusCode.ShouldBeEquivalentTo(HttpStatusCode.Created);
            response.Headers.Location.ToString().ShouldBeEquivalentTo($"users/{request.Email}");

            var user = await GetUserAsync(request.Email);
            user.Email.ShouldBeEquivalentTo(request.Email);

        }

        private async Task<UserDTO> GetUserAsync(string email)
        {
            var response = await _client.GetAsync($"users/{email}");
            var responseString = await response.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<UserDTO>(responseString);
        }

        private static StringContent GetPayLoad(object data)
        {
            var json = JsonConvert.SerializeObject(data);
            //content-type "application/json"
            return new StringContent(json, Encoding.UTF8, "application/json");
        }

    }


}