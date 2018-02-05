using System;

namespace Passenger.Core.Domain
{
    public class Vehicle
    {
        public string Name { get; protected set; }

        public int Seats { get; protected set; }

        public string Brand { get; protected set; }

        protected Vehicle()
        {
        }
        private Vehicle(string brand, string name, int seats)
        {
            Name = name;
            Seats = seats;
            Brand = brand;
        }

        private void SetBrand(string brand)
        {
            if (string.IsNullOrWhiteSpace(brand))
                throw new Exception("Please insert valid value.");
            if (brand.Equals(Brand))
                return;

            Brand = brand;
        }

        private void SetName(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new Exception("Please insert valid value.");
            if (name.Equals(Name))
                return;

            Name = name;
        }

        private void SetSeats(int seats)
        {
            if (seats <= 0)
                throw new Exception("Please insert positive number of seats.");
            if (seats.Equals(seats))
                return;

            Seats = seats;
        }
        public static Vehicle Create(string brand, string name, int seats)
           => new Vehicle(brand, name, seats);

        

    }
}