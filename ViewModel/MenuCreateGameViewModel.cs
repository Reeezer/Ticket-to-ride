using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Ticket_to_ride.Commands;
using Ticket_to_ride.Enums;
using Ticket_to_ride.Model;

namespace Ticket_to_ride.ViewModel
{
    public class MenuCreateGameViewModel : ViewModelBase
    {
        private readonly ObservableCollection<Player> players;
        public IEnumerable<Player> Players => players;

        private readonly Board board;

        public ICommand AddPlayerCommand { get; }
        public ICommand RemovePlayerCommand { get; }
        public ICommand StartGameCommand { get; }
        public ICommand CancelCommand { get; }

        public MenuCreateGameViewModel()
        {
            board = new Board();
            players = new ObservableCollection<Player>
            {
                new Player(board),
                new Player(board)
            };

            StartGameCommand = new NavigationCommand(CreateGame);
            CancelCommand = new NavigationCommand(Cancel);
            AddPlayerCommand = new FunctionCommand(CreatePlayer);
            RemovePlayerCommand = new FunctionCommand(RemovePlayer);
        }

        private GameViewModel CreateGame()
        {
            return new GameViewModel(board, Players.ToList());
        }

        private MenuViewModel Cancel()
        {
            return new MenuViewModel();
        }

        private void CreatePlayer()
        {
            if (players.Count < 6)
            {
                players.Add(new Player(board));
            }
        }

        private void RemovePlayer()
        {
            if (players.Count > 2)
            {
                _ = players.Remove(players[players.Count - 1]);
            }
        }
    }
}