using System;

namespace GT.Events.Concrete
{
    public class BullyEvent : Event
    {
        // TODO: random prompt generation from file
        public BullyEvent(Random rng) : base(rng, RegularDailyThreshold, string.Empty)
        {
        }
        
        public override void Result(Game game)
        {
            throw new NotImplementedException();
        }
    }
}