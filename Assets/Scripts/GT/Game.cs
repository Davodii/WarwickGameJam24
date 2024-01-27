using GT.Counters;
using GT.Events;
using System;


namespace GT
{
    public class Game
    {
        private readonly GoldenTime _goldenTime = new GoldenTime();
        private readonly CloudChart _cloudChart = new CloudChart();
        private int _money = 0;

        private readonly Random _rng = new Random();
        private readonly EventFactory _eventFactory;

        public Game()
        {
            // initialise anything that needs a random number
            // generator with the centralised Random object.
            _eventFactory = new EventFactory(_rng);
        }

        public int GetMoney() { return _money; }
        public void ModifyMoney(int delta) { _money += delta; }
        
        public int GetCloudChartValue() { return _cloudChart.Get(); }
        public ECloudChartStatus GetCloudChartStatus() { return _cloudChart.GetStatus(); }
        public void ModifyCloudChart(int delta) { _cloudChart.Modify(delta); }

        public int GetGoldenTime() { return _goldenTime.Get(); }
        public void ModifyGoldenTime(int delta) { _goldenTime.Modify(delta); }

        public IEvent GenerateEvent()
        {
            IEvent regularEvent = _eventFactory.CreateDailyEvent();
            IEvent deathEvent = _eventFactory.CreateDeathEvent();

            // if an active random death event does get generated then it must happen
            return deathEvent.WillHappen() ? deathEvent : regularEvent;
        }
    }
}