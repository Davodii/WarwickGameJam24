using System;

namespace GT.Events
{
    public abstract class Event : IEvent
    {
        protected const int RegularDailyThreshold = 50;
        protected const int RandomDeathDailyThreshold = 5;
        // randomness occurs on the principle that when a new event
        // is created we compare a threshold number to a randomly
        // generated number (assigned in the constructor)
        // the threshold and generated number are treated as percentages
        private readonly int _generatedNumber;
        private readonly int _threshold;
        private readonly string _prompt;

        protected Event(Random rng, int threshold, string prompt)
        {
            _generatedNumber = rng.Next(0, 100);
            _threshold = threshold;
            _prompt = prompt;
        }
        
        public bool WillHappen()
        {
            return _generatedNumber > _threshold;
        }

        public string GetPrompt()
        {
            return _prompt;
        }

        public abstract void Result(Game game);
    }
}