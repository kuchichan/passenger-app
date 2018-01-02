using System;
using System.Collections.Generic;
using Passenger.Core.Domain;

namespace Passenger.Infrastructure.Repositories
{
    public interface IDriverRepository
    {
         Driver Get(Guid userId);
         void Add(Driver driver);
         void Update(Guid id); 
         IEnumerable<Driver> GetAll();
    }
}