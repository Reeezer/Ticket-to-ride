using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

using Ticket_to_ride.Enums;
using Ticket_to_ride.Model;
using Ticket_to_ride.ViewModel;
using Ticket_to_ride.Tools;
using System.Reflection;

namespace Ticket_to_ride.Model
{
    public class Connection : ViewModelBase
    {
        public List<City> Cities { get; }
        public SolidColorBrush TrainColor { get; }
        public int Length { get; }
        public bool IsEmpty { get; set; } = true;

        public int Points
        {
            get
            {
                switch (Length)
                {
                    case 2:
                        return 2;
                    case 3:
                        return 4;
                    case 4:
                        return 7;
                    case 5:
                        return 10;
                    case 6:
                        return 15;
                    default:
                        return 1;
                }
            }
        }

        private SolidColorBrush playerColor;
        public SolidColorBrush PlayerColor
        {
            get => playerColor;
            set
            {
                playerColor = value;
                OnPropertyChanged(nameof(playerColor));
            }
        }

        private readonly string colorName;
        public string FullInformations => $"{Cities[0]} - {Cities[1]}\n({Length} {colorName} trains)";
        public double LengthPosX => (Cities[0].X + Cities[1].X - 8) / 2;
        public double LengthPosY => (Cities[0].Y + Cities[1].Y - 16) / 2;

        public Connection(City origin, City destination, Color color, int length)
        {
            Cities = new List<City>
            {
                origin,
                destination
            };

            TrainColor = new SolidColorBrush(color);
            Length = length;
            PlayerColor = new SolidColorBrush(Colors.Transparent);

            PropertyInfo colorProperty = typeof(Colors).GetProperties().FirstOrDefault(p => Color.AreClose((Color)p.GetValue(null), TrainColor.Color));
            colorName = colorProperty != null ? colorProperty.Name : "Unnamed color";
        }

        public override string ToString()
        {
            return $"{Cities[0]} - {Cities[1]}";
        }

        public override bool Equals(object obj)
        {
            return Equals(obj as Connection);
        }

        public bool Equals(Connection connection2)
        {
            return connection2 != null && Cities[0].Equals(connection2.Cities[0]) && Cities[1].Equals(connection2.Cities[1]) && TrainColor.Color == connection2.TrainColor.Color && Length == connection2.Length;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Cities, TrainColor, PlayerColor, Length, IsEmpty);
        }
    }
}
