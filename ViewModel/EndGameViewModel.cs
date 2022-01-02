using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Ticket_to_ride.Commands;

namespace Ticket_to_ride.ViewModel
{
    public class EndGameViewModel : ViewModelBase
    {
        public ICommand MainMenuCommand { get; }

        public EndGameViewModel()
        {
            MainMenuCommand = new NavigationCommand(Menu);
        }

        private MenuViewModel Menu()
        {
            return new MenuViewModel();
        }
    }
}
