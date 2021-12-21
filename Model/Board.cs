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

        public Board()
        {
            InitBoardConnections();
            InitGoalCards();
            InitDeck();
        }

        private void InitBoardConnections()
        {
            #region Create connections
            Connections.Add(new Connection(CityName.Vancouver, CityName.Calgary, TrainColor.Grey, 3));
            Connections.Add(new Connection(CityName.Calgary, CityName.Winnipeg, TrainColor.White, 6));
            Connections.Add(new Connection(CityName.Winnipeg, CityName.SaultSaintMarie, TrainColor.Grey, 6));
            Connections.Add(new Connection(CityName.SaultSaintMarie, CityName.Montreal, TrainColor.Black, 5));
            Connections.Add(new Connection(CityName.Montreal, CityName.Boston, TrainColor.Grey, 2));
            Connections.Add(new Connection(CityName.Montreal, CityName.Boston, TrainColor.Grey, 2));
            Connections.Add(new Connection(CityName.Vancouver, CityName.Seattle, TrainColor.Grey, 1));
            Connections.Add(new Connection(CityName.Vancouver, CityName.Seattle, TrainColor.Grey, 1));
            Connections.Add(new Connection(CityName.Seattle, CityName.Calgary, TrainColor.Grey, 4));
            Connections.Add(new Connection(CityName.Calgary, CityName.Helena, TrainColor.Grey, 4));
            Connections.Add(new Connection(CityName.Helena, CityName.Winnipeg, TrainColor.Blue, 4));
            Connections.Add(new Connection(CityName.Winnipeg, CityName.Duluth, TrainColor.Black, 4));
            Connections.Add(new Connection(CityName.Duluth, CityName.SaultSaintMarie, TrainColor.Grey, 3));
            Connections.Add(new Connection(CityName.SaultSaintMarie, CityName.Toronto, TrainColor.Grey, 2));
            Connections.Add(new Connection(CityName.Toronto, CityName.Montreal, TrainColor.Grey, 3));
            Connections.Add(new Connection(CityName.Portland, CityName.Seattle, TrainColor.Grey, 1));
            Connections.Add(new Connection(CityName.Portland, CityName.Seattle, TrainColor.Grey, 1));
            Connections.Add(new Connection(CityName.Seattle, CityName.Helena, TrainColor.Yellow, 6));
            Connections.Add(new Connection(CityName.Helena, CityName.Duluth, TrainColor.Orange, 6));
            Connections.Add(new Connection(CityName.Duluth, CityName.Toronto, TrainColor.Purple, 6));
            Connections.Add(new Connection(CityName.Toronto, CityName.Pittsburgh, TrainColor.Grey, 2));
            Connections.Add(new Connection(CityName.Montreal, CityName.NewYork, TrainColor.Blue, 3));
            Connections.Add(new Connection(CityName.NewYork, CityName.Boston, TrainColor.Yellow, 2));
            Connections.Add(new Connection(CityName.NewYork, CityName.Boston, TrainColor.Red, 2));
            Connections.Add(new Connection(CityName.Portland, CityName.SanFrancisco, TrainColor.Green, 5));
            Connections.Add(new Connection(CityName.Portland, CityName.SanFrancisco, TrainColor.Purple, 5));
            Connections.Add(new Connection(CityName.Portland, CityName.SaltLakeCity, TrainColor.Blue, 5));
            Connections.Add(new Connection(CityName.SanFrancisco, CityName.SaltLakeCity, TrainColor.Orange, 5));
            Connections.Add(new Connection(CityName.SanFrancisco, CityName.SaltLakeCity, TrainColor.White, 5));
            Connections.Add(new Connection(CityName.SaltLakeCity, CityName.Helena, TrainColor.Purple, 3));
            Connections.Add(new Connection(CityName.Helena, CityName.Denver, TrainColor.Green, 4));
            Connections.Add(new Connection(CityName.SaltLakeCity, CityName.Denver, TrainColor.Red, 3));
            Connections.Add(new Connection(CityName.SaltLakeCity, CityName.Denver, TrainColor.Yellow, 3));
            Connections.Add(new Connection(CityName.Helena, CityName.Omaha, TrainColor.Red, 5));
            Connections.Add(new Connection(CityName.Omaha, CityName.Duluth, TrainColor.Grey, 2));
            Connections.Add(new Connection(CityName.Omaha, CityName.Duluth, TrainColor.Grey, 2));
            Connections.Add(new Connection(CityName.Duluth, CityName.Chicago, TrainColor.Red, 4));
            Connections.Add(new Connection(CityName.Omaha, CityName.Chicago, TrainColor.Blue, 4));
            Connections.Add(new Connection(CityName.Chicago, CityName.Toronto, TrainColor.White, 4));
            Connections.Add(new Connection(CityName.Chicago, CityName.Pittsburgh, TrainColor.Orange, 3));
            Connections.Add(new Connection(CityName.Chicago, CityName.Pittsburgh, TrainColor.Black, 3));
            Connections.Add(new Connection(CityName.Pittsburgh, CityName.NewYork, TrainColor.White, 2));
            Connections.Add(new Connection(CityName.Pittsburgh, CityName.NewYork, TrainColor.Green, 2));
            Connections.Add(new Connection(CityName.NewYork, CityName.Washington, TrainColor.Orange, 2));
            Connections.Add(new Connection(CityName.NewYork, CityName.Washington, TrainColor.Black, 2));
            Connections.Add(new Connection(CityName.SanFrancisco, CityName.LosAngeles, TrainColor.Yellow, 3));
            Connections.Add(new Connection(CityName.SanFrancisco, CityName.LosAngeles, TrainColor.Purple, 3));
            Connections.Add(new Connection(CityName.LosAngeles, CityName.LasVegas, TrainColor.Grey, 2));
            Connections.Add(new Connection(CityName.LasVegas, CityName.SaltLakeCity, TrainColor.Orange, 3));
            Connections.Add(new Connection(CityName.LosAngeles, CityName.Phoenix, TrainColor.Grey, 3));
            Connections.Add(new Connection(CityName.LosAngeles, CityName.ElPaso, TrainColor.Black, 6));
            Connections.Add(new Connection(CityName.Phoenix, CityName.Denver, TrainColor.White, 5));
            Connections.Add(new Connection(CityName.Phoenix, CityName.SantaFe, TrainColor.Grey, 3));
            Connections.Add(new Connection(CityName.Phoenix, CityName.ElPaso, TrainColor.Grey, 3));
            Connections.Add(new Connection(CityName.ElPaso, CityName.SantaFe, TrainColor.Grey, 2));
            Connections.Add(new Connection(CityName.SantaFe, CityName.Denver, TrainColor.Grey, 2));
            Connections.Add(new Connection(CityName.Denver, CityName.KansasCity, TrainColor.Black, 4));
            Connections.Add(new Connection(CityName.Denver, CityName.KansasCity, TrainColor.Orange, 4));
            Connections.Add(new Connection(CityName.Omaha, CityName.Duluth, TrainColor.Grey, 2));
            Connections.Add(new Connection(CityName.Omaha, CityName.Duluth, TrainColor.Grey, 2));
            Connections.Add(new Connection(CityName.Omaha, CityName.KansasCity, TrainColor.Grey, 1));
            Connections.Add(new Connection(CityName.Omaha, CityName.KansasCity, TrainColor.Grey, 1));
            Connections.Add(new Connection(CityName.Denver, CityName.OklahomaCity, TrainColor.Red, 4));
            Connections.Add(new Connection(CityName.SantaFe, CityName.OklahomaCity, TrainColor.Blue, 2));
            Connections.Add(new Connection(CityName.ElPaso, CityName.OklahomaCity, TrainColor.Yellow, 5));
            Connections.Add(new Connection(CityName.ElPaso, CityName.Dallas, TrainColor.Red, 4));
            Connections.Add(new Connection(CityName.ElPaso, CityName.Houston, TrainColor.Green, 6));
            Connections.Add(new Connection(CityName.KansasCity, CityName.SaintLouis, TrainColor.Blue, 2));
            Connections.Add(new Connection(CityName.KansasCity, CityName.SaintLouis, TrainColor.Purple, 2));
            Connections.Add(new Connection(CityName.SaintLouis, CityName.Chicago, TrainColor.Green, 2));
            Connections.Add(new Connection(CityName.SaintLouis, CityName.Chicago, TrainColor.White, 2));
            Connections.Add(new Connection(CityName.SaintLouis, CityName.Pittsburgh, TrainColor.Green, 5));
            Connections.Add(new Connection(CityName.Pittsburgh, CityName.Washington, TrainColor.Grey, 2));
            Connections.Add(new Connection(CityName.SaintLouis, CityName.Nashville, TrainColor.Grey, 2));
            Connections.Add(new Connection(CityName.KansasCity, CityName.OklahomaCity, TrainColor.Grey, 2));
            Connections.Add(new Connection(CityName.KansasCity, CityName.OklahomaCity, TrainColor.Grey, 2));
            Connections.Add(new Connection(CityName.OklahomaCity, CityName.Dallas, TrainColor.Grey, 2));
            Connections.Add(new Connection(CityName.OklahomaCity, CityName.Dallas, TrainColor.Grey, 2));
            Connections.Add(new Connection(CityName.Dallas, CityName.Houston, TrainColor.Grey, 1));
            Connections.Add(new Connection(CityName.Dallas, CityName.Houston, TrainColor.Grey, 1));
            Connections.Add(new Connection(CityName.OklahomaCity, CityName.LittleRock, TrainColor.Grey, 2));
            Connections.Add(new Connection(CityName.LittleRock, CityName.SaintLouis, TrainColor.Grey, 2));
            Connections.Add(new Connection(CityName.SaintLouis, CityName.Nashville, TrainColor.Grey, 2));
            Connections.Add(new Connection(CityName.Nashville, CityName.Pittsburgh, TrainColor.Yellow, 4));
            Connections.Add(new Connection(CityName.Pittsburgh, CityName.Raleigh, TrainColor.Grey, 2));
            Connections.Add(new Connection(CityName.Nashville, CityName.Raleigh, TrainColor.Black, 3));
            Connections.Add(new Connection(CityName.Raleigh, CityName.Washington, TrainColor.Grey, 2));
            Connections.Add(new Connection(CityName.Raleigh, CityName.Washington, TrainColor.Grey, 2));
            Connections.Add(new Connection(CityName.Raleigh, CityName.Charleston, TrainColor.Grey, 2));
            Connections.Add(new Connection(CityName.Dallas, CityName.LittleRock, TrainColor.Grey, 2));
            Connections.Add(new Connection(CityName.LittleRock, CityName.Nashville, TrainColor.White, 3));
            Connections.Add(new Connection(CityName.Nashville, CityName.Atlanta, TrainColor.Grey, 1));
            Connections.Add(new Connection(CityName.Atlanta, CityName.Raleigh, TrainColor.Grey, 2));
            Connections.Add(new Connection(CityName.Atlanta, CityName.Raleigh, TrainColor.Grey, 2));
            Connections.Add(new Connection(CityName.Atlanta, CityName.Charleston, TrainColor.Grey, 2));
            Connections.Add(new Connection(CityName.LittleRock, CityName.NewOrleans, TrainColor.Green, 3));
            Connections.Add(new Connection(CityName.Houston, CityName.NewOrleans, TrainColor.Grey, 2));
            Connections.Add(new Connection(CityName.NewOrleans, CityName.Atlanta, TrainColor.Yellow, 4));
            Connections.Add(new Connection(CityName.NewOrleans, CityName.Atlanta, TrainColor.Orange, 4));
            Connections.Add(new Connection(CityName.NewOrleans, CityName.Miami, TrainColor.Red, 6));
            Connections.Add(new Connection(CityName.Atlanta, CityName.Miami, TrainColor.Blue, 5));
            Connections.Add(new Connection(CityName.Charleston, CityName.Miami, TrainColor.Purple, 4));
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
