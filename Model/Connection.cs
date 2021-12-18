using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Ticket_to_ride.EnumsNs;
using Ticket_to_ride.ModelNs;
using Ticket_to_ride.ViewModelNs;
using Ticket_to_ride.ToolsNs;

namespace Ticket_to_ride.ModelNs
{
    public class Connection
    {
        public CityName Origin { get; set; }
        public CityName Destination { get; set; }
        public TrainColor Color { get; set; }
        public int Length { get; set; }
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

        public Connection(CityName origin, CityName destination, TrainColor color, int length)
        {
            Origin = origin;
            Destination = destination;
            Color = color;
            Length = length;
        }
    }
}
