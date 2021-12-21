using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Ticket_to_ride.Enums;
using Ticket_to_ride.Model;
using Ticket_to_ride.ViewModel;
using Ticket_to_ride.Tools;

namespace Ticket_to_ride.ViewModel
{
    public class PlayerViewModel : ViewModelBase
    {
        private readonly Player player;

        public string Name => player.Name;
        public PlayerColor Color => player.Color;

        public PlayerViewModel(Player player)
        {
            this.player = player;
        }
    }
}
