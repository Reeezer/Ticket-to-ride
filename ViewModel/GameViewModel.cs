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
    /// <summary>
    /// ViewModel of the Game class : handles the logial behaviour of a current game.
    /// </summary>
    public class GameViewModel : ViewModelBase
    {
        public ICommand ClaimCommand { get; }
        public ICommand EndGameCommand { get; }
        public ICommand ExitCommand { get; }
        public ICommand RulesCommand { get; }
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

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="board">The board needed to play</param>
        /// <param name="players">The list of players</param>
        public GameViewModel(Board board, List<Player> players)
        {
            Board = board;
            board.PopulateShownCards();

            Players = players;
            turn = 0;
            turnsLeft = -1;

            cardsToTakeLeft = 2;
            NotPickingCards = true;
            CurrentPlayer = Players[turn];
            SelectedConnection = null;
            selectedHandCards = new List<TrainCard>();

            DistributeCards();

            ClaimCommand = new FunctionCommand(TryToClaim);
            GoalCardCommand = new FunctionCommand(TakeGoalCard);
            EndGameCommand = new NavigationCommand(EndGame);
            ExitCommand = new NavigationCommand(Exit);
            RulesCommand = new NavigationCommand(Rules);
        }
        /// <summary>
        /// Gives the cards to each player a the beginning of a game.
        /// </summary>
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
        /// <summary>
        /// Handles the game & board behaviour when it's to an other player to play.
        /// </summary>
        private void NextTurn()
        {
            //Go to next player
            turn = ++turn % Players.Count;

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

        /// <summary>
        /// Used to highlight and choose a connection.
        /// </summary>
        /// <param name="origin">the start point</param>
        /// <param name="destination">the end point</param>
        /// <param name="line">the path between origin & destination</param>
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
        }

        /// <summary>
        /// Used to claim a connection. If a player fails to claim, nothing happens.
        /// </summary>
        private void TryToClaim()
        {
            if (selectedConnection == null || selectedHandCards.Count <= 0 || !NotPickingCards)
            {
                return;
            }

            // Check if the player has selected enough cards to claim
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

            // Claim the connection
            if (selectedConnection.Length == usefullCards.Count && CurrentPlayer.RemainingTrains >= selectedConnection.Length)
            {
                Console.WriteLine($"[{CurrentPlayer}] Claiming {selectedConnection}");

                // Remove used card from his hand
                foreach (TrainCard card in usefullCards)
                {
                    CurrentPlayer.Hand.Remove(card);
                }

                selectedConnection.IsEmpty = false;
                selectedConnection.PlayerColor = CurrentPlayer.ColorBrush;
                CurrentPlayer.Score += selectedConnection.Points;
                CurrentPlayer.RemainingTrains -= selectedConnection.Length;
                CurrentPlayer.ClaimedConnections.Add(selectedConnection);

                // Check if a goal has been fullfilled
                foreach (GoalCard goalCard in CurrentPlayer.GoalCards)
                {
                    if (IsGoalFullFilled(goalCard))
                    {

                        Console.WriteLine($"[{CurrentPlayer}] Goal {goalCard} has been fullfilled !");

                        CurrentPlayer.Score += goalCard.PointValue;

                        goalCard.IsDone = true;
                    }
                }

                ToolBox.Sort(CurrentPlayer.GoalCards);

                // The game has to end
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

        /// <summary>
        /// Checks if a goal card as been fufilled.
        /// </summary>
        /// <param name="goalCard">The goal card to check</param>
        /// <returns>true : if fufilled, false if not.</returns>
        private bool IsGoalFullFilled(GoalCard goalCard)
        {
            // Breadth first search
            List<City> visitedCities = new List<City>();
            List<Connection> connectionsToLook = new List<Connection>();

            City none = new City(CityName.None, 0, 0);
            Connection init = new Connection(goalCard.Origin, none, Colors.Transparent, 0)
            {
                ComesFrom = none
            };
            connectionsToLook.Add(init);

            while (connectionsToLook.Any())
            {
                Connection connection = connectionsToLook.First();
                connectionsToLook.Remove(connection);

                if (connection.Contains(goalCard.Destination))
                {
                    return true;
                }

                City actualCity = connection.OppositeCity(connection.ComesFrom);
                List<Connection> neighborsConnections = CurrentPlayer.ClaimedConnections.Where(c => c.Contains(actualCity)).ToList();

                foreach (Connection neighborConnection in neighborsConnections)
                {
                    Connection newConnection = new Connection(neighborConnection.Cities[0], neighborConnection.Cities[1], neighborConnection.TrainColor.Color, neighborConnection.Length)
                    {
                        ComesFrom = actualCity
                    };

                    City oppositeCity = neighborConnection.OppositeCity(actualCity);

                    if (!visitedCities.Contains(oppositeCity))
                    {
                        connectionsToLook.Add(newConnection);
                    }
                }

                visitedCities.Add(actualCity);
            };

            return false;
        }

        /// <summary>
        /// Gets a card from the stack remaining trains.
        /// </summary>
        /// <param name="trainCardId">The id of the train taken</param>
        public void TakeCardFromStack(int trainCardId)
        {
            if (cardsToTakeLeft <= 0)
            {
                return;
            }

            TrainCard cardToTake = Board.ShownCards.First(c => c.Id == trainCardId);
            if (cardToTake.Color.Color == Colors.FloralWhite && cardsToTakeLeft <= 1)
            {
                return;
            }

            TakeCard(cardToTake, false);
            Board.ShownCards.Remove(cardToTake);
            Board.AddAShownCard();
        }

        /// <summary>
        /// Gets a card from the trains shown on the board.
        /// </summary>
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

        /// <summary>
        /// Main take card method. Gets a cards (deck or stack)
        /// </summary>
        /// <param name="cardToTake">the train card to take</param>
        /// <param name="fromDeck">take a card from the deck or from the stack.</param>
        private void TakeCard(TrainCard cardToTake, bool fromDeck)
        {
            CurrentPlayer.Hand.Add(cardToTake);
            CurrentPlayer.SortCards();
            NotPickingCards = false;

            Console.WriteLine($"from deck: {fromDeck}, FloralWhite: {cardToTake.Color.Color == Colors.FloralWhite}");

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

        /// <summary>
        /// Takes a goal card from the goal cards stack.
        /// </summary>
        private void TakeGoalCard()
        {
            if (Board.GoalCards.Count <= 0 || !NotPickingCards)
            {
                return;
            }

            CurrentPlayer.GoalCards.Add(ToolBox.PopOnCollection(Board.GoalCards, 1)[0]);
            NextTurn();
        }

        /// <summary>
        /// Selects a card from the player hand
        /// </summary>
        /// <param name="trainCardId">The id of the card to select.</param>
        /// <param name="image">The source image of the raken card.</param>
        public void HandCardSelect(int trainCardId, Image image)
        {
            if (!NotPickingCards)
            {
                return;
            }

            TrainCard cardClicked = CurrentPlayer.Hand.First(c => c.Id == trainCardId);
            bool isAlreadySelected = selectedHandCards.Any(c => c.Equals(cardClicked));

            if (isAlreadySelected)
            {
                selectedHandCards.Remove(cardClicked);
                image.Opacity = 1;
            }
            else
            {
                selectedHandCards.Add(cardClicked);
                image.Opacity = 0.5;
            }

            Console.WriteLine("Selected hand cards:");
            foreach (TrainCard card in selectedHandCards)
            {
                Console.WriteLine(card);
            }
        }

        /// <summary>
        /// Displays an EndGame when the game is over. Or when "End" button is pressed.
        /// </summary>
        /// <returns>The End Game View</returns>
        private EndGameViewModel EndGame()
        {
            foreach (Player player in Players)
            {
                foreach (GoalCard goalCard in player.GoalCards)
                {
                    if (!goalCard.IsDone)
                    {
                        player.Score -= goalCard.PointValue;
                    }
                }
            }

            return new EndGameViewModel(Players);
        }

        /// <summary>
        /// Goes back to main menu.
        /// </summary>
        /// <returns>The Menu View</returns>
        private MenuViewModel Exit()
        {
            return new MenuViewModel();
        }

        /// <summary>
        /// Displays the rules
        /// </summary>
        /// <returns>The Rules View</returns>
        private RulesViewModel Rules()
        {
            return new RulesViewModel(this);
        }
    }
}
