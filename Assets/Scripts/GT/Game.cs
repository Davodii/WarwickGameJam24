using System;
using System.Collections.Generic;
using GT.Characters;
using GT.Events;
using GT.Items.Cards;
using GT.Quests;
using GT.Trades;

namespace GT
{
    public sealed class Game
    {
        private static Game? _instance = null;

        /// <summary>
        /// Get the singleton instance of the Game class:
        /// <code>
        /// Game g = Game.GetInstance();
        /// </code>
        /// </summary>
        /// <returns>Singleton game instance.</returns>
        public static Game? GetInstance()
        {
            if (_instance == null)
            {
                _instance = new Game();
            }
            return _instance;
        }
        
        private readonly Player _player = new Player();
        private readonly Teacher _teacher = new Teacher();
        private readonly List<Npc> _npcs = new List<Npc>();

        private readonly Random _rng = new Random();
        private readonly EventFactory _eventFactory;
        private readonly TradeFactory _tradeFactory;
        private readonly QuestFactory _questFactory;

        private Game()
        {
            // initialise anything that needs a random number
            // generator with the centralised Random object.
            _eventFactory = new EventFactory(_rng);
            _tradeFactory = new TradeFactory(_rng);
            _questFactory = new QuestFactory(_rng, _npcs);
        }

        public void DepositCard(Card card)
        {
            _player.GiveCardToTeacher(_teacher, card);
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