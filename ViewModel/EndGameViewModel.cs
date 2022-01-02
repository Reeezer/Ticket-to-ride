using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Ticket_to_ride.Commands;
using Ticket_to_ride.Model;

namespace Ticket_to_ride.ViewModel
{
    public class EndGameViewModel : ViewModelBase
    {
        public ICommand MainMenuCommand { get; }

        public List<Player> Players { get; set; }

        public EndGameViewModel(List<Player> players)
        {
            Players = players.OrderBy(p => -p.Score).ToList();
            MainMenuCommand = new NavigationCommand(Menu);
        }

        private MenuViewModel Menu()
        {
            return new MenuViewModel();
        }
    }
}
