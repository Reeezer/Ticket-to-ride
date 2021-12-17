using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Ticket_to_ride.Enums;
using Ticket_to_ride.ViewModel;

namespace Ticket_to_ride.Model
{
    public class GoalCard
    {
        public CityName Origin { get; set; }
        public CityName Destination { get; set; }
        public int PointValue { get; set; }

        public GoalCard(CityName origin, CityName destination, int points)
        {
            Origin = origin;
            Destination = destination;
            PointValue = points;
        }
    }
}
