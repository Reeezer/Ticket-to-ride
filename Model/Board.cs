using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Ticket_to_ride.Enums;
using Ticket_to_ride.Model;
using Ticket_to_ride.ViewModel;
using Ticket_to_ride.Tools;

namespace Ticket_to_ride.Model
{
    public class Board
    {
        public List<GoalCard> GoalCards { get; set; } = new List<GoalCard>();
        public List<TrainCard> Deck { get; set; } = new List<TrainCard>();
        public List<TrainCard> DiscardCards { get; set; } = new List<TrainCard>();
        public List<TrainCard> ShownCards { get; set; } = new List<TrainCard>();

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
            Cities.Add(CreateCity(CityName.Phoenix, 10, 30));
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
            Connections.Add(CreateConnection(CityName.Vancouver, CityName.Calgary, TrainColor.Grey, 3));
            Connections.Add(CreateConnection(CityName.Calgary, CityName.Winnipeg, TrainColor.White, 6));
            Connections.Add(CreateConnection(CityName.Winnipeg, CityName.SaultSaintMarie, TrainColor.Grey, 6));
            Connections.Add(CreateConnection(CityName.SaultSaintMarie, CityName.Montreal, TrainColor.Black, 5));
            Connections.Add(CreateConnection(CityName.Montreal, CityName.Boston, TrainColor.Grey, 2));
            Connections.Add(CreateConnection(CityName.Montreal, CityName.Boston, TrainColor.Grey, 2));
            Connections.Add(CreateConnection(CityName.Vancouver, CityName.Seattle, TrainColor.Grey, 1));
            //Connections.Add(CreateConnection(CityName.Vancouver, CityName.Seattle, TrainColor.Grey, 1));
            Connections.Add(CreateConnection(CityName.Seattle, CityName.Calgary, TrainColor.Grey, 4));
            Connections.Add(CreateConnection(CityName.Calgary, CityName.Helena, TrainColor.Grey, 4));
            Connections.Add(CreateConnection(CityName.Helena, CityName.Winnipeg, TrainColor.Blue, 4));
            Connections.Add(CreateConnection(CityName.Winnipeg, CityName.Duluth, TrainColor.Black, 4));
            Connections.Add(CreateConnection(CityName.Duluth, CityName.SaultSaintMarie, TrainColor.Grey, 3));
            Connections.Add(CreateConnection(CityName.SaultSaintMarie, CityName.Toronto, TrainColor.Grey, 2));
            Connections.Add(CreateConnection(CityName.Toronto, CityName.Montreal, TrainColor.Grey, 3));
            Connections.Add(CreateConnection(CityName.Portland, CityName.Seattle, TrainColor.Grey, 1));
            //Connections.Add(CreateConnection(CityName.Portland, CityName.Seattle, TrainColor.Grey, 1));
            Connections.Add(CreateConnection(CityName.Seattle, CityName.Helena, TrainColor.Yellow, 6));
            Connections.Add(CreateConnection(CityName.Helena, CityName.Duluth, TrainColor.Orange, 6));
            Connections.Add(CreateConnection(CityName.Duluth, CityName.Toronto, TrainColor.Purple, 6));
            Connections.Add(CreateConnection(CityName.Toronto, CityName.Pittsburgh, TrainColor.Grey, 2));
            Connections.Add(CreateConnection(CityName.Montreal, CityName.NewYork, TrainColor.Blue, 3));
            Connections.Add(CreateConnection(CityName.NewYork, CityName.Boston, TrainColor.Yellow, 2));
            //Connections.Add(CreateConnection(CityName.NewYork, CityName.Boston, TrainColor.Red, 2));
            Connections.Add(CreateConnection(CityName.Portland, CityName.SanFrancisco, TrainColor.Green, 5));
            //Connections.Add(CreateConnection(CityName.Portland, CityName.SanFrancisco, TrainColor.Purple, 5));
            Connections.Add(CreateConnection(CityName.Portland, CityName.SaltLakeCity, TrainColor.Blue, 5));
            //Connections.Add(CreateConnection(CityName.SanFrancisco, CityName.SaltLakeCity, TrainColor.Orange, 5));
            Connections.Add(CreateConnection(CityName.SanFrancisco, CityName.SaltLakeCity, TrainColor.White, 5));
            Connections.Add(CreateConnection(CityName.SaltLakeCity, CityName.Helena, TrainColor.Purple, 3));
            Connections.Add(CreateConnection(CityName.Helena, CityName.Denver, TrainColor.Green, 4));
            Connections.Add(CreateConnection(CityName.SaltLakeCity, CityName.Denver, TrainColor.Red, 3));
            //Connections.Add(CreateConnection(CityName.SaltLakeCity, CityName.Denver, TrainColor.Yellow, 3));
            Connections.Add(CreateConnection(CityName.Helena, CityName.Omaha, TrainColor.Red, 5));
            Connections.Add(CreateConnection(CityName.Omaha, CityName.Duluth, TrainColor.Grey, 2));
            //Connections.Add(CreateConnection(CityName.Omaha, CityName.Duluth, TrainColor.Grey, 2));
            Connections.Add(CreateConnection(CityName.Duluth, CityName.Chicago, TrainColor.Red, 4));
            Connections.Add(CreateConnection(CityName.Omaha, CityName.Chicago, TrainColor.Blue, 4));
            Connections.Add(CreateConnection(CityName.Chicago, CityName.Toronto, TrainColor.White, 4));
            Connections.Add(CreateConnection(CityName.Chicago, CityName.Pittsburgh, TrainColor.Orange, 3));
            //Connections.Add(CreateConnection(CityName.Chicago, CityName.Pittsburgh, TrainColor.Black, 3));
            Connections.Add(CreateConnection(CityName.Pittsburgh, CityName.NewYork, TrainColor.White, 2));
            //Connections.Add(CreateConnection(CityName.Pittsburgh, CityName.NewYork, TrainColor.Green, 2));
            Connections.Add(CreateConnection(CityName.NewYork, CityName.Washington, TrainColor.Orange, 2));
            //Connections.Add(CreateConnection(CityName.NewYork, CityName.Washington, TrainColor.Black, 2));
            Connections.Add(CreateConnection(CityName.SanFrancisco, CityName.LosAngeles, TrainColor.Yellow, 3));
            //Connections.Add(CreateConnection(CityName.SanFrancisco, CityName.LosAngeles, TrainColor.Purple, 3));
            Connections.Add(CreateConnection(CityName.LosAngeles, CityName.LasVegas, TrainColor.Grey, 2));
            Connections.Add(CreateConnection(CityName.LasVegas, CityName.SaltLakeCity, TrainColor.Orange, 3));
            Connections.Add(CreateConnection(CityName.LosAngeles, CityName.Phoenix, TrainColor.Grey, 3));
            Connections.Add(CreateConnection(CityName.LosAngeles, CityName.ElPaso, TrainColor.Black, 6));
            Connections.Add(CreateConnection(CityName.Phoenix, CityName.Denver, TrainColor.White, 5));
            Connections.Add(CreateConnection(CityName.Phoenix, CityName.SantaFe, TrainColor.Grey, 3));
            Connections.Add(CreateConnection(CityName.Phoenix, CityName.ElPaso, TrainColor.Grey, 3));
            Connections.Add(CreateConnection(CityName.ElPaso, CityName.SantaFe, TrainColor.Grey, 2));
            Connections.Add(CreateConnection(CityName.SantaFe, CityName.Denver, TrainColor.Grey, 2));
            Connections.Add(CreateConnection(CityName.Denver, CityName.KansasCity, TrainColor.Black, 4));
            //Connections.Add(CreateConnection(CityName.Denver, CityName.KansasCity, TrainColor.Orange, 4));
            Connections.Add(CreateConnection(CityName.Omaha, CityName.Duluth, TrainColor.Grey, 2));
            //Connections.Add(CreateConnection(CityName.Omaha, CityName.Duluth, TrainColor.Grey, 2));
            Connections.Add(CreateConnection(CityName.Omaha, CityName.KansasCity, TrainColor.Grey, 1));
            //Connections.Add(CreateConnection(CityName.Omaha, CityName.KansasCity, TrainColor.Grey, 1));
            Connections.Add(CreateConnection(CityName.Denver, CityName.OklahomaCity, TrainColor.Red, 4));
            Connections.Add(CreateConnection(CityName.SantaFe, CityName.OklahomaCity, TrainColor.Blue, 2));
            Connections.Add(CreateConnection(CityName.ElPaso, CityName.OklahomaCity, TrainColor.Yellow, 5));
            Connections.Add(CreateConnection(CityName.ElPaso, CityName.Dallas, TrainColor.Red, 4));
            Connections.Add(CreateConnection(CityName.ElPaso, CityName.Houston, TrainColor.Green, 6));
            Connections.Add(CreateConnection(CityName.KansasCity, CityName.SaintLouis, TrainColor.Blue, 2));
            //Connections.Add(CreateConnection(CityName.KansasCity, CityName.SaintLouis, TrainColor.Purple, 2));
            Connections.Add(CreateConnection(CityName.SaintLouis, CityName.Chicago, TrainColor.Green, 2));
            //Connections.Add(CreateConnection(CityName.SaintLouis, CityName.Chicago, TrainColor.White, 2));
            Connections.Add(CreateConnection(CityName.SaintLouis, CityName.Pittsburgh, TrainColor.Green, 5));
            Connections.Add(CreateConnection(CityName.Pittsburgh, CityName.Washington, TrainColor.Grey, 2));
            Connections.Add(CreateConnection(CityName.SaintLouis, CityName.Nashville, TrainColor.Grey, 2));
            Connections.Add(CreateConnection(CityName.KansasCity, CityName.OklahomaCity, TrainColor.Grey, 2));
            //Connections.Add(CreateConnection(CityName.KansasCity, CityName.OklahomaCity, TrainColor.Grey, 2));
            Connections.Add(CreateConnection(CityName.OklahomaCity, CityName.Dallas, TrainColor.Grey, 2));
            //Connections.Add(CreateConnection(CityName.OklahomaCity, CityName.Dallas, TrainColor.Grey, 2));
            Connections.Add(CreateConnection(CityName.Dallas, CityName.Houston, TrainColor.Grey, 1));
            //Connections.Add(CreateConnection(CityName.Dallas, CityName.Houston, TrainColor.Grey, 1));
            Connections.Add(CreateConnection(CityName.OklahomaCity, CityName.LittleRock, TrainColor.Grey, 2));
            Connections.Add(CreateConnection(CityName.LittleRock, CityName.SaintLouis, TrainColor.Grey, 2));
            Connections.Add(CreateConnection(CityName.SaintLouis, CityName.Nashville, TrainColor.Grey, 2));
            Connections.Add(CreateConnection(CityName.Nashville, CityName.Pittsburgh, TrainColor.Yellow, 4));
            Connections.Add(CreateConnection(CityName.Pittsburgh, CityName.Raleigh, TrainColor.Grey, 2));
            Connections.Add(CreateConnection(CityName.Nashville, CityName.Raleigh, TrainColor.Black, 3));
            Connections.Add(CreateConnection(CityName.Raleigh, CityName.Washington, TrainColor.Grey, 2));
            //Connections.Add(CreateConnection(CityName.Raleigh, CityName.Washington, TrainColor.Grey, 2));
            Connections.Add(CreateConnection(CityName.Raleigh, CityName.Charleston, TrainColor.Grey, 2));
            Connections.Add(CreateConnection(CityName.Dallas, CityName.LittleRock, TrainColor.Grey, 2));
            Connections.Add(CreateConnection(CityName.LittleRock, CityName.Nashville, TrainColor.White, 3));
            Connections.Add(CreateConnection(CityName.Nashville, CityName.Atlanta, TrainColor.Grey, 1));
            Connections.Add(CreateConnection(CityName.Atlanta, CityName.Raleigh, TrainColor.Grey, 2));
            //Connections.Add(CreateConnection(CityName.Atlanta, CityName.Raleigh, TrainColor.Grey, 2));
            Connections.Add(CreateConnection(CityName.Atlanta, CityName.Charleston, TrainColor.Grey, 2));
            Connections.Add(CreateConnection(CityName.LittleRock, CityName.NewOrleans, TrainColor.Green, 3));
            Connections.Add(CreateConnection(CityName.Houston, CityName.NewOrleans, TrainColor.Grey, 2));
            Connections.Add(CreateConnection(CityName.NewOrleans, CityName.Atlanta, TrainColor.Yellow, 4));
            //Connections.Add(CreateConnection(CityName.NewOrleans, CityName.Atlanta, TrainColor.Orange, 4));
            Connections.Add(CreateConnection(CityName.NewOrleans, CityName.Miami, TrainColor.Red, 6));
            Connections.Add(CreateConnection(CityName.Atlanta, CityName.Miami, TrainColor.Blue, 5));
            Connections.Add(CreateConnection(CityName.Charleston, CityName.Miami, TrainColor.Purple, 4));
            #endregion
        }

        private void InitGoalCards()
        {
            #region Create goal cards
            GoalCards.Add(new GoalCard(CityName.NewYork, CityName.Atlanta, 6));
            GoalCards.Add(new GoalCard(CityName.Winnipeg, CityName.LittleRock, 11));
            GoalCards.Add(new GoalCard(CityName.Boston, CityName.Miami, 12));
            GoalCards.Add(new GoalCard(CityName.LosAngeles, CityName.Chicago, 16));
            GoalCards.Add(new GoalCard(CityName.Montreal, CityName.Atlanta, 9));
            GoalCards.Add(new GoalCard(CityName.Seattle, CityName.LosAngeles, 9));
            GoalCards.Add(new GoalCard(CityName.KansasCity, CityName.Houston, 5));
            GoalCards.Add(new GoalCard(CityName.Chicago, CityName.NewOrleans, 7));
            GoalCards.Add(new GoalCard(CityName.Seattle, CityName.NewYork, 22));
            GoalCards.Add(new GoalCard(CityName.Portland, CityName.Nashville, 17));
            GoalCards.Add(new GoalCard(CityName.SaultSaintMarie, CityName.OklahomaCity, 9));
            GoalCards.Add(new GoalCard(CityName.Vancouver, CityName.SantaFe, 13));
            GoalCards.Add(new GoalCard(CityName.SanFrancisco, CityName.Atlanta, 17));
            GoalCards.Add(new GoalCard(CityName.Vancouver, CityName.Montreal, 20));
            GoalCards.Add(new GoalCard(CityName.Montreal, CityName.NewOrleans, 13));
            GoalCards.Add(new GoalCard(CityName.LosAngeles, CityName.NewYork, 21));
            GoalCards.Add(new GoalCard(CityName.Calgary, CityName.SaltLakeCity, 7));
            GoalCards.Add(new GoalCard(CityName.Denver, CityName.Pittsburgh, 11));
            GoalCards.Add(new GoalCard(CityName.Helena, CityName.LosAngeles, 8));
            GoalCards.Add(new GoalCard(CityName.Calgary, CityName.Phoenix, 13));
            GoalCards.Add(new GoalCard(CityName.Chicago, CityName.SantaFe, 9));
            GoalCards.Add(new GoalCard(CityName.Toronto, CityName.Miami, 10)); ;
            GoalCards.Add(new GoalCard(CityName.Dallas, CityName.NewYork, 11));
            GoalCards.Add(new GoalCard(CityName.Duluth, CityName.Houston, 8));
            GoalCards.Add(new GoalCard(CityName.SaultSaintMarie, CityName.Nashville, 8));
            GoalCards.Add(new GoalCard(CityName.Duluth, CityName.ElPaso, 10));
            GoalCards.Add(new GoalCard(CityName.Winnipeg, CityName.Houston, 12));
            GoalCards.Add(new GoalCard(CityName.Denver, CityName.ElPaso, 4));
            GoalCards.Add(new GoalCard(CityName.LosAngeles, CityName.Miami, 20));
            GoalCards.Add(new GoalCard(CityName.Portland, CityName.Phoenix, 11));

            ToolBox<GoalCard>.Shuffle(GoalCards);
            #endregion
        }

        private void InitDeck()
        {
            #region Create train cards
            Deck.AddRange(FillColorTrainCards(TrainColor.Red, 12));
            Deck.AddRange(FillColorTrainCards(TrainColor.Purple, 12));
            Deck.AddRange(FillColorTrainCards(TrainColor.Blue, 12));
            Deck.AddRange(FillColorTrainCards(TrainColor.Green, 12));
            Deck.AddRange(FillColorTrainCards(TrainColor.Yellow, 12));
            Deck.AddRange(FillColorTrainCards(TrainColor.Orange, 12));
            Deck.AddRange(FillColorTrainCards(TrainColor.Black, 12));
            Deck.AddRange(FillColorTrainCards(TrainColor.White, 12));
            Deck.AddRange(FillColorTrainCards(TrainColor.Locomotive, 14));

            ToolBox<TrainCard>.Shuffle(Deck);
            #endregion
        }

        private List<TrainCard> FillColorTrainCards(TrainColor color, int count)
        {
            List<TrainCard> cards = new List<TrainCard>();
            for (int i = 0; i < count; i++)
            {
                cards.Add(new TrainCard(color));
            }
            return cards;
        }

        private Connection CreateConnection(CityName origin, CityName destination, TrainColor color, int length)
        {
            return new Connection(Cities.First(c => c.Name == origin), Cities.First(c => c.Name == destination), color, length);
        }

        private City CreateCity(CityName name, double x, double y)
        {
            return new City(name, x * 12, y * 13);
        }

        public void ChangeAllShownCards()
        {
            while (ShownCards.Count < 5)
            {
                List<TrainCard> newCard = ToolBox<TrainCard>.Pop(Deck, 1); // only 1 car is popped in the list
                ShownCards.AddRange(newCard);

                if (Deck.Count == 0)
                {
                    ToolBox<TrainCard>.Shuffle(DiscardCards);

                    Deck = DiscardCards;
                    DiscardCards = new List<TrainCard>();
                }
            }
        }

        public void PopulateShownCards()
        {
            ChangeAllShownCards();

            // Verify if there are 3 or more than 3 locomotive in the shown cards: not allowed

            int locomotiveCount = ShownCards.Where(x => x.Color == TrainColor.Locomotive).Count();
            while (locomotiveCount >= 3)
            {
                DiscardCards.AddRange(ShownCards);
                ShownCards = new List<TrainCard>();

                ChangeAllShownCards();
                locomotiveCount = ShownCards.Where(x => x.Color == TrainColor.Locomotive).Count();
            }
        }
    }
}
