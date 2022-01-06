using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Ticket_to_ride.Enums;
using Ticket_to_ride.ViewModel;
using Ticket_to_ride.Tools;

namespace Ticket_to_ride.Model
{
    public class GoalCard
    {
        public CityName Origin { get; }
        public CityName Destination { get; }
        public string SourcePath { get; }
        public int PointValue { get; }

        public GoalCard(CityName origin, CityName destination, int points, string sourcePath)
        {
            Origin = origin;
            Destination = destination;
            PointValue = points;
            SourcePath = sourcePath;
        }

    }
}
