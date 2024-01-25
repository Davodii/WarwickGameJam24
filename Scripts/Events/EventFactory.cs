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
        private Random _rng;

        public EventFactory(Random rng)
        {
            _rng = rng;
        }
        
        public IEvent CreateEvent()
        {
            throw new NotImplementedException();
        }
    }
}