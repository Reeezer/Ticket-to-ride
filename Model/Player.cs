﻿using System.Collections.Generic;
using Ticket_to_ride.ViewModel;
using Ticket_to_ride.Tools;
using System.Collections.ObjectModel;
using System.Windows.Media;

namespace Ticket_to_ride.Model
{
    public class Player : ViewModelBase
    {
        public Board Board { get; }

        public string Name { get; set; }
        public SolidColorBrush ColorBrush { get; }

        public ObservableCollection<TrainCard> Hand { get; } = new ObservableCollection<TrainCard>();
        public ObservableCollection<GoalCard> GoalCards { get; } = new ObservableCollection<GoalCard>();
        public List<Connection> ClaimedConnections { get; } = new List<Connection>();

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

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="name">Name</param>
        /// <param name="board">Board</param>
        /// <param name="color">Color</param>
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

        /// <summary>
        /// Sort hand train cards
        /// </summary>
        public void SortCards()
        {
            ToolBox.Sort(Hand);
        }
    }
}
