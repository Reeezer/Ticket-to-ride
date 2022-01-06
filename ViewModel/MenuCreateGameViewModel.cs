using System;

using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Media;
using Ticket_to_ride.Commands;
using Ticket_to_ride.Enums;
using Ticket_to_ride.Model;

namespace Ticket_to_ride.ViewModel
{
    public class MenuCreateGameViewModel : ViewModelBase
    {
        private static List<Color> playerColors = new List<Color> { Colors.Cyan, Colors.DarkOrange, Colors.Magenta, Colors.GreenYellow, Colors.DarkRed, Colors.DarkGray };

        private readonly ObservableCollection<Player> players;
        public IEnumerable<Player> Players => players;

        private readonly Board board;
        private int nbPlayer = 1;

        public ICommand AddPlayerCommand { get; }
        public ICommand RemovePlayerCommand { get; }
        public ICommand StartGameCommand { get; }
        public ICommand CancelCommand { get; }

        public MenuCreateGameViewModel()
        {
            board = new Board();
            players = new ObservableCollection<Player>();
            CreatePlayer();
            CreatePlayer();

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
                players.Add(new Player($"Player {nbPlayer}", board, playerColors[nbPlayer-1]));
                nbPlayer++;
            }
        }

        private void RemovePlayer()
        {
            if (players.Count > 2)
            {
                Player playerRemoved = players[players.Count - 1];
                _ = players.Remove(playerRemoved);
                nbPlayer--;

                // On a player instantiation, we give him goalCards, so we have to take them back when player is going out
                foreach (GoalCard goalCard in playerRemoved.GoalCards)
                {
                    board.GoalCards.Add(goalCard);
                }
            }
        }
    }
}