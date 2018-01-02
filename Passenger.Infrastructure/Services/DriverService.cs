using System;
using Passenger.Core.Domain;
using Passenger.Infrastructure.DTO;
using Passenger.Infrastructure.Repositories;

namespace Passenger.Infrastructure.Services
{
    public class DriverService : IDriverService
    {
        private readonly IDriverRepository _driverRepository;

        public DriverDTO Get(Guid userId)
        {
            var driver = _driverRepository.Get(userId);
            return new DriverDTO
            {
                UserId = driver.UserId,
                Vehicle = driver.Vehicle,
                Routes = driver.Routes,
                DailyRoutes =driver.DailyRoutes
             
            };
            
        }

        public void Register(Guid userId)
        {            
        }
    }
}