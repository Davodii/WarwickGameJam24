using System.Collections.Generic;
using GT.Characters;
using GT.Items;
using GT.Items.Cards;
using GT.Items.Money;
using GT.Quests;
using System;

namespace GT.Trades
{
    public sealed class TradeFactory
    {
        private readonly Random _rng;
        
        public TradeFactory(Random rng)
        {
            _rng = rng;
        }
        
        /// <summary>
        /// Generate a random trade based on the inputs
        /// </summary>
        /// <returns></returns>
        public Trade CreateRandomTrade()
        {
            // TODO: introduce some way of making trades more/less "expensive"
            Dictionary<IItem, int> items = new Dictionary<IItem, int>();
            Dictionary<IItem, int> price = new Dictionary<IItem, int>();

            // Add random items
            items.Add(new Card(ECardValue._1), 1);
            items.Add(new Money(5), 1);
            
            Trade trade = new Trade(items, price);
            
            return trade;
        }
    }
}