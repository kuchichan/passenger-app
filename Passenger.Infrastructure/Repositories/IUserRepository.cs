using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Passenger.Core.Domain;

namespace Passenger.Infrastructure.Repositories
{
    public interface IUserRepository : IRepository
    {
         Task<User> GetAsync(Guid id);
         Task<User> GetAsync(string email);
         Task AddAsync(User user);
         Task RemoveAsync(Guid id);
         Task UpdateAsync(Guid id); 
         Task<IEnumerable<User>> GetAllAsync();


    }
}