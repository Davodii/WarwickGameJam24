using System;
using GT.Events.Concrete;

namespace GT.Events
{
    /**
     * This factory should generate a new event irregardless of probability.
     * Whether the event occurs or not is contained in the generated event
     * object itself (IEvent.WillHappen()), so the game's main-loop doesn't
     * need to care about random number generation and probabilities.
     */
    public class EventFactory
    {
        private readonly Random _rng;

        public EventFactory(Random rng)
        {
            _rng = rng;
        }
        
        public IEvent CreateDailyEvent()
        {
            // this is how we decide which event to produce
            int randomNumber = _rng.Next(0, 100);

            // I can't think of a more elegant generation method
            if (randomNumber < 25) return new NoLunchEvent(_rng);
            if (randomNumber < 50) return new BullyEvent(_rng);
            if (randomNumber < 75) return new RainyDayEvent(_rng);
            // randomNumber < 100:
            return new RoutineBagCheckEvent(_rng);
        }

        public IEvent CreateDeathEvent()
        {
            return new RandomDeathEvent(_rng);
        }
    }
}