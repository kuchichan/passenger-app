using System;

namespace Passenger.Infrastructure.Commands.Drivers
{
    public class CreateDriver : ICommand
    {
        public Guid UserId { get; set; }
        public DriverVehicle Vehicle{ get; set;}

        public class DriverVehicle
        {
            public string Name { get; set; }
            public int Seats { get; set; }
            public string  Brand { get; set; }
        }
    }
}