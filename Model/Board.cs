using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Ticket_to_ride.Enums;
using Ticket_to_ride.ViewModel;

namespace Ticket_to_ride.Model
{
    struct City
    {
        public CityName cityName;
        public float posX;
        public float posY;
        public int book_id;
    };

    public class Board
    {
        public BoardRouteCollection Routes { get; set; } = new BoardRouteCollection();

        public List<DestinationCard> DestinationCards { get; set; } = new List<DestinationCard>();

        public List<TrainCard> Deck { get; set; } = new List<TrainCard>();

        public List<TrainCard> DiscardPile { get; set; } = new List<TrainCard>();

        public List<TrainCard> ShownCards { get; set; } = new List<TrainCard>();

        public Board()
        {
            CreateBoardRoutes();
            CreateDestinationCards();
            CreateTrainCardDeck();
        }

        private void CreateBoardRoutes()
        {
            #region Create Routes
            Routes.AddRoute(CityName.Vancouver, CityName.Calgary, TrainColor.Grey, 3);
            Routes.AddRoute(CityName.Calgary, CityName.Winnipeg, TrainColor.White, 6);
            Routes.AddRoute(CityName.Winnipeg, CityName.SaultSaintMarie, TrainColor.Grey, 6);
            Routes.AddRoute(CityName.SaultSaintMarie, CityName.Montreal, TrainColor.Black, 5);
            Routes.AddRoute(CityName.Montreal, CityName.Boston, TrainColor.Grey, 2);
            Routes.AddRoute(CityName.Montreal, CityName.Boston, TrainColor.Grey, 2);
            Routes.AddRoute(CityName.Vancouver, CityName.Seattle, TrainColor.Grey, 1);
            Routes.AddRoute(CityName.Vancouver, CityName.Seattle, TrainColor.Grey, 1);
            Routes.AddRoute(CityName.Seattle, CityName.Calgary, TrainColor.Grey, 4);
            Routes.AddRoute(CityName.Calgary, CityName.Helena, TrainColor.Grey, 4);
            Routes.AddRoute(CityName.Helena, CityName.Winnipeg, TrainColor.Blue, 4);
            Routes.AddRoute(CityName.Winnipeg, CityName.Duluth, TrainColor.Black, 4);
            Routes.AddRoute(CityName.Duluth, CityName.SaultSaintMarie, TrainColor.Grey, 3);
            Routes.AddRoute(CityName.SaultSaintMarie, CityName.Toronto, TrainColor.Grey, 2);
            Routes.AddRoute(CityName.Toronto, CityName.Montreal, TrainColor.Grey, 3);
            Routes.AddRoute(CityName.Portland, CityName.Seattle, TrainColor.Grey, 1);
            Routes.AddRoute(CityName.Portland, CityName.Seattle, TrainColor.Grey, 1);
            Routes.AddRoute(CityName.Seattle, CityName.Helena, TrainColor.Yellow, 6);
            Routes.AddRoute(CityName.Helena, CityName.Duluth, TrainColor.Orange, 6);
            Routes.AddRoute(CityName.Duluth, CityName.Toronto, TrainColor.Purple, 6);
            Routes.AddRoute(CityName.Toronto, CityName.Pittsburgh, TrainColor.Grey, 2);
            Routes.AddRoute(CityName.Montreal, CityName.NewYork, TrainColor.Blue, 3);
            Routes.AddRoute(CityName.NewYork, CityName.Boston, TrainColor.Yellow, 2);
            Routes.AddRoute(CityName.NewYork, CityName.Boston, TrainColor.Red, 2);
            Routes.AddRoute(CityName.Portland, CityName.SanFrancisco, TrainColor.Green, 5);
            Routes.AddRoute(CityName.Portland, CityName.SanFrancisco, TrainColor.Purple, 5);
            Routes.AddRoute(CityName.Portland, CityName.SaltLakeCity, TrainColor.Blue, 5);
            Routes.AddRoute(CityName.SanFrancisco, CityName.SaltLakeCity, TrainColor.Orange, 5);
            Routes.AddRoute(CityName.SanFrancisco, CityName.SaltLakeCity, TrainColor.White, 5);
            Routes.AddRoute(CityName.SaltLakeCity, CityName.Helena, TrainColor.Purple, 3);
            Routes.AddRoute(CityName.Helena, CityName.Denver, TrainColor.Green, 4);
            Routes.AddRoute(CityName.SaltLakeCity, CityName.Denver, TrainColor.Red, 3);
            Routes.AddRoute(CityName.SaltLakeCity, CityName.Denver, TrainColor.Yellow, 3);
            Routes.AddRoute(CityName.Helena, CityName.Omaha, TrainColor.Red, 5);
            Routes.AddRoute(CityName.Omaha, CityName.Duluth, TrainColor.Grey, 2);
            Routes.AddRoute(CityName.Omaha, CityName.Duluth, TrainColor.Grey, 2);
            Routes.AddRoute(CityName.Duluth, CityName.Chicago, TrainColor.Red, 4);
            Routes.AddRoute(CityName.Omaha, CityName.Chicago, TrainColor.Blue, 4);
            Routes.AddRoute(CityName.Chicago, CityName.Toronto, TrainColor.White, 4);
            Routes.AddRoute(CityName.Chicago, CityName.Pittsburgh, TrainColor.Orange, 3);
            Routes.AddRoute(CityName.Chicago, CityName.Pittsburgh, TrainColor.Black, 3);
            Routes.AddRoute(CityName.Pittsburgh, CityName.NewYork, TrainColor.White, 2);
            Routes.AddRoute(CityName.Pittsburgh, CityName.NewYork, TrainColor.Green, 2);
            Routes.AddRoute(CityName.NewYork, CityName.Washington, TrainColor.Orange, 2);
            Routes.AddRoute(CityName.NewYork, CityName.Washington, TrainColor.Black, 2);
            Routes.AddRoute(CityName.SanFrancisco, CityName.LosAngeles, TrainColor.Yellow, 3);
            Routes.AddRoute(CityName.SanFrancisco, CityName.LosAngeles, TrainColor.Purple, 3);
            Routes.AddRoute(CityName.LosAngeles, CityName.LasVegas, TrainColor.Grey, 2);
            Routes.AddRoute(CityName.LasVegas, CityName.SaltLakeCity, TrainColor.Orange, 3);
            Routes.AddRoute(CityName.LosAngeles, CityName.Phoenix, TrainColor.Grey, 3);
            Routes.AddRoute(CityName.LosAngeles, CityName.ElPaso, TrainColor.Black, 6);
            Routes.AddRoute(CityName.Phoenix, CityName.Denver, TrainColor.White, 5);
            Routes.AddRoute(CityName.Phoenix, CityName.SantaFe, TrainColor.Grey, 3);
            Routes.AddRoute(CityName.Phoenix, CityName.ElPaso, TrainColor.Grey, 3);
            Routes.AddRoute(CityName.ElPaso, CityName.SantaFe, TrainColor.Grey, 2);
            Routes.AddRoute(CityName.SantaFe, CityName.Denver, TrainColor.Grey, 2);
            Routes.AddRoute(CityName.Denver, CityName.KansasCity, TrainColor.Black, 4);
            Routes.AddRoute(CityName.Denver, CityName.KansasCity, TrainColor.Orange, 4);
            Routes.AddRoute(CityName.Omaha, CityName.Duluth, TrainColor.Grey, 2);
            Routes.AddRoute(CityName.Omaha, CityName.Duluth, TrainColor.Grey, 2);
            Routes.AddRoute(CityName.Omaha, CityName.KansasCity, TrainColor.Grey, 1);
            Routes.AddRoute(CityName.Omaha, CityName.KansasCity, TrainColor.Grey, 1);
            Routes.AddRoute(CityName.Denver, CityName.OklahomaCity, TrainColor.Red, 4);
            Routes.AddRoute(CityName.SantaFe, CityName.OklahomaCity, TrainColor.Blue, 2);
            Routes.AddRoute(CityName.ElPaso, CityName.OklahomaCity, TrainColor.Yellow, 5);
            Routes.AddRoute(CityName.ElPaso, CityName.Dallas, TrainColor.Red, 4);
            Routes.AddRoute(CityName.ElPaso, CityName.Houston, TrainColor.Green, 6);
            Routes.AddRoute(CityName.KansasCity, CityName.SaintLouis, TrainColor.Blue, 2);
            Routes.AddRoute(CityName.KansasCity, CityName.SaintLouis, TrainColor.Purple, 2);
            Routes.AddRoute(CityName.SaintLouis, CityName.Chicago, TrainColor.Green, 2);
            Routes.AddRoute(CityName.SaintLouis, CityName.Chicago, TrainColor.White, 2);
            Routes.AddRoute(CityName.SaintLouis, CityName.Pittsburgh, TrainColor.Green, 5);
            Routes.AddRoute(CityName.Pittsburgh, CityName.Washington, TrainColor.Grey, 2);
            Routes.AddRoute(CityName.SaintLouis, CityName.Nashville, TrainColor.Grey, 2);
            Routes.AddRoute(CityName.KansasCity, CityName.OklahomaCity, TrainColor.Grey, 2);
            Routes.AddRoute(CityName.KansasCity, CityName.OklahomaCity, TrainColor.Grey, 2);
            Routes.AddRoute(CityName.OklahomaCity, CityName.Dallas, TrainColor.Grey, 2);
            Routes.AddRoute(CityName.OklahomaCity, CityName.Dallas, TrainColor.Grey, 2);
            Routes.AddRoute(CityName.Dallas, CityName.Houston, TrainColor.Grey, 1);
            Routes.AddRoute(CityName.Dallas, CityName.Houston, TrainColor.Grey, 1);
            Routes.AddRoute(CityName.OklahomaCity, CityName.LittleRock, TrainColor.Grey, 2);
            Routes.AddRoute(CityName.LittleRock, CityName.SaintLouis, TrainColor.Grey, 2);
            Routes.AddRoute(CityName.SaintLouis, CityName.Nashville, TrainColor.Grey, 2);
            Routes.AddRoute(CityName.Nashville, CityName.Pittsburgh, TrainColor.Yellow, 4);
            Routes.AddRoute(CityName.Pittsburgh, CityName.Raleigh, TrainColor.Grey, 2);
            Routes.AddRoute(CityName.Nashville, CityName.Raleigh, TrainColor.Black, 3);
            Routes.AddRoute(CityName.Raleigh, CityName.Washington, TrainColor.Grey, 2);
            Routes.AddRoute(CityName.Raleigh, CityName.Washington, TrainColor.Grey, 2);
            Routes.AddRoute(CityName.Raleigh, CityName.Charleston, TrainColor.Grey, 2);
            Routes.AddRoute(CityName.Dallas, CityName.LittleRock, TrainColor.Grey, 2);
            Routes.AddRoute(CityName.LittleRock, CityName.Nashville, TrainColor.White, 3);
            Routes.AddRoute(CityName.Nashville, CityName.Atlanta, TrainColor.Grey, 1);
            Routes.AddRoute(CityName.Atlanta, CityName.Raleigh, TrainColor.Grey, 2);
            Routes.AddRoute(CityName.Atlanta, CityName.Raleigh, TrainColor.Grey, 2);
            Routes.AddRoute(CityName.Atlanta, CityName.Charleston, TrainColor.Grey, 2);
            Routes.AddRoute(CityName.LittleRock, CityName.NewOrleans, TrainColor.Green, 3);
            Routes.AddRoute(CityName.Houston, CityName.NewOrleans, TrainColor.Grey, 2);
            Routes.AddRoute(CityName.NewOrleans, CityName.Atlanta, TrainColor.Yellow, 4);
            Routes.AddRoute(CityName.NewOrleans, CityName.Atlanta, TrainColor.Orange, 4);
            Routes.AddRoute(CityName.NewOrleans, CityName.Miami, TrainColor.Red, 6);
            Routes.AddRoute(CityName.Atlanta, CityName.Miami, TrainColor.Blue, 5);
            Routes.AddRoute(CityName.Charleston, CityName.Miami, TrainColor.Purple, 4);
            #endregion
        }

        private void CreateDestinationCards()
        {
            #region Create Destination cards
            DestinationCards.Add(new DestinationCard(CityName.NewYork, CityName.Atlanta, 6));
            DestinationCards.Add(new DestinationCard(CityName.Winnipeg, CityName.LittleRock, 11));
            DestinationCards.Add(new DestinationCard(CityName.Boston, CityName.Miami, 12));
            DestinationCards.Add(new DestinationCard(CityName.LosAngeles, CityName.Chicago, 16));
            DestinationCards.Add(new DestinationCard(CityName.Montreal, CityName.Atlanta, 9));
            DestinationCards.Add(new DestinationCard(CityName.Seattle, CityName.LosAngeles, 9));
            DestinationCards.Add(new DestinationCard(CityName.KansasCity, CityName.Houston, 5));
            DestinationCards.Add(new DestinationCard(CityName.Chicago, CityName.NewOrleans, 7));
            DestinationCards.Add(new DestinationCard(CityName.Seattle, CityName.NewYork, 22));
            DestinationCards.Add(new DestinationCard(CityName.Portland, CityName.Nashville, 17));
            DestinationCards.Add(new DestinationCard(CityName.SaultSaintMarie, CityName.OklahomaCity, 9));
            DestinationCards.Add(new DestinationCard(CityName.Vancouver, CityName.SantaFe, 13));
            DestinationCards.Add(new DestinationCard(CityName.SanFrancisco, CityName.Atlanta, 17));
            DestinationCards.Add(new DestinationCard(CityName.Vancouver, CityName.Montreal, 20));
            DestinationCards.Add(new DestinationCard(CityName.Montreal, CityName.NewOrleans, 13));
            DestinationCards.Add(new DestinationCard(CityName.LosAngeles, CityName.NewYork, 21));
            DestinationCards.Add(new DestinationCard(CityName.Calgary, CityName.SaltLakeCity, 7));
            DestinationCards.Add(new DestinationCard(CityName.Denver, CityName.Pittsburgh, 11));
            DestinationCards.Add(new DestinationCard(CityName.Helena, CityName.LosAngeles, 8));
            DestinationCards.Add(new DestinationCard(CityName.Calgary, CityName.Phoenix, 13));
            DestinationCards.Add(new DestinationCard(CityName.Chicago, CityName.SantaFe, 9));
            DestinationCards.Add(new DestinationCard(CityName.Toronto, CityName.Miami, 10)); ;
            DestinationCards.Add(new DestinationCard(CityName.Dallas, CityName.NewYork, 11));
            DestinationCards.Add(new DestinationCard(CityName.Duluth, CityName.Houston, 8));
            DestinationCards.Add(new DestinationCard(CityName.SaultSaintMarie, CityName.Nashville, 8));
            DestinationCards.Add(new DestinationCard(CityName.Duluth, CityName.ElPaso, 10));
            DestinationCards.Add(new DestinationCard(CityName.Winnipeg, CityName.Houston, 12));
            DestinationCards.Add(new DestinationCard(CityName.Denver, CityName.ElPaso, 4));
            DestinationCards.Add(new DestinationCard(CityName.LosAngeles, CityName.Miami, 20));
            DestinationCards.Add(new DestinationCard(CityName.Portland, CityName.Phoenix, 11));
            #endregion

            DestinationCards = DestinationCards.Shuffle();
        }

        private void CreateTrainCardDeck()
        {
            var deck = new List<TrainCard>();
            #region Create Train card deck
            deck.AddRange(CreateSingleColorCollection(TrainColor.Red, 12));
            deck.AddRange(CreateSingleColorCollection(TrainColor.Purple, 12));
            deck.AddRange(CreateSingleColorCollection(TrainColor.Blue, 12));
            deck.AddRange(CreateSingleColorCollection(TrainColor.Green, 12));
            deck.AddRange(CreateSingleColorCollection(TrainColor.Yellow, 12));
            deck.AddRange(CreateSingleColorCollection(TrainColor.Orange, 12));
            deck.AddRange(CreateSingleColorCollection(TrainColor.Black, 12));
            deck.AddRange(CreateSingleColorCollection(TrainColor.White, 12));
            deck.AddRange(CreateSingleColorCollection(TrainColor.Locomotive, 14));
            #endregion

            deck.Shuffle();

            this.Deck = deck;
        }

        private List<TrainCard> CreateSingleColorCollection(TrainColor color, int count)
        {
            List<TrainCard> cards = new List<TrainCard>();
            for (int i = 0; i < count; i++)
            {
                cards.Add(new TrainCard() { Color = color });
            }
            return cards;
        }

        public void FlipShownCards()
        {
            while (ShownCards.Count < 5)
            {
                var newCard = Deck.Pop(1);
                ShownCards.AddRange(newCard);
            }
        }

        public void PopulateShownCards()
        {
            if (Deck.Count < 10)
            {
                //Shuffle the discard pile into the deck
                var allCards = DiscardPile;
                allCards.AddRange(Deck.Pop(Deck.Count));

                allCards.Shuffle();

                Deck = allCards;
                DiscardPile = new List<TrainCard>();
            }

            FlipShownCards();

            var locomotiveCount = ShownCards.Where(x => x.Color == TrainColor.Locomotive).Count();
            while (locomotiveCount >= 3)
            {
                Console.WriteLine("Shown cards has 3 or more locomotives! Burning the shown cards.");

                //Discard the shown cards
                DiscardPile.AddRange(ShownCards);
                ShownCards = new List<TrainCard>();

                //Add a new set of shown cards
                FlipShownCards();
                locomotiveCount = ShownCards.Where(x => x.Color == TrainColor.Locomotive).Count();
            }
        }
    }
}
