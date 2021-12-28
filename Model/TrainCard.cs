using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Ticket_to_ride.Enums;
using Ticket_to_ride.ViewModel;
using Ticket_to_ride.Tools;
using System.Windows.Media;

namespace Ticket_to_ride.Model
{
    public class TrainCard
    {
        public SolidColorBrush Color { get; set; }

        public TrainCard(Color color)
        {
            Color = new SolidColorBrush(color);
        }
    }
}
