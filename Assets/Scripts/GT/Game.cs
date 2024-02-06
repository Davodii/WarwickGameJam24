using System;
using System.Collections.Generic;
using GT.Characters;
using GT.Characters.Npcs;
using GT.Counters;
using GT.Events;
using GT.Items.Cards;
using GT.Items.GoldenTimeMinutes;
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
        public static Game GetInstance()
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
        private const int DailyStartCloudChart = (int)ECloudChartStatus.Sunny; // bottom of sunny
        
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
        private bool _randomDeathOccurred = false;

        private IEvent? _event = null;
        
        #endregion

        #region Constructors
        
        private Game()
        {
            _eventFactory = new EventFactory(_rng);
            _tradeFactory = new TradeFactory(_rng);
            _questFactory = new QuestFactory(_rng);
        }
        
        #endregion
        
        #region DaySystem

        public bool HasRandomDeathOccurred()
        {
            return _randomDeathOccurred;
        }

        public void RandomDeathOccurred()
        {
            _randomDeathOccurred = true;
        }

        public int GetDay()
        {
            return _day;
        }

        public bool IsFinalDay()
        {
            return _day == NumberOfDays;
        }

        public void NewGame()
        {
            // Generate interactive NPCs
            GenerateNpcs();
            
            // attach NPC list to quest factory
            _questFactory.SetNpcs(_npcs);

            // reset day counter
            _day = 0;
        }

        public void NewDay()
        {
            // Add to golden time based on today's performance
            // NOTE: the below needs to run before other stats are reset,
            //       because it makes use of them to calculate the amount
            //       of golden time.
            DaysStatsToGoldenTime().Give(_player);
            
            // Reset player stats
            _player.ResetMoney(DailyStartMoney);
            _player.ResetCloudChart(DailyStartCloudChart);
            _player.ClearItems();
            _player.ClearBlood();
            // cards, golden time and cloud chart are carried over
            
            // Generate daily event
            GenerateEvent();

            // daily event must be generated and not null after GenerateEvent()
            if (_event == null)
            {
                throw new Exception("_event can't be null.");
            }
           
            // perform consequence of random daily event
            if (_event.WillHappen())
            {
                _event.Result(this);
            }

            // increment day counter
            _day++;
        }

        private GoldenTimeMinutes DaysStatsToGoldenTime()
        {
            int money = _player.GetMoney();
            int deckValue = _player.GetDeckValue();
            int cloudChart = _player.GetCloudChartValue();

            // TODO: you can easily adjust this formula
            return new GoldenTimeMinutes(money / 100 * cloudChart + deckValue);
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
            // ensure that NPCs from previous games don't carry over
            _npcs.Clear();
            
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


        public Player GetPlayer()
        {
            return _player;
        }
     
        #endregion

    }
}