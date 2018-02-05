using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Passenger.Core.Domain;

namespace Passenger.Infrastructure.Repositories
{
    public interface IDriverRepository : IRepository
    {
         Task<Driver> GetAsync(Guid userId);
         Task AddAsync(Driver driver);
         Task UpdateAsync(Guid id); 
         Task<IEnumerable<Driver>> GetAllAsync();
    }
}