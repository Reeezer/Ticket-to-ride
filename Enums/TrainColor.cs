using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Ticket_to_ride.ModelNs;
using Ticket_to_ride.ViewModelNs;
using Ticket_to_ride.ToolsNs;

namespace Ticket_to_ride.EnumsNs
{
    public enum TrainColor
    {
        Red,
        Orange,
        Yellow,
        Green,
        Blue,
        Purple,
        Black,
        White,
        Locomotive, // Only used for cards
        Grey // Only used for board, for any color
    }
}
