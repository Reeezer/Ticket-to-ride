using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Ticket_to_ride.EnumsNs;
using Ticket_to_ride.ViewModelNs;
using Ticket_to_ride.ToolsNs;

namespace Ticket_to_ride.ModelNs
{
    public class Player
    {
        public Board Board { get; set; }

        public string Name { get; set; }
        public PlayerColor Color { get; set; }
        public int RemainingTrains { get; set; } = 45;

        public List<TrainCard> Hand { get; set; } = new List<TrainCard>();

        public List<GoalCard> DestinationCards { get; set; } = new List<GoalCard>();

        public Player(string name, PlayerColor color, Board board)
        {
            Name = name;
            DestinationCards = Tools<GoalCard>.Pop(board.GoalCards, 3);
            Color = color;
            Board = board;
        }
    }
}
