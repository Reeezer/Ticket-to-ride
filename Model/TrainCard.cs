﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Ticket_to_ride.Enums;
using Ticket_to_ride.ViewModel;
using Ticket_to_ride.Tools;
using System.Windows.Media;

namespace Ticket_to_ride.Model
{
    public class TrainCard : IComparable, IEquatable<TrainCard>
    {
        private static int ID = 0;

        public SolidColorBrush Color { get; }
        public string SourcePath { get; }
        public int Id { get; }

        public TrainCard(Color color, string sourcePath)
        {
            Color = new SolidColorBrush(color);
            SourcePath = sourcePath;
            Id = ID++;
        }

        public override string ToString()
        {
            return $"[{Id}] {SourcePath}";
        }

        public int CompareTo(object obj)
        {
            TrainCard card = obj as TrainCard;
            return string.Compare(Color.Color.ToString(), card.Color.Color.ToString());
        }

        public override bool Equals(object obj)
        {
            return Equals(obj as TrainCard);
        }

        public bool Equals(TrainCard card2)
        {
            return card2 != null && Id == card2.Id;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Id, Color.Color);
        }
    }
}
