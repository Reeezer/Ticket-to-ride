using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Media;

using Ticket_to_ride.Enums;
using Ticket_to_ride.Model;
using Ticket_to_ride.ViewModel;
using Ticket_to_ride.Tools;
using System.Collections.ObjectModel;

// Train colors: Gray (all), White, Black, Blue, Yellow, Purple, Orange, Green, Red, FloralWhite (Locomotive)

namespace Ticket_to_ride.Model
{
    public class Board
    {
        public List<GoalCard> GoalCards { get; set; } = new List<GoalCard>();
        public List<TrainCard> Deck { get; set; } = new List<TrainCard>();
        public List<TrainCard> DiscardCards { get; set; } = new List<TrainCard>();
        public ObservableCollection<TrainCard> ShownCards { get; set; } = new ObservableCollection<TrainCard>();

        public List<Connection> Connections { get; set; } = new List<Connection>();
        public List<City> Cities { get; set; } = new List<City>();

        public Board()
        {
            InitCities();
            InitConnections();
            InitGoalCards();
            InitDeck();
        }

        private void InitCities()
        {
            #region Create cities
            Cities.Add(CreateCity(CityName.Atlanta, 45, 23));
            Cities.Add(CreateCity(CityName.Boston, 55, 2));
            Cities.Add(CreateCity(CityName.Calgary, 10, 0));
            Cities.Add(CreateCity(CityName.Charleston, 53, 20));
            Cities.Add(CreateCity(CityName.Chicago, 40, 11));
            Cities.Add(CreateCity(CityName.Dallas, 32, 33));
            Cities.Add(CreateCity(CityName.Denver, 22, 19));
            Cities.Add(CreateCity(CityName.Duluth, 33, 6));
            Cities.Add(CreateCity(CityName.ElPaso, 22, 33));
            Cities.Add(CreateCity(CityName.Helena, 18, 6));
            Cities.Add(CreateCity(CityName.Houston, 34, 35));
            Cities.Add(CreateCity(CityName.KansasCity, 33, 18));
            Cities.Add(CreateCity(CityName.LasVegas, 7, 25));
            Cities.Add(CreateCity(CityName.LittleRock, 38, 25));
            Cities.Add(CreateCity(CityName.LosAngeles, 5, 30));
            Cities.Add(CreateCity(CityName.Miami, 55, 35));
            Cities.Add(CreateCity(CityName.Montreal, 50, 0));
            Cities.Add(CreateCity(CityName.Nashville, 42, 16));
            Cities.Add(CreateCity(CityName.NewOrleans, 40, 35));
            Cities.Add(CreateCity(CityName.NewYork, 55, 5));
            Cities.Add(CreateCity(CityName.OklahomaCity, 32, 25));
            Cities.Add(CreateCity(CityName.Omaha, 32, 13));
            Cities.Add(CreateCity(CityName.Phoenix, 10, 28));
            Cities.Add(CreateCity(CityName.Pittsburgh, 47, 10));
            Cities.Add(CreateCity(CityName.Portland, 1, 4));
            Cities.Add(CreateCity(CityName.Raleigh, 50, 17));
            Cities.Add(CreateCity(CityName.SaintLouis, 35, 18));
            Cities.Add(CreateCity(CityName.SaltLakeCity, 10, 18));
            Cities.Add(CreateCity(CityName.SanFrancisco, 0, 20));
            Cities.Add(CreateCity(CityName.SantaFe, 22, 26));
            Cities.Add(CreateCity(CityName.SaultSaintMarie, 40, 5));
            Cities.Add(CreateCity(CityName.Seattle, 2, 2));
            Cities.Add(CreateCity(CityName.Toronto, 47, 6));
            Cities.Add(CreateCity(CityName.Vancouver, 3, 0));
            Cities.Add(CreateCity(CityName.Washington, 55, 12));
            Cities.Add(CreateCity(CityName.Winnipeg, 25, 0));
            #endregion
        }

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

        private void InitGoalCards()
        {
            #region Create goal cards
            GoalCards.Add(new GoalCard(CityName.NewYork, CityName.Atlanta, 6, $"/Ticket-to-ride;component/images/goal/newyork-atlanta.png"));
            GoalCards.Add(new GoalCard(CityName.Winnipeg, CityName.LittleRock, 11, $"/Ticket-to-ride;component/images/goal/winnipeg-littlerock.png"));
            GoalCards.Add(new GoalCard(CityName.Boston, CityName.Miami, 12, $"/Ticket-to-ride;component/images/goal/boston-miami.png"));
            GoalCards.Add(new GoalCard(CityName.LosAngeles, CityName.Chicago, 16, $"/Ticket-to-ride;component/images/goal/losangeles-chicago.png"));
            GoalCards.Add(new GoalCard(CityName.Montreal, CityName.Atlanta, 9, $"/Ticket-to-ride;component/images/goal/montreal-atlanta.png"));
            GoalCards.Add(new GoalCard(CityName.Seattle, CityName.LosAngeles, 9, $"/Ticket-to-ride;component/images/goal/seattle-losangeles.png"));
            GoalCards.Add(new GoalCard(CityName.KansasCity, CityName.Houston, 5, $"/Ticket-to-ride;component/images/goal/kansascity-houston.png"));
            GoalCards.Add(new GoalCard(CityName.Chicago, CityName.NewOrleans, 7, $"/Ticket-to-ride;component/images/goal/chicago-neworleans.png"));
            GoalCards.Add(new GoalCard(CityName.Seattle, CityName.NewYork, 22, $"/Ticket-to-ride;component/images/goal/seattle-newyork.png"));
            GoalCards.Add(new GoalCard(CityName.Portland, CityName.Nashville, 17, $"/Ticket-to-ride;component/images/goal/portland-nashville.png"));
            GoalCards.Add(new GoalCard(CityName.SaultSaintMarie, CityName.OklahomaCity, 9, $"/Ticket-to-ride;component/images/goal/saultstmarie-oklahomacity.png"));
            GoalCards.Add(new GoalCard(CityName.Vancouver, CityName.SantaFe, 13, $"/Ticket-to-ride;component/images/goal/vancouver-santafe.png"));
            GoalCards.Add(new GoalCard(CityName.SanFrancisco, CityName.Atlanta, 17, $"/Ticket-to-ride;component/images/goal/sanfrancisco-atlanta.png"));
            GoalCards.Add(new GoalCard(CityName.Vancouver, CityName.Montreal, 20, $"/Ticket-to-ride;component/images/goal/vancouver-montreal.png"));
            GoalCards.Add(new GoalCard(CityName.Montreal, CityName.NewOrleans, 13, $"/Ticket-to-ride;component/images/goal/montreal-neworleans.png"));
            GoalCards.Add(new GoalCard(CityName.LosAngeles, CityName.NewYork, 21, $"/Ticket-to-ride;component/images/goal/losangeles-newyork.png"));
            GoalCards.Add(new GoalCard(CityName.Calgary, CityName.SaltLakeCity, 7, $"/Ticket-to-ride;component/images/goal/calgary-saltlakecity.png"));
            GoalCards.Add(new GoalCard(CityName.Denver, CityName.Pittsburgh, 11, $"/Ticket-to-ride;component/images/goal/denver-pittsburgh.png"));
            GoalCards.Add(new GoalCard(CityName.Helena, CityName.LosAngeles, 8, $"/Ticket-to-ride;component/images/goal/helena-losangeles.png"));
            GoalCards.Add(new GoalCard(CityName.Calgary, CityName.Phoenix, 13, $"/Ticket-to-ride;component/images/goal/calgary-phoenix.png"));
            GoalCards.Add(new GoalCard(CityName.Chicago, CityName.SantaFe, 9, $"/Ticket-to-ride;component/images/goal/chicago-santafe.png"));
            GoalCards.Add(new GoalCard(CityName.Toronto, CityName.Miami, 10, $"/Ticket-to-ride;component/images/goal/toronto-miami.png")); ;
            GoalCards.Add(new GoalCard(CityName.Dallas, CityName.NewYork, 11, $"/Ticket-to-ride;component/images/goal/dallas-newyork.png"));
            GoalCards.Add(new GoalCard(CityName.Duluth, CityName.Houston, 8, $"/Ticket-to-ride;component/images/goal/duluth-houston.png"));
            GoalCards.Add(new GoalCard(CityName.SaultSaintMarie, CityName.Nashville, 8, $"/Ticket-to-ride;component/images/goal/saultstmarie-nashville.png"));
            GoalCards.Add(new GoalCard(CityName.Duluth, CityName.ElPaso, 10, $"/Ticket-to-ride;component/images/goal/duluth-elpaso.png"));
            GoalCards.Add(new GoalCard(CityName.Winnipeg, CityName.Houston, 12, $"/Ticket-to-ride;component/images/goal/winnipeg-houston.png"));
            GoalCards.Add(new GoalCard(CityName.Denver, CityName.ElPaso, 4, $"/Ticket-to-ride;component/images/goal/denver-elpaso.png"));
            GoalCards.Add(new GoalCard(CityName.LosAngeles, CityName.Miami, 20, $"/Ticket-to-ride;component/images/goal/losangeles-miami.png"));
            GoalCards.Add(new GoalCard(CityName.Portland, CityName.Phoenix, 11, $"/Ticket-to-ride;component/images/goal/portland-phoenix.png"));

            ToolBox.Shuffle<GoalCard>(GoalCards);
            #endregion
        }

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

        private List<TrainCard> FillColorTrainCards(Color color, string sourcePathColor, int count)
        {
            List<TrainCard> cards = new List<TrainCard>();
            for (int i = 0; i < count; i++)
            {
                cards.Add(new TrainCard(color, $"/Ticket-to-ride;component/images/train/{sourcePathColor}.png"));
            }
            return cards;
        }


        private Connection CreateConnection(CityName origin, CityName destination, Color color, int length)
        {
            return new Connection(Cities.First(c => c.Name == origin), Cities.First(c => c.Name == destination), color, length);
        }

        private City CreateCity(CityName name, double x, double y)
        {
            return new City(name, x * 12, y * 13);
        }

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

        private void CheckShownCards()
        {
            // Verify if there are 3 or more than 3 locomotive in the shown cards: not allowed
            int locomotiveCount = ShownCards.Count(x => x.Color.Color == Colors.FloralWhite);
            while (locomotiveCount >= 3)
            {
                DiscardCards.AddRange(ShownCards);
                ShownCards.Clear();

                ChangeAllShownCards();
                locomotiveCount = ShownCards.Count(x => x.Color.Color == Colors.FloralWhite);
            }
        }

        public void PopulateShownCards()
        {
            ChangeAllShownCards();
            CheckShownCards();
        }

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
