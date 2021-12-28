using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Ticket_to_ride.Model;
using Ticket_to_ride.Enums;
using Ticket_to_ride.Tools;
using System.Windows.Input;
using Ticket_to_ride.Commands;
using System.Windows.Data;
using System.Windows.Media;

namespace Ticket_to_ride.ViewModel
{
    public class GameViewModel : ViewModelBase
    {
        public ICommand NextTurnCommand { get; }

        public List<Player> Players { get; set; }
        public List<City> Cities => board.Cities;
        public List<Connection> Connections => board.Connections;

        private Board board;
        public Board Board
        {
            get => board;
            set
            {
                board = value;
                OnPropertyChanged(nameof(board));
            }
        }

        private int turn;
        public int Turn
        {
            get => turn;
            set
            {
                turn = value;
                OnPropertyChanged(nameof(turn));
            }
        }

        private Player currentPlayer;
        public Player CurrentPlayer
        {
            get => currentPlayer;
            set
            {
                currentPlayer = value;
                OnPropertyChanged(nameof(currentPlayer));
            }
        }

        private Connection selectedConnection;
        public Connection SelectedConnection
        {
            get => selectedConnection;
            set
            {
                selectedConnection = value;
                OnPropertyChanged(nameof(selectedConnection));
            }
        }

        public GameViewModel(Board board, List<Player> players)
        {
            Board = board;
            Players = players;
            NextTurnCommand = new FunctionCommand(NextTurn);

            Initialize();
        }

        public void Initialize()
        {
            // Has to be done on every game start, before everything !
            Turn = 0;
            CurrentPlayer = Players[Turn];
            SelectedConnection = null;

            DistributeCards();
        }

        public void DistributeCards()
        {
            // Distribute 4 cards to everyone
            for (int i = 0; i < 4; i++)
            {
                List<TrainCard> cards = ToolBox<TrainCard>.Pop(Board.Deck, Players.Count);

                for (int j = 0; j < Players.Count; j++)
                {
                    Players[j].Hand.Add(cards[j]);
                }
            }
        }

        private void NextTurn()
        {
            Turn += 1;
            if (Turn == Players.Count)
            {
                Turn = 0;
            }
            CurrentPlayer = Players[Turn];
            SelectedConnection = null;
        }

        public void SelectConnection(City origin, City destination)
        {
            // Check if not already the current selected
            if (selectedConnection != null && SelectedConnection.Cities[0].Equals(origin) && SelectedConnection.Cities[1].Equals(destination))
            {
                return;
            }

            Connection connectionToBeSelected = Connections.First(c => c.Cities[0].Equals(origin) && c.Cities[1].Equals(destination));

            // Can't select if already claimed by a player
            if (!connectionToBeSelected.IsEmpty)
            {
                return;
            }

            SelectedConnection = connectionToBeSelected;
            Console.WriteLine($"[{CurrentPlayer}] Select: {SelectedConnection}");
        }
    }
}
