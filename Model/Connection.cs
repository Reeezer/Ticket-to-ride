using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Ticket_to_ride.Enums;
using Ticket_to_ride.Model;
using Ticket_to_ride.ViewModel;
using Ticket_to_ride.Tools;

namespace Ticket_to_ride.Model
{
    public class Connection
    {
        public City Origin { get; }
        public City Destination { get; }
        public TrainColor Color { get; }
        public PlayerColor PlayerColor { get; set; } = PlayerColor.None;
        public int Length { get; }
        public bool IsEmpty { get; set; } = true;

        public int Points
        {
            get
            {
                switch (Length)
                {
                    case 2:
                        return 2;
                    case 3:
                        return 4;
                    case 4:
                        return 7;
                    case 5:
                        return 10;
                    case 6:
                        return 15;
                    default:
                        return 1;
                }
            }
        }

        public Connection(City origin, City destination, TrainColor color, int length)
        {
            Origin = origin;
            Destination = destination;
            Color = color;
            Length = length;
        }
    }
}
