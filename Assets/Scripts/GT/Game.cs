using System;
using GT.Characters;
using GT.Events;

namespace GT
{
    public sealed class Game
    {
        private readonly Player _player = new Player();
        private readonly Teacher _teacher = new Teacher();

        private readonly Random _rng = new Random();
        private readonly EventFactory _eventFactory;

        public Game()
        {
            // initialise anything that needs a random number
            // generator with the centralised Random object.
            _eventFactory = new EventFactory(_rng);
        }

        public IEvent GenerateEvent()
        {
            IEvent regularEvent = _eventFactory.CreateDailyEvent();
            IEvent deathEvent = _eventFactory.CreateDeathEvent();

            // if an active random death event does get generated then it must happen
            return deathEvent.WillHappen() ? deathEvent : regularEvent;
        }
    }
}