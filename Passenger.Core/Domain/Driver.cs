using System;
using System.Collections.Generic;

namespace Passenger.Core.Domain
{
    public class Driver
    // Aggregate root
    {
        public Guid Id { get; protected set; }
        public Guid UserId { get; protected set; }
        public Vehicle Vehicle { get; protected set; }
        public IEnumerable<Route> Routes { get; protected set; }
        public IEnumerable<DailyRoute> DailyRoutes { get; protected set; }
    
        protected Driver()
        { 
        }
    
        public Driver(Guid id, Guid userid)
        {
            Id = id;
            UserId = userid;
        }
    
        public void SetVehicle(string brand,string name, int seats)
        {
            Vehicle = new Vehicle(brand,name,seats);
        }
    }    
}