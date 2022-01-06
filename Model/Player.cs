using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Ticket_to_ride.Enums;
using Ticket_to_ride.ViewModel;
using Ticket_to_ride.Tools;
using System.Collections.ObjectModel;
using System.Windows.Media;

namespace Ticket_to_ride.Model
{
    // FIXME: Not supposed to implement "ViewModelBase" in a model to be able to notify the view
    public class Player : ViewModelBase
    {
        public Board Board { get; }

        public string Name { get; set; }
        public SolidColorBrush ColorBrush { get; }

        public ObservableCollection<TrainCard> Hand { get; } = new ObservableCollection<TrainCard>();
        public ObservableCollection<GoalCard> GoalCards { get; } = new ObservableCollection<GoalCard>();

        private int remainingTrains;
        public int RemainingTrains
        {
            get => remainingTrains;
            set
            {
                remainingTrains = value;
                OnPropertyChanged(nameof(remainingTrains));
            }
        }

        private int score;
        public int Score
        {
            get => score;
            set
            {
                score = value;
                OnPropertyChanged(nameof(score));
            }
        }

        public Player(string name, Board board, Color color)
        {
            Name = name;
            GoalCards = ToolBox.PopOnCollection(board.GoalCards, 3); // TODO Player can choose at least 2 of the 3 cards
            ColorBrush = new SolidColorBrush(color);
            Board = board;
            RemainingTrains = 45;
            Score = 0;
        }

        public override string ToString()
        {
            return $"{Name}";
        }

        public void SortCards()
        {
            ToolBox.Sort(Hand);
        }
    }
}
