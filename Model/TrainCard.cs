using System;
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
    public class TrainCard
    {
        private static int ID = 0;

        public SolidColorBrush Color { get; set; }
        public string SourcePath { get; set; }
        public int Id { get; set; }

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
    }
}
