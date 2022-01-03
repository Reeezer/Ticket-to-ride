using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using Ticket_to_ride.Commands;

namespace Ticket_to_ride.ViewModel
{
    public class MenuViewModel : ViewModelBase
    {
        public ICommand NewGameCommand { get; }
        public ICommand ExitCommand { get; }

        public ICommand RulesCommand { get; }

        public MenuViewModel()
        {
            NewGameCommand = new NavigationCommand(NewGame);
            ExitCommand = new ExitCommand();
            RulesCommand = new NavigationCommand(OpenRules);
        }

        private MenuCreateGameViewModel NewGame()
        {
            return new MenuCreateGameViewModel();
        }

        private RulesViewModel OpenRules()
        {
            return new RulesViewModel();
        }
    }
}
