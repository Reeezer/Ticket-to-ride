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
    public class TrainCard
    {
        public TrainColor Color { get; set; }

        public TrainCard(TrainColor color)
        {
            Color = color;
        }
    }
}
