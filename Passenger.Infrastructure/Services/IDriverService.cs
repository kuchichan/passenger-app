using System;
using System.Threading.Tasks;
using Passenger.Infrastructure.DTO;

namespace Passenger.Infrastructure.Services
{
    public interface IDriverService : IService
    {
         Task<DriverDTO> GetAsync(Guid userId);
         Task RegisterAsync(Guid userId, string name, int seats, string brand);
    }
}