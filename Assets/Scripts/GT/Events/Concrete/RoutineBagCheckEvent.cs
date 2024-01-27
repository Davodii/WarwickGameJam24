using System;

namespace GT.Events.Concrete
{
    public class RoutineBagCheckEvent : Event
    {
        // TODO: random prompt generation from file
        public RoutineBagCheckEvent(Random rng) : base(rng, RegularDailyThreshold, string.Empty)
        {
        }

        public override void Result(Game game)
        {
            throw new NotImplementedException();
        }
    }
}