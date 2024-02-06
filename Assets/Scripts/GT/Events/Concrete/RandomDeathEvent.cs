using System;

namespace GT.Events.Concrete
{
    public class RandomDeathEvent : Event
    {
        public RandomDeathEvent(Random rng) : base(rng, RandomDeathDailyThreshold, string.Empty)
        {
        }

        public override void Result(Game game)
        {
            game.RandomDeathOccurred();
        }
    }
}