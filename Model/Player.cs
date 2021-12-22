using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Ticket_to_ride.Enums;
using Ticket_to_ride.ViewModel;
using Ticket_to_ride.Tools;

namespace Ticket_to_ride.Model
{
    public class Player
    {
        public Board Board { get; set; }

        public string Name { get; set; }
        public int RemainingTrains { get; set; }
        public int Score { get; set; }

        public List<TrainCard> Hand { get; set; } = new List<TrainCard>();

        public List<GoalCard> GoalCards { get; set; } = new List<GoalCard>();

        public Player(string name, Board board)
        {
            Name = name;
            GoalCards = ToolBox<GoalCard>.Pop(board.GoalCards, 3); // TODO Player can choose at least 2 of the 3 cards
            Board = board;
            RemainingTrains = 45;
            Score = 0;
        }
    }
}
