using System;

namespace GT.Events.Concrete
{
    public class RainyDayEvent : Event
    {
        // TODO: random prompt generation from file
        public RainyDayEvent(Random rng) : base(rng, RegularDailyThreshold, string.Empty)
        {
        }

        public override void Result(Game game)
        {
            throw new NotImplementedException();
        }
    }
}