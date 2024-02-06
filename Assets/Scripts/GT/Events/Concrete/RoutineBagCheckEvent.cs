using System;
using GT.Characters;

namespace GT.Events.Concrete
{
    public class RoutineBagCheckEvent : Event
    {
        public RoutineBagCheckEvent(Random rng) : base(rng, RegularDailyThreshold, string.Empty)
        {
        }

        public override void Result(Game game)
        {
            Player player = game.GetPlayer();
            
            // remove all the player's cards
            while (player.DeckSize() > 0)
            {
                player.RemoveCard(player.TopCard());
            }
        }
    }
}