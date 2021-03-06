using System;
using System.Collections.Generic;

namespace Passenger.Core.Domain
{
    public class Driver
    // Aggregate root
    {
        public Guid UserId { get; protected set; }
        public Vehicle Vehicle { get; protected set; }
        public IEnumerable<Route> Routes { get; protected set; }
        public IEnumerable<DailyRoute> DailyRoutes { get; protected set; }
        public DateTime UpdatedAt {get; private set;}
    
        protected Driver()
        { 
        }
    
        public Driver(Guid userId, Vehicle vehicle)
        {
            UserId = userId;
            Vehicle = vehicle;
        }

    
    
    }    
}