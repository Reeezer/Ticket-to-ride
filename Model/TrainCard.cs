using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Ticket_to_ride.EnumsNs;
using Ticket_to_ride.ViewModelNs;
using Ticket_to_ride.ToolsNs;

namespace Ticket_to_ride.ModelNs
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
