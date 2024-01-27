using System;

namespace GT.Events.Concrete
{
    public class RandomDeathEvent : Event
    {
        // TODO: random prompt generation from file
        public RandomDeathEvent(Random rng) : base(rng, RandomDeathDailyThreshold, string.Empty)
        {
        }

        public override void Result(Game game)
        {
            throw new NotImplementedException();
        }
    }
}