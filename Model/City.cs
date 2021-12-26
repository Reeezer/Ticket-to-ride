using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ticket_to_ride.Enums;

namespace Ticket_to_ride.Model
{
    public class City
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
    }
}
