using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Ticket_to_ride.Commands;
using Ticket_to_ride.Model;

namespace Ticket_to_ride.ViewModel
{
    public class MenuCreateGameViewModel : ViewModelBase
    {
        private readonly ObservableCollection<PlayerViewModel> players;
        public IEnumerable<PlayerViewModel> Players => players;

        public ICommand StartGameCommand { get; }
        public ICommand CancelCommand { get; }

        public MenuCreateGameViewModel()
        {
            players = new ObservableCollection<PlayerViewModel>();

            StartGameCommand = new NavigationCommand(CreateGame);
            CancelCommand = new NavigationCommand(Cancel);
        }

        private GameViewModel CreateGame()
        {
            return new GameViewModel();
        }

        private MenuViewModel Cancel()
        {
            return new MenuViewModel();
        }
    }
}
 