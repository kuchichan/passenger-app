using System.Net.Http;
using System.Text;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Newtonsoft.Json;
using Passenger.API;

namespace Passenger.Tests.EndToEnd.Controllers
{
    public abstract class ControllerTestsBase
    {
        protected readonly TestServer _server;
        protected readonly HttpClient _client;

        protected ControllerTestsBase()
        {
            _server = new TestServer(new WebHostBuilder()
                .UseStartup<Startup>());
            _client = _server.CreateClient();
        }

        protected static StringContent GetPayLoad(object data)
        {
            var json = JsonConvert.SerializeObject(data);
            //content-type "application/json"
            return new StringContent(json, Encoding.UTF8, "application/json");
        }
    }
}