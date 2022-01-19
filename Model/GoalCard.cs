using System;

namespace Ticket_to_ride.Model
{
    public class GoalCard : IComparable
    {
        public City Origin { get; }
        public City Destination { get; }
        public string SourcePath { get; }
        public int PointValue { get; }
        public bool IsDone { get; set; } = false;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="origin">Origin city</param>
        /// <param name="destination">Destinatino city</param>
        /// <param name="points">Value</param>
        /// <param name="sourcePath">Image path</param>
        public GoalCard(City origin, City destination, int points, string sourcePath)
        {
            Origin = origin;
            Destination = destination;
            PointValue = points;
            SourcePath = sourcePath;
        }

        public override string ToString()
        {
            return $"{Origin} - {Destination} ({PointValue} points)";
        }

        public int CompareTo(object obj)
        {
            GoalCard c2 = obj as GoalCard;
            return IsDone.CompareTo(c2.IsDone);
        }
    }
}
