using System;
using System.Collections.Generic;
using Passenger.Core.Domain;

namespace Passenger.Infrastructure.Repositories
{
    public interface IUserRepository
    {
         User Get(Guid id);
         User Get(string email);
         void Add(User user);
         void Remove(Guid id);
         void Update(Guid id); 
         IEnumerable<User> GetAll();


    }
}