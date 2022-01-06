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
        public City Origin { get; }
        public City Destination { get; }
        public string SourcePath { get; }
        public int PointValue { get; }

        public GoalCard(City origin, City destination, int points, string sourcePath)
        {
            Origin = origin;
            Destination = destination;
            PointValue = points;
            SourcePath = sourcePath;
        }

        public override string ToString()
        {
            return $"{Origin} - {Destination} ({PointValue} points)";
        }
    }
}
