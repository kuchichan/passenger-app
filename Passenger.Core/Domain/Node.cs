using System;
using System.Text.RegularExpressions;

namespace Passenger.Core.Domain
{
    public class Node
    {
        public static readonly Regex _nameRegex = new Regex("^(?![_.])(?!.*[_.-]{2})[a-zA-Z0-9._.-]+(?<![_.-])$");
        public string Address { get; protected set; }
        public double Longitude { get; protected set; }
        public double Latitude { get; protected set; }

        public DateTime UpdatedAt { get; protected set; }

        public Node(string address, double longitude, double latitude)
        {
            SetLongitude(longitude);
            SetLatitude(latitude);
            SetAddress(address);
        }
        public void SetAddress(string address)
        {
            if(!_nameRegex.IsMatch(address))
                throw new Exception("Entered address is invalid");
            
            Address = address;
            UpdatedAt = DateTime.UtcNow;
        }

        public void SetLongitude(double longitude)
        {
            if(longitude >= -180.0 && longitude <= 180.0)
            {
                Longitude = longitude;
            }
            else
            {
                throw new Exception("Logitude should be between -180 and 180 degrees.");
            }

        }
        public void SetLatitude(double latitude)
        {
            if(latitude >= -90 && latitude <= 90)
            {
                Latitude = latitude;
            }
            else
            {
                throw new Exception("Logitude should be between -180 and 180 degrees.");
            }

        }

        public static Node Create(string address, double longitude, double latitude)
            => new Node(address,longitude,latitude);
    }
}