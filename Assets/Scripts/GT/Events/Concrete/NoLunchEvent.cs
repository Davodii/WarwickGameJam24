using System;

namespace GT.Events.Concrete
{
    public class NoLunchEvent : Event
    {
        // TODO: random prompt generation from file
        public NoLunchEvent(Random rng) : base(rng, RegularDailyThreshold, string.Empty)
        {
        }

        public override void Result(Game game)
        {
            throw new NotImplementedException();
        }
    }
}