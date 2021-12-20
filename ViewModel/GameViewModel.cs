using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Ticket_to_ride.Model;
using Ticket_to_ride.Enums;
using Ticket_to_ride.Tools;

namespace Ticket_to_ride.ViewModel
{
    public class GameViewModel : ViewModelBase
    {
        public List<Player> Players { get; set; }

        public Board Board
        {
            get => Board;
            set
            {
                Board = value;
                OnPropertyChanged(nameof(Board));
            }
        }

        public int Turn
        {
            get => Turn;
            set
            {
                Turn = value;
                OnPropertyChanged(nameof(Turn));
            }
        }

        public GameViewModel()
        {
            Initialize();
        }

        public void Initialize()
        {
            // Has to be done on every game start, before everything !
            Turn = 0;
            Board = new Board();
            Players = new List<Player>();
        }

        public void CreatePlayer(string name, PlayerColor color)
        {
            Players.Add(new Player(name, color, Board));
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

        // Summary informations on every players
        // TODO maybe go to JSON ?
        public List<Dictionary<string, string>> PlayersSummaries()
        {
            List<Dictionary<string, string>> playersSummaries = new List<Dictionary<string, string>>();
            
            for (int i = 0; i < Players.Count; i++)
            {
                Dictionary<string, string> summary = new Dictionary<string, string>();
                Player player = Players[i];

                summary.Add("name", player.Name);
                summary.Add("color", player.Color.ToString());
                summary.Add("score", player.Score.ToString());
                summary.Add("remainingTrains", player.RemainingTrains.ToString());
                summary.Add("nbCards", player.Hand.Count.ToString());
                summary.Add("remainnigGoalCards", player.GoalCards.Count.ToString());

                playersSummaries.Add(summary);
            }

            return playersSummaries;
        }

        // Real informations for the current playing player
        // TODO maybe go to JSON ?
        public Dictionary<string, string> PlayerInformations(int playerIndex) 
        {
            Dictionary<string, string> informations = new Dictionary<string, string>();
            Player player = Players[playerIndex];

            informations.Add("name", player.Name);
            informations.Add("color", player.Color.ToString());
            informations.Add("score", player.Score.ToString());
            informations.Add("remainingTrains", player.RemainingTrains.ToString());

            // Display all train cards
            for (int i = 0; i < player.Hand.Count; i++)
            {
                informations.Add("trainCard" + i, player.Hand[i].ToString());
            }

            // Display all goal cards
            for (int i = 0; i < player.GoalCards.Count; i++)
            {
                informations.Add("goalCard" + i, player.GoalCards[i].ToString());
            }

            return informations;
        }
    }
}
