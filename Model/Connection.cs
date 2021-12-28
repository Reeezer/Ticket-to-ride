using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

using Ticket_to_ride.Enums;
using Ticket_to_ride.Model;
using Ticket_to_ride.ViewModel;
using Ticket_to_ride.Tools;

namespace Ticket_to_ride.Model
{
    public class Connection
    {
        public List<City> Cities { get; }
        public SolidColorBrush TrainColor { get; }
        public SolidColorBrush PlayerColor { get; set; } = new SolidColorBrush(Colors.Black);
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

        public Connection(City origin, City destination, Color color, int length)
        {
            Cities = new List<City>
            {
                origin,
                destination
            };

            TrainColor = new SolidColorBrush(color);
            Length = length;
        }
    }
}
