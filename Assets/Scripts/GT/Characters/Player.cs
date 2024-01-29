using System.Collections.Generic;
using GT.Counters;
using GT.Items;
using GT.Items.Cards;

namespace GT.Characters
{
    public sealed class Player
    {
        private readonly GoldenTime _goldenTime = new GoldenTime();
        private readonly CloudChart _cloudChart = new CloudChart();
        private readonly Deck _deck = new Deck();
        private readonly Wallet _wallet = new Wallet();
        private readonly Dictionary<IItem, int> _miscItems = new Dictionary<IItem, int>();
        
        public int GetMoney() { return _wallet.Get(); }
        public void ModifyMoney(int delta) { _wallet.Modify(delta); }
        
        public int GetCloudChartValue() { return _cloudChart.Get(); }
        public ECloudChartStatus GetCloudChartStatus() { return _cloudChart.GetStatus(); }
        public void ModifyCloudChart(int delta) { _cloudChart.Modify(delta); }

        public void GiveCard(Card card) { _deck.AddCard(card); }

        public int GetGoldenTime() { return _goldenTime.Get(); }
        public void ModifyGoldenTime(int delta) { _goldenTime.Modify(delta); }

        public bool HasItem(IItem item)
        {
            return _miscItems.ContainsKey(item);
        }
        
        public int NumberOfItem(IItem item)
        {
            return !_miscItems.ContainsKey(item) ? 0 : _miscItems[item];
        }

        public void GiveItem(IItem item)
        {
            if (HasItem(item))
            {
                _miscItems[item]++;
            }
            else
            {
                _miscItems.Add(item, 1);
            }
        }

        public bool RemoveItem(IItem item)
        {
            // can't delete non-existent item
            if (!HasItem(item))
            {
                return false;
            }

            // remove key-value pair completely if only 1 of item exists
            if (_miscItems[item] == 1)
            {
                _miscItems.Remove(item);
            }
            // otherwise just decrease the count of the item
            else
            {
                _miscItems[item]--;
            }

            // successful deletion
            return true;
        }

        public void GiveCardToTeacher(Teacher teacher, Card card)
        {
            teacher.GiveCard(card).Give(this);
        }
    }
}