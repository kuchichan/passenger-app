using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using FluentAssertions;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Passenger.API;
using Passenger.Infrastructure.Commands.Users;
using Xunit;

namespace Passenger.Tests.EndToEnd.Controllers
{
    public class AccountControllerTests : ControllerTestsBase
    {
       
        [Fact]
        public async Task given_valid_password_and_new_password_it_should_be_changed()
        {
            
            var command = new ChangeUserPassword
            {
                CurrentPassword = "secret",
                NewPassword = "newPass"
            };

            var payload = GetPayLoad(command);
            var response = await _client.PutAsync("account/password", payload);
            response.StatusCode.ShouldBeEquivalentTo(HttpStatusCode.NoContent);
        }
    }
}