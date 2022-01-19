using System.Collections.Generic;
using System.Linq;
using System.Windows.Media;

using Ticket_to_ride.Enums;
using Ticket_to_ride.Tools;
using System.Collections.ObjectModel;

// Train colors: Gray (all), White, Black, Blue, Yellow, Purple, Orange, Green, Red, FloralWhite (Locomotive)

namespace Ticket_to_ride.Model
{
    public class Board
    {
        public List<GoalCard> GoalCards { get; } = new List<GoalCard>();
        public List<TrainCard> Deck { get; set; } = new List<TrainCard>();
        public List<TrainCard> DiscardCards { get; set; } = new List<TrainCard>();
        public ObservableCollection<TrainCard> ShownCards { get; } = new ObservableCollection<TrainCard>();

        public List<Connection> Connections { get; } = new List<Connection>();
        public List<City> Cities { get; } = new List<City>();

        /// <summary>
        /// Constructor
        /// </summary>
        public Board()
        {
            InitCities();
            InitConnections();
            InitGoalCards();
            InitDeck();
        }

        /// <summary>
        /// Create all the cities
        /// </summary>
        private void InitCities()
        {
            #region Create cities
            Cities.Add(CreateCity(CityName.Atlanta, 45, 23));
            Cities.Add(CreateCity(CityName.Boston, 55, 1));
            Cities.Add(CreateCity(CityName.Calgary, 10, 0));
            Cities.Add(CreateCity(CityName.Charleston, 53, 20));
            Cities.Add(CreateCity(CityName.Chicago, 40, 11));
            Cities.Add(CreateCity(CityName.Dallas, 33, 32));
            Cities.Add(CreateCity(CityName.Denver, 22, 19));
            Cities.Add(CreateCity(CityName.Duluth, 33, 6));
            Cities.Add(CreateCity(CityName.ElPaso, 22, 33));
            Cities.Add(CreateCity(CityName.Helena, 18, 6));
            Cities.Add(CreateCity(CityName.Houston, 34, 35));
            Cities.Add(CreateCity(CityName.KansasCity, 30, 18));
            Cities.Add(CreateCity(CityName.LasVegas, 7, 25));
            Cities.Add(CreateCity(CityName.LittleRock, 38, 25));
            Cities.Add(CreateCity(CityName.LosAngeles, 5, 30));
            Cities.Add(CreateCity(CityName.Miami, 55, 35));
            Cities.Add(CreateCity(CityName.Montreal, 50, 0));
            Cities.Add(CreateCity(CityName.Nashville, 42, 16));
            Cities.Add(CreateCity(CityName.NewOrleans, 40, 35));
            Cities.Add(CreateCity(CityName.NewYork, 55, 5));
            Cities.Add(CreateCity(CityName.OklahomaCity, 31, 25));
            Cities.Add(CreateCity(CityName.Omaha, 32, 13));
            Cities.Add(CreateCity(CityName.Phoenix, 10, 28));
            Cities.Add(CreateCity(CityName.Pittsburgh, 47, 10));
            Cities.Add(CreateCity(CityName.Portland, 1, 8));
            Cities.Add(CreateCity(CityName.Raleigh, 50, 17));
            Cities.Add(CreateCity(CityName.SaintLouis, 35, 18));
            Cities.Add(CreateCity(CityName.SaltLakeCity, 10, 18));
            Cities.Add(CreateCity(CityName.SanFrancisco, 1, 20));
            Cities.Add(CreateCity(CityName.SantaFe, 22, 26));
            Cities.Add(CreateCity(CityName.SaultSaintMarie, 40, 3));
            Cities.Add(CreateCity(CityName.Seattle, 2, 5));
            Cities.Add(CreateCity(CityName.Toronto, 47, 6));
            Cities.Add(CreateCity(CityName.Vancouver, 3, 0));
            Cities.Add(CreateCity(CityName.Washington, 55, 12));
            Cities.Add(CreateCity(CityName.Winnipeg, 25, 0));
            #endregion
        }

        /// <summary>
        /// Create all the connections between cities
        /// </summary>
        private void InitConnections()
        {
            #region Create connections
            Connections.Add(CreateConnection(CityName.Vancouver, CityName.Calgary, Colors.Gray, 3));
            Connections.Add(CreateConnection(CityName.Calgary, CityName.Winnipeg, Colors.White, 6));
            Connections.Add(CreateConnection(CityName.Winnipeg, CityName.SaultSaintMarie, Colors.Gray, 6));
            Connections.Add(CreateConnection(CityName.SaultSaintMarie, CityName.Montreal, Colors.Black, 5));
            Connections.Add(CreateConnection(CityName.Montreal, CityName.Boston, Colors.Gray, 2));
            Connections.Add(CreateConnection(CityName.Montreal, CityName.Boston, Colors.Gray, 2));
            Connections.Add(CreateConnection(CityName.Vancouver, CityName.Seattle, Colors.Gray, 1));
            //Connections.Add(CreateConnection(CityName.Vancouver, CityName.Seattle, Colors.Gray, 1));
            Connections.Add(CreateConnection(CityName.Seattle, CityName.Calgary, Colors.Gray, 4));
            Connections.Add(CreateConnection(CityName.Calgary, CityName.Helena, Colors.Gray, 4));
            Connections.Add(CreateConnection(CityName.Helena, CityName.Winnipeg, Colors.Blue, 4));
            Connections.Add(CreateConnection(CityName.Winnipeg, CityName.Duluth, Colors.Black, 4));
            Connections.Add(CreateConnection(CityName.Duluth, CityName.SaultSaintMarie, Colors.Gray, 3));
            Connections.Add(CreateConnection(CityName.SaultSaintMarie, CityName.Toronto, Colors.Gray, 2));
            Connections.Add(CreateConnection(CityName.Toronto, CityName.Montreal, Colors.Gray, 3));
            Connections.Add(CreateConnection(CityName.Portland, CityName.Seattle, Colors.Gray, 1));
            //Connections.Add(CreateConnection(CityName.Portland, CityName.Seattle, Colors.Gray, 1));
            Connections.Add(CreateConnection(CityName.Seattle, CityName.Helena, Colors.Yellow, 6));
            Connections.Add(CreateConnection(CityName.Helena, CityName.Duluth, Colors.Orange, 6));
            Connections.Add(CreateConnection(CityName.Duluth, CityName.Toronto, Colors.Purple, 6));
            Connections.Add(CreateConnection(CityName.Toronto, CityName.Pittsburgh, Colors.Gray, 2));
            Connections.Add(CreateConnection(CityName.Montreal, CityName.NewYork, Colors.Blue, 3));
            Connections.Add(CreateConnection(CityName.NewYork, CityName.Boston, Colors.Yellow, 2));
            //Connections.Add(CreateConnection(CityName.NewYork, CityName.Boston, Colors.Red, 2));
            Connections.Add(CreateConnection(CityName.Portland, CityName.SanFrancisco, Colors.Green, 5));
            //Connections.Add(CreateConnection(CityName.Portland, CityName.SanFrancisco, Colors.Purple, 5));
            Connections.Add(CreateConnection(CityName.Portland, CityName.SaltLakeCity, Colors.Blue, 5));
            //Connections.Add(CreateConnection(CityName.SanFrancisco, CityName.SaltLakeCity, Colors.Orange, 5));
            Connections.Add(CreateConnection(CityName.SanFrancisco, CityName.SaltLakeCity, Colors.White, 5));
            Connections.Add(CreateConnection(CityName.SaltLakeCity, CityName.Helena, Colors.Purple, 3));
            Connections.Add(CreateConnection(CityName.Helena, CityName.Denver, Colors.Green, 4));
            Connections.Add(CreateConnection(CityName.SaltLakeCity, CityName.Denver, Colors.Red, 3));
            //Connections.Add(CreateConnection(CityName.SaltLakeCity, CityName.Denver, Colors.Yellow, 3));
            Connections.Add(CreateConnection(CityName.Helena, CityName.Omaha, Colors.Red, 5));
            Connections.Add(CreateConnection(CityName.Omaha, CityName.Duluth, Colors.Gray, 2));
            //Connections.Add(CreateConnection(CityName.Omaha, CityName.Duluth, Colors.Gray, 2));
            Connections.Add(CreateConnection(CityName.Duluth, CityName.Chicago, Colors.Red, 4));
            Connections.Add(CreateConnection(CityName.Omaha, CityName.Chicago, Colors.Blue, 4));
            Connections.Add(CreateConnection(CityName.Chicago, CityName.Toronto, Colors.White, 4));
            Connections.Add(CreateConnection(CityName.Chicago, CityName.Pittsburgh, Colors.Orange, 3));
            //Connections.Add(CreateConnection(CityName.Chicago, CityName.Pittsburgh, Colors.Black, 3));
            Connections.Add(CreateConnection(CityName.Pittsburgh, CityName.NewYork, Colors.White, 2));
            //Connections.Add(CreateConnection(CityName.Pittsburgh, CityName.NewYork, Colors.Green, 2));
            Connections.Add(CreateConnection(CityName.NewYork, CityName.Washington, Colors.Orange, 2));
            //Connections.Add(CreateConnection(CityName.NewYork, CityName.Washington, Colors.Black, 2));
            Connections.Add(CreateConnection(CityName.SanFrancisco, CityName.LosAngeles, Colors.Yellow, 3));
            //Connections.Add(CreateConnection(CityName.SanFrancisco, CityName.LosAngeles, Colors.Purple, 3));
            Connections.Add(CreateConnection(CityName.LosAngeles, CityName.LasVegas, Colors.Gray, 2));
            Connections.Add(CreateConnection(CityName.LasVegas, CityName.SaltLakeCity, Colors.Orange, 3));
            Connections.Add(CreateConnection(CityName.LosAngeles, CityName.Phoenix, Colors.Gray, 3));
            Connections.Add(CreateConnection(CityName.LosAngeles, CityName.ElPaso, Colors.Black, 6));
            Connections.Add(CreateConnection(CityName.Phoenix, CityName.Denver, Colors.White, 5));
            Connections.Add(CreateConnection(CityName.Phoenix, CityName.SantaFe, Colors.Gray, 3));
            Connections.Add(CreateConnection(CityName.Phoenix, CityName.ElPaso, Colors.Gray, 3));
            Connections.Add(CreateConnection(CityName.ElPaso, CityName.SantaFe, Colors.Gray, 2));
            Connections.Add(CreateConnection(CityName.SantaFe, CityName.Denver, Colors.Gray, 2));
            Connections.Add(CreateConnection(CityName.Denver, CityName.KansasCity, Colors.Black, 4));
            //Connections.Add(CreateConnection(CityName.Denver, CityName.KansasCity, Colors.Orange, 4));
            Connections.Add(CreateConnection(CityName.Omaha, CityName.Duluth, Colors.Gray, 2));
            //Connections.Add(CreateConnection(CityName.Omaha, CityName.Duluth, Colors.Gray, 2));
            Connections.Add(CreateConnection(CityName.Omaha, CityName.KansasCity, Colors.Gray, 1));
            //Connections.Add(CreateConnection(CityName.Omaha, CityName.KansasCity, Colors.Gray, 1));
            Connections.Add(CreateConnection(CityName.Denver, CityName.OklahomaCity, Colors.Red, 4));
            Connections.Add(CreateConnection(CityName.SantaFe, CityName.OklahomaCity, Colors.Blue, 2));
            Connections.Add(CreateConnection(CityName.ElPaso, CityName.OklahomaCity, Colors.Yellow, 5));
            Connections.Add(CreateConnection(CityName.ElPaso, CityName.Dallas, Colors.Red, 4));
            Connections.Add(CreateConnection(CityName.ElPaso, CityName.Houston, Colors.Green, 6));
            Connections.Add(CreateConnection(CityName.KansasCity, CityName.SaintLouis, Colors.Blue, 2));
            //Connections.Add(CreateConnection(CityName.KansasCity, CityName.SaintLouis, Colors.Purple, 2));
            Connections.Add(CreateConnection(CityName.SaintLouis, CityName.Chicago, Colors.Green, 2));
            //Connections.Add(CreateConnection(CityName.SaintLouis, CityName.Chicago, Colors.White, 2));
            Connections.Add(CreateConnection(CityName.SaintLouis, CityName.Pittsburgh, Colors.Green, 5));
            Connections.Add(CreateConnection(CityName.Pittsburgh, CityName.Washington, Colors.Gray, 2));
            Connections.Add(CreateConnection(CityName.SaintLouis, CityName.Nashville, Colors.Gray, 2));
            Connections.Add(CreateConnection(CityName.KansasCity, CityName.OklahomaCity, Colors.Gray, 2));
            //Connections.Add(CreateConnection(CityName.KansasCity, CityName.OklahomaCity, Colors.Gray, 2));
            Connections.Add(CreateConnection(CityName.OklahomaCity, CityName.Dallas, Colors.Gray, 2));
            //Connections.Add(CreateConnection(CityName.OklahomaCity, CityName.Dallas, Colors.Gray, 2));
            Connections.Add(CreateConnection(CityName.Dallas, CityName.Houston, Colors.Gray, 1));
            //Connections.Add(CreateConnection(CityName.Dallas, CityName.Houston, Colors.Gray, 1));
            Connections.Add(CreateConnection(CityName.OklahomaCity, CityName.LittleRock, Colors.Gray, 2));
            Connections.Add(CreateConnection(CityName.LittleRock, CityName.SaintLouis, Colors.Gray, 2));
            Connections.Add(CreateConnection(CityName.SaintLouis, CityName.Nashville, Colors.Gray, 2));
            Connections.Add(CreateConnection(CityName.Nashville, CityName.Pittsburgh, Colors.Yellow, 4));
            Connections.Add(CreateConnection(CityName.Pittsburgh, CityName.Raleigh, Colors.Gray, 2));
            Connections.Add(CreateConnection(CityName.Nashville, CityName.Raleigh, Colors.Black, 3));
            Connections.Add(CreateConnection(CityName.Raleigh, CityName.Washington, Colors.Gray, 2));
            //Connections.Add(CreateConnection(CityName.Raleigh, CityName.Washington, Colors.Gray, 2));
            Connections.Add(CreateConnection(CityName.Raleigh, CityName.Charleston, Colors.Gray, 2));
            Connections.Add(CreateConnection(CityName.Dallas, CityName.LittleRock, Colors.Gray, 2));
            Connections.Add(CreateConnection(CityName.LittleRock, CityName.Nashville, Colors.White, 3));
            Connections.Add(CreateConnection(CityName.Nashville, CityName.Atlanta, Colors.Gray, 1));
            Connections.Add(CreateConnection(CityName.Atlanta, CityName.Raleigh, Colors.Gray, 2));
            //Connections.Add(CreateConnection(CityName.Atlanta, CityName.Raleigh, Colors.Gray, 2));
            Connections.Add(CreateConnection(CityName.Atlanta, CityName.Charleston, Colors.Gray, 2));
            Connections.Add(CreateConnection(CityName.LittleRock, CityName.NewOrleans, Colors.Green, 3));
            Connections.Add(CreateConnection(CityName.Houston, CityName.NewOrleans, Colors.Gray, 2));
            Connections.Add(CreateConnection(CityName.NewOrleans, CityName.Atlanta, Colors.Yellow, 4));
            //Connections.Add(CreateConnection(CityName.NewOrleans, CityName.Atlanta, Colors.Orange, 4));
            Connections.Add(CreateConnection(CityName.NewOrleans, CityName.Miami, Colors.Red, 6));
            Connections.Add(CreateConnection(CityName.Atlanta, CityName.Miami, Colors.Blue, 5));
            Connections.Add(CreateConnection(CityName.Charleston, CityName.Miami, Colors.Purple, 4));
            #endregion
        }

        /// <summary>
        /// Create and shuffle all the goal cards
        /// </summary>
        private void InitGoalCards()
        {
            #region Create goal cards
            GoalCards.Add(CreateGoalCard(CityName.NewYork, CityName.Atlanta, 6, $"newyork-atlanta"));
            GoalCards.Add(CreateGoalCard(CityName.Winnipeg, CityName.LittleRock, 11, $"winnipeg-littlerock"));
            GoalCards.Add(CreateGoalCard(CityName.Boston, CityName.Miami, 12, $"boston-miami"));
            GoalCards.Add(CreateGoalCard(CityName.LosAngeles, CityName.Chicago, 16, $"losangeles-chicago"));
            GoalCards.Add(CreateGoalCard(CityName.Montreal, CityName.Atlanta, 9, $"montreal-atlanta"));
            GoalCards.Add(CreateGoalCard(CityName.Seattle, CityName.LosAngeles, 9, $"seattle-losangeles"));
            GoalCards.Add(CreateGoalCard(CityName.KansasCity, CityName.Houston, 5, $"kansascity-houston"));
            GoalCards.Add(CreateGoalCard(CityName.Chicago, CityName.NewOrleans, 7, $"chicago-neworleans"));
            GoalCards.Add(CreateGoalCard(CityName.Seattle, CityName.NewYork, 22, $"seattle-newyork"));
            GoalCards.Add(CreateGoalCard(CityName.Portland, CityName.Nashville, 17, $"portland-nashville"));
            GoalCards.Add(CreateGoalCard(CityName.SaultSaintMarie, CityName.OklahomaCity, 9, $"saultstmarie-oklahomacity"));
            GoalCards.Add(CreateGoalCard(CityName.Vancouver, CityName.SantaFe, 13, $"vancouver-santafe"));
            GoalCards.Add(CreateGoalCard(CityName.SanFrancisco, CityName.Atlanta, 17, $"sanfrancisco-atlanta"));
            GoalCards.Add(CreateGoalCard(CityName.Vancouver, CityName.Montreal, 20, $"vancouver-montreal"));
            GoalCards.Add(CreateGoalCard(CityName.Montreal, CityName.NewOrleans, 13, $"montreal-neworleans"));
            GoalCards.Add(CreateGoalCard(CityName.LosAngeles, CityName.NewYork, 21, $"losangeles-newyork"));
            GoalCards.Add(CreateGoalCard(CityName.Calgary, CityName.SaltLakeCity, 7, $"calgary-saltlakecity"));
            GoalCards.Add(CreateGoalCard(CityName.Denver, CityName.Pittsburgh, 11, $"denver-pittsburgh"));
            GoalCards.Add(CreateGoalCard(CityName.Helena, CityName.LosAngeles, 8, $"helena-losangeles"));
            GoalCards.Add(CreateGoalCard(CityName.Calgary, CityName.Phoenix, 13, $"calgary-phoenix"));
            GoalCards.Add(CreateGoalCard(CityName.Chicago, CityName.SantaFe, 9, $"chicago-santafe"));
            GoalCards.Add(CreateGoalCard(CityName.Toronto, CityName.Miami, 10, $"toronto-miami")); ;
            GoalCards.Add(CreateGoalCard(CityName.Dallas, CityName.NewYork, 11, $"dallas-newyork"));
            GoalCards.Add(CreateGoalCard(CityName.Duluth, CityName.Houston, 8, $"duluth-houston"));
            GoalCards.Add(CreateGoalCard(CityName.SaultSaintMarie, CityName.Nashville, 8, $"saultstmarie-nashville"));
            GoalCards.Add(CreateGoalCard(CityName.Duluth, CityName.ElPaso, 10, $"duluth-elpaso"));
            GoalCards.Add(CreateGoalCard(CityName.Winnipeg, CityName.Houston, 12, $"winnipeg-houston"));
            GoalCards.Add(CreateGoalCard(CityName.Denver, CityName.ElPaso, 4, $"denver-elpaso"));
            GoalCards.Add(CreateGoalCard(CityName.LosAngeles, CityName.Miami, 20, $"losangeles-miami"));
            GoalCards.Add(CreateGoalCard(CityName.Portland, CityName.Phoenix, 11, $"portland-phoenix"));

            ToolBox.Shuffle(GoalCards);
            #endregion
        }

        /// <summary>
        /// Create and shuffle all the train cards
        /// </summary>
        private void InitDeck()
        {
            #region Create train cards
            Deck.AddRange(FillColorTrainCards(Colors.Red, "red", 12));
            Deck.AddRange(FillColorTrainCards(Colors.Purple, "purple", 12));
            Deck.AddRange(FillColorTrainCards(Colors.Blue, "blue", 12));
            Deck.AddRange(FillColorTrainCards(Colors.Green, "green", 12));
            Deck.AddRange(FillColorTrainCards(Colors.Yellow, "yellow", 12));
            Deck.AddRange(FillColorTrainCards(Colors.Orange, "orange", 12));
            Deck.AddRange(FillColorTrainCards(Colors.Black, "black", 12));
            Deck.AddRange(FillColorTrainCards(Colors.White, "white", 12));
            Deck.AddRange(FillColorTrainCards(Colors.FloralWhite, "locomotive", 14));

            ToolBox.Shuffle<TrainCard>(Deck);
            #endregion
        }

        /// <summary>
        /// Populate deck of a number of same train cards
        /// </summary>
        /// <param name="color">Color</param>
        /// <param name="sourcePathColor">Image path</param>
        /// <param name="count">Number</param>
        /// <returns>List of same train cards</returns>
        private List<TrainCard> FillColorTrainCards(Color color, string sourcePathColor, int count)
        {
            List<TrainCard> cards = new List<TrainCard>();
            for (int i = 0; i < count; i++)
            {
                cards.Add(new TrainCard(color, $"/Ticket-to-ride;component/images/train/{sourcePathColor}.png"));
            }
            return cards;
        }

        /// <summary>
        /// Create a connection between two cities
        /// </summary>
        /// <param name="origin">Origin city</param>
        /// <param name="destination">Destination city</param>
        /// <param name="color">Color</param>
        /// <param name="length">Length</param>
        /// <returns>Connection</returns>
        private Connection CreateConnection(CityName origin, CityName destination, Color color, int length)
        {
            return new Connection(Cities.First(c => c.Name == origin), Cities.First(c => c.Name == destination), color, length);
        }

        /// <summary>
        /// Create a city 
        /// </summary>
        /// <param name="name"></param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns>City</returns>
        private City CreateCity(CityName name, double x, double y)
        {
            return new City(name, (x * 12) + 10, (y * 13) + 10); // Tricks to display correctly on canvas
        }

        /// <summary>
        /// Create a goal card
        /// </summary>
        /// <param name="origin">Origin city</param>
        /// <param name="destination">Destination city</param>
        /// <param name="points">Value</param>
        /// <param name="path">Image path</param>
        /// <returns>GoalCard</returns>
        private GoalCard CreateGoalCard(CityName origin, CityName destination, int points, string path)
        {
            return new GoalCard(Cities.First(c => c.Name == origin), Cities.First(c => c.Name == destination), points, $"/Ticket-to-ride;component/images/goal/{path}.png");
        }

        /// <summary>
        /// Repopulate all the train cards that are able to be picked up
        /// </summary>
        private void ChangeAllShownCards()
        {
            while (ShownCards.Count < 5)
            {
                List<TrainCard> newCard = ToolBox.Pop(Deck, 1); // only 1 car is popped in the list
                ShownCards.Add(newCard[0]);

                if (Deck.Count == 0)
                {
                    ToolBox.Shuffle(DiscardCards);

                    Deck = DiscardCards;
                    DiscardCards = new List<TrainCard>();
                }
            }
        }

        /// <summary>
        /// Verify if there are 3 or more than 3 locomotive in the shown cards: not allowed. Otherwise repopulate shown cards
        /// </summary>
        private void CheckShownCards()
        {
            int locomotiveCount = ShownCards.Count(x => x.Color.Color == Colors.FloralWhite);
            while (locomotiveCount >= 3)
            {
                DiscardCards.AddRange(ShownCards);
                ShownCards.Clear();

                ChangeAllShownCards();
                locomotiveCount = ShownCards.Count(x => x.Color.Color == Colors.FloralWhite);
            }
        }

        /// <summary>
        /// Populate all the train cards that are able to be picked up
        /// </summary>
        public void PopulateShownCards()
        {
            ChangeAllShownCards();
            CheckShownCards();
        }

        /// <summary>
        /// Add a card to the shown ones
        /// </summary>
        public void AddAShownCard()
        {
            if (ShownCards.Count >= 5 || Deck.Count <= 0)
            {
                return;
            }

            ShownCards.Add(Deck[0]);
            Deck.RemoveAt(0);

            CheckShownCards();
        }
    }
}
