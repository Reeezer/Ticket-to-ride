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
        }

        public void SelectConnection(City origin, City destination)
        {
            if (selectedConnection != null && SelectedConnection.Cities[0].Name == origin.Name && SelectedConnection.Cities[1].Name == destination.Name)
            {
                return;
            }

            SelectedConnection = Connections.First(c => c.Cities[0].Name == origin.Name && c.Cities[1].Name == destination.Name);
        }
    }
}
