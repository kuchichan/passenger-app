using AutoMapper;
using Passenger.Core.Domain;
using Passenger.Infrastructure.DTO;

namespace Passenger.Infrastructure.Mappers
{
    public class AutoMapperConfig
    {
        public static IMapper Initialize()
         => new MapperConfiguration(cfg =>
           {
               cfg.CreateMap<User, UserDTO>();
               cfg.CreateMap<Driver, DriverDTO>();

           })
           .CreateMapper();
    }
}