using System;
using System.Threading.Tasks;
using AutoMapper;
using Passenger.Core.Domain;
using Passenger.Infrastructure.DTO;
using Passenger.Infrastructure.Repositories;

namespace Passenger.Infrastructure.Services
{
    public class DriverService : IDriverService
    {
        private readonly IDriverRepository _driverRepository;
        private readonly IMapper _mapper;

        public DriverService(IDriverRepository repository, IMapper mapper)
        {
            _driverRepository = repository;
            _mapper = mapper;
        }

        public async Task<DriverDTO> GetAsync(Guid userId)
        {
            var driver = await _driverRepository.GetAsync(userId);
            return _mapper.Map<Driver,DriverDTO>(driver);
            
        }

        public async Task RegisterAsync(Guid userId)
        {
            await Task.CompletedTask;            
        }
    }
}