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
using System.Collections.ObjectModel;

namespace Ticket_to_ride.ViewModel
{
    public class GameViewModel : ViewModelBase
    {
        public ICommand NextTurnCommand { get; }

        public List<Player> Players { get; }
        private int cardsToTakeLeft;
        private int turn;

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
            board.PopulateShownCards();

            Players = players;

            NextTurnCommand = new FunctionCommand(NextTurn);
            
            Initialize();
        }
        
        public void Initialize()
        {
            // Has to be done on every game start, before everything !
            turn = 0;
            cardsToTakeLeft = 2;
            CurrentPlayer = Players[turn];
            SelectedConnection = null;

            DistributeCards();
        }

        public void DistributeCards()
        {
            const int startCards = 4;
            // Distribute 4 cards to everyone
            for (int i = 0; i < startCards; i++)
            {
                List<TrainCard> cards = ToolBox.Pop(Board.Deck, Players.Count);

                for (int j = 0; j < Players.Count; j++)
                {
                    Players[j].Hand.Add(cards[j]);
                    Players[j].SortCards();
                }
            }

            //Sort the cards of each player
            for (int i = 0; i < Players.Count; i++)
            {
                Players[i].SortCards();
            }
        }

        private void NextTurn()
        {
            turn += 1;
            if (turn == Players.Count)
            {
                turn = 0;
            }
            CurrentPlayer = Players[turn];
            SelectedConnection = null;
            cardsToTakeLeft = 2;
        }

        public void SelectConnection(City origin, City destination)
        {
            // Check if not already the current selected
            if (selectedConnection != null && SelectedConnection.Cities[0].Equals(origin) && SelectedConnection.Cities[1].Equals(destination))
            {
                return;
            }

            Connection connectionToBeSelected = Board.Connections.First(c => c.Cities[0].Equals(origin) && c.Cities[1].Equals(destination));

            // Can't select if already claimed by a player
            if (!connectionToBeSelected.IsEmpty)
            {
                return;
            }

            SelectedConnection = connectionToBeSelected;
            Console.WriteLine($"[{CurrentPlayer}] Select: {SelectedConnection}");
        }

        public void TakeCardFromStack(int trainCardId)
        {
            if (cardsToTakeLeft <= 0)
            {
                return;
            }

            for (int i = 0; i < Board.ShownCards.Count; i++)
            {
                if (Board.ShownCards[i].Id == trainCardId)
                {
                    TrainCard cardToTake = Board.ShownCards[i];

                    if (cardToTake.Color.Color == Colors.FloralWhite && cardsToTakeLeft <= 1)
                    {
                        return;
                    }

                    CurrentPlayer.Hand.Add(cardToTake);
                    Board.ShownCards.RemoveAt(i);

                    if (cardToTake.Color.Color == Colors.FloralWhite)
                    {
                        cardsToTakeLeft -= 2;
                    }
                    else
                    {
                        cardsToTakeLeft--;
                    }

                    break;
                }
            }

            Board.AddAShownCard();
            CurrentPlayer.SortCards();

            if (cardsToTakeLeft <= 0)
            {
                NextTurn();
            }
        }
    }
}
