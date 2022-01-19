using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Media;
using Ticket_to_ride.ViewModel;
using System.Reflection;

namespace Ticket_to_ride.Model
{
    public class Connection : ViewModelBase
    {
        public List<City> Cities { get; }
        public SolidColorBrush TrainColor { get; }
        public int Length { get; }
        public bool IsEmpty { get; set; } = true;

        public City ComesFrom { get; set; } = null;

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

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="origin">Origin city</param>
        /// <param name="destination">Destination city</param>
        /// <param name="color">Color</param>
        /// <param name="length">Length</param>
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

        /// <summary>
        /// Returns opposite city from the one passed
        /// </summary>
        /// <param name="city">City</param>
        /// <returns>City</returns>
        public City OppositeCity(City city)
        {
            return city.Equals(Cities[0]) ? Cities[1] : Cities[0];
        }

        /// <summary>
        /// Check if the city passed is contained in the connection
        /// </summary>
        /// <param name="city">City</param>
        /// <returns>Bool</returns>
        public bool Contains(City city)
        {
            return city.Equals(Cities[0]) || city.Equals(Cities[1]);
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
