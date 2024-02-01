using System;
using System.Collections.Generic;
using GT.Characters;
using GT.Characters.Npcs;
using GT.Events;
using GT.Items.Cards;
using GT.Quests;
using GT.Trades;

namespace GT
{
    public sealed class Game
    {
        #region Singleton
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
        
        #endregion
        
        #region Fields

        private const int DailyStartMoney = 500; // £5.00
        
        private readonly Player _player = new Player();
        private readonly Teacher _teacher = new Teacher();
        private readonly List<Npc> _npcs = new List<Npc>();
        private const int NumberOfInteractiveNpcs = 5;

        private readonly Random _rng = new Random();
        private readonly EventFactory _eventFactory;
        private readonly TradeFactory _tradeFactory;
        private readonly QuestFactory _questFactory;

        private int _day;
        private const int NumberOfDays = 5;

        private IEvent? _event = null;
        
        #endregion

        #region Constructors
        
        private Game()
        {
            // initialise anything that needs a random number
            // generator with the centralised Random object.
            _eventFactory = new EventFactory(_rng);
            _tradeFactory = new TradeFactory(_rng);
            _questFactory = new QuestFactory(_rng, _npcs);
            
            // day system
            _day = 0;
        }
        
        #endregion
        
        #region DaySystem

        public int GetDay()
        {
            return _day;
        }

        public bool FinalDay()
        {
            return _day == NumberOfDays;
        }

        public void NewGame()
        {
            // Generate interactive NPCs
            GenerateNpcs();
        }

        public void NewDay()
        {
            // Generate daily event
            GenerateEvent();
            
            // TODO: game should end if death event
            // TODO: generate daily quest for event if not death event (and if required)
            
            // Reset player stats
            _player.ResetMoney(DailyStartMoney);
            _player.ClearItems();
            _player.ClearBlood();
            // cards, golden time and cloud chart are carried over
            
            // Add to golden time based on today's performance
            // TODO: the above
        }
        
        #endregion

        #region Cards
        
        public void DepositCard(Card card)
        {
            _player.GiveCardToTeacher(_teacher, card);
        }
        
        #endregion

        #region Generation

        public void GenerateEvent()
        {
            IEvent regularEvent = _eventFactory.CreateDailyEvent();
            IEvent deathEvent = _eventFactory.CreateDeathEvent();

            // if an active random death event does get generated then it must happen
            _event = deathEvent.WillHappen() ? deathEvent : regularEvent;
        }
        
        private void GenerateNpcs()
        {
            for (int i = 0; i < NumberOfInteractiveNpcs; i++)
            {
                Npc npc = GenerateNpc();
                _npcs.Add(npc);
            }
        }

        private Npc GenerateNpc()
        {
            return new NpcBuilder(_rng)
                .GenerateName()
                .GenerateQuest(_questFactory)
                .GenerateTrade(_tradeFactory)
                .GenerateBullyRewards()
                .Build();
        }
        
        #endregion
    }
}