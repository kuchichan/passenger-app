using System.Threading.Tasks;
using Passenger.Infrastructure.Commands;
using Passenger.Infrastructure.Commands.Drivers;
using Passenger.Infrastructure.Services;

namespace Passenger.Infrastructure.Handlers.Drivers
{
    public class CreateDriverHandler : ICommandHandler<CreateDriver>
    {
        private readonly IDriverService _driverService;

        public CreateDriverHandler(IDriverService driverService)
        {
            _driverService = driverService;
        }
        public async Task HandleAsync(CreateDriver command)
        {
            await _driverService.RegisterAsync(command.UserId, command.Vehicle.Name, command.Vehicle.Seats,
            command.Vehicle.Brand);
        }
    }
}