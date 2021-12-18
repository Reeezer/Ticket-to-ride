using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Ticket_to_ride.EnumsNs;
using Ticket_to_ride.ModelNs;
using Ticket_to_ride.ViewModelNs;
using Ticket_to_ride.ToolsNs;

namespace Ticket_to_ride.ModelNs
{
    public class Board
    {
        public List<GoalCard> GoalCards { get; set; } = new List<GoalCard>();
        public List<TrainCard> Deck { get; set; } = new List<TrainCard>();
        public List<TrainCard> DiscardCards { get; set; } = new List<TrainCard>();
        public List<TrainCard> ShownCards { get; set; } = new List<TrainCard>();

        public Board()
        {
            FillBoardRoutes();
            FillGoalCards();
            FillDeck();
        }

        private void FillBoardRoutes()
        {
            // TODO
        }

        private void FillGoalCards()
        {
            // TODO
        }

        private void FillDeck()
        {
            // TODO
        }

        public void FlipShownCards()
        {
            while (ShownCards.Count < 5)
            {
                List<TrainCard> newCard = Tools<TrainCard>.Pop(Deck, 1); // only 1 car is popped in the list
                ShownCards.AddRange(newCard);

                if (Deck.Count == 0)
                {
                    Tools<TrainCard>.Shuffle(DiscardCards);

                    Deck = DiscardCards;
                    DiscardCards = new List<TrainCard>();
                }
            }
        }

        public void PopulateShownCards()
        {
            FlipShownCards();

            int locomotiveCount = ShownCards.Where(x => x.Color == TrainColor.Locomotive).Count();
            while (locomotiveCount >= 3)
            {
                DiscardCards.AddRange(ShownCards);
                ShownCards = new List<TrainCard>();

                FlipShownCards();
                locomotiveCount = ShownCards.Where(x => x.Color == TrainColor.Locomotive).Count();
            }
        }
    }
}
