using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ticket_to_ride.Enums;

namespace Ticket_to_ride.Model
{
    public class City : IEquatable<City>
    {
        public CityName Name { get; }
        public double X { get; }
        public double Y { get; }

        public City(CityName name, double x, double y)
        {
            Name = name;
            X = x;
            Y = y;
        }

        public override string ToString()
        {
            return $"{Name}";
        }

        public override bool Equals(object obj)
        {
            return Equals(obj as City);
        }

        public bool Equals(City city2)
        {
            return city2 != null && Name == city2.Name;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Name, X, Y);
        }
    }
}
