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
using System.Windows.Controls;
using System.Windows.Media.Effects;
using System.Windows.Shapes;
using System.Windows;

namespace Ticket_to_ride.ViewModel
{
    public class GameViewModel : ViewModelBase
    {
        public ICommand ClaimCommand { get; }
        public ICommand EndGameCommand { get; }
        public ICommand ExitCommand { get; }
        public ICommand GoalCardCommand { get; }

        public List<Player> Players { get; }
        private int cardsToTakeLeft;
        private int turn;
        private int turnsLeft;
        private List<TrainCard> selectedHandCards;

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

        private bool notPickingCards; // This way to be able to disable buttons using binding
        public bool NotPickingCards
        {
            get => notPickingCards;
            set
            {
                notPickingCards = value;
                OnPropertyChanged(nameof(notPickingCards));
            }
        }

        public GameViewModel(Board board, List<Player> players)
        {
            Board = board;
            board.PopulateShownCards();

            Players = players;
            turnsLeft = -1;

            turn = 0;
            cardsToTakeLeft = 2;
            NotPickingCards = true;
            CurrentPlayer = Players[turn];
            SelectedConnection = null;

            DistributeCards();

            selectedHandCards = new List<TrainCard>();

            ClaimCommand = new FunctionCommand(TryToClaim);
            GoalCardCommand = new FunctionCommand(TakeGoalCard);
            EndGameCommand = new NavigationCommand(EndGame);
            ExitCommand = new NavigationCommand(Exit);
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
            selectedHandCards = new List<TrainCard>();
            cardsToTakeLeft = 2;
            NotPickingCards = true;

            turnsLeft -= 1;
            if (turnsLeft == 0)
            {
                EndGameCommand.Execute(null);
            }
        }

        private void TryToClaim()
        {
            if (selectedConnection == null || selectedHandCards.Count <= 0 || !NotPickingCards)
            {
                return;
            }

            List<TrainCard> usefullCards = new List<TrainCard>();
            foreach (TrainCard card in selectedHandCards)
            {
                if (selectedConnection.Length > usefullCards.Count)
                {
                    if (card.Color.Color == selectedConnection.TrainColor.Color || card.Color.Color == Colors.FloralWhite || selectedConnection.TrainColor.Color == Colors.Gray)
                    {
                        usefullCards.Add(card);
                    }
                }
            }

            if (selectedConnection.Length == usefullCards.Count)
            {
                Console.WriteLine($"[{CurrentPlayer}] Claiming {selectedConnection}");

                foreach (TrainCard card in usefullCards)
                {
                    _ = CurrentPlayer.Hand.Remove(card);
                }

                selectedConnection.IsEmpty = false;
                //selectedConnection.PlayerColor = CurrentPlayer.Color.Color; // TODO
                CurrentPlayer.Score += selectedConnection.Points;
                CurrentPlayer.RemainingTrains -= selectedConnection.Length;

                if (CurrentPlayer.RemainingTrains <= 2)
                {
                    turnsLeft = Players.Count + 1;
                }

                NextTurn();
            }
            else
            {
                Console.WriteLine($"[{CurrentPlayer}] Can't claim this connection");
            }
        }

        public void SelectConnection(City origin, City destination, Line line)
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

            // TODO change connection opacity on selection
            //foreach (UIElement l in lines)
            //{
            //    l.Opacity = 0.1;
            //    Console.WriteLine(l);
            //}
            //line.Opacity = 1;
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

                    TakeCard(cardToTake, true);
                    Board.ShownCards.RemoveAt(i);
                    Board.AddAShownCard();

                    break;
                }
            }
        }

        public void TakeCardFromDeck()
        {
            if (cardsToTakeLeft <= 0)
            {
                return;
            }

            if (Board.Deck.Count > 0)
            {
                TakeCard(Board.Deck[0], true);
                Board.Deck.RemoveAt(0);
            }
        }

        private void TakeCard(TrainCard cardToTake, bool fromDeck)
        {
            // TODO change hand card opacity (to 1) on card taking

            CurrentPlayer.Hand.Add(cardToTake);
            CurrentPlayer.SortCards();
            NotPickingCards = false;

            if (!fromDeck && cardToTake.Color.Color == Colors.FloralWhite)
            {
                cardsToTakeLeft -= 2;
            }
            else
            {
                cardsToTakeLeft--;
            }

            if (cardsToTakeLeft <= 0)
            {
                NextTurn();
            }
        }

        private void TakeGoalCard()
        {
            if (Board.GoalCards.Count <= 0 || !NotPickingCards)
            {
                return;
            }

            // TODO make the same thing that hand cards, because we actually can't see more than 4 goal cards
            CurrentPlayer.GoalCards.Add(ToolBox.PopOnCollection(Board.GoalCards, 1)[0]);
            NextTurn();
        }

        public void HandCardSelect(int trainCardId, Image image)
        {
            if (!NotPickingCards)
            {
                return;
            }

            for (int i = 0; i < CurrentPlayer.Hand.Count; i++)
            {
                if (CurrentPlayer.Hand[i].Id == trainCardId)
                {
                    TrainCard cardClicked = CurrentPlayer.Hand[i];

                    bool isAlreadySelected = false;

                    foreach (TrainCard card in selectedHandCards)
                    {
                        if (cardClicked.Equals(card))
                        {
                            isAlreadySelected = true;
                            break;
                        }
                    }

                    if (isAlreadySelected)
                    {
                        _ = selectedHandCards.Remove(cardClicked);
                        image.Opacity = 1;
                    }
                    else
                    {
                        selectedHandCards.Add(cardClicked);
                        image.Opacity = 0.5;
                    }

                    break;
                }
            }

            Console.WriteLine("Selected hand cards:");
            foreach (TrainCard card in selectedHandCards)
            {
                Console.WriteLine(card);
            }
        }

        private EndGameViewModel EndGame()
        {
            return new EndGameViewModel(Players);
        }

        private MenuViewModel Exit()
        {
            return new MenuViewModel();
        }
    }
}
