using System;
using Passenger.Infrastructure.DTO;

namespace Passenger.Infrastructure.Services
{
    public interface IDriverService
    {
         DriverDTO Get(Guid userId);
         void Register(Guid userId);
    }
}