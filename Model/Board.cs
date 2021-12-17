using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Ticket_to_ride.Enums;
using Ticket_to_ride.ViewModel;

namespace Ticket_to_ride.Model
{
    public class Board
    {
        public BoardRouteCollection Routes { get; set; } = new BoardRouteCollection();
        public List<GoalCard> GoalCards { get; set; } = new List<GoalCard>();
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
            // TODO
        }

        private void CreateDestinationCards()
        {
            // TODO
        }

        private void CreateTrainCardDeck()
        {
            // TODO
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
