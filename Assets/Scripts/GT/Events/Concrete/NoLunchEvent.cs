using System;
using GT.Characters;

namespace GT.Events.Concrete
{
    public class NoLunchEvent : Event
    {
        private const int LunchCost = 300;
        
        public NoLunchEvent(Random rng) : base(rng, RegularDailyThreshold, string.Empty)
        {
        }

        public override void Result(Game game)
        {
            Player player = game.GetPlayer();
            player.ModifyMoney(-1 * LunchCost);
        }
    }
}