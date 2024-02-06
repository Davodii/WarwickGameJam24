using System;
using GT.Characters;

namespace GT.Events.Concrete
{
    public class RainyDayEvent : Event
    {
        public RainyDayEvent(Random rng) : base(rng, RegularDailyThreshold, string.Empty)
        {
        }

        public override void Result(Game game)
        {
            Player player = game.GetPlayer();
            
            // lose between 1 and 3 cards if possible
            int numberOfCardsLost = Rng.Next(1, 4);

            while (numberOfCardsLost-- > 0)
            {
                if (player.DeckSize() == 0)
                {
                    break;
                }

                player.RemoveCard(player.TopCard());
            }
        }
    }
}