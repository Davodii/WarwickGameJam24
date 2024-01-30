using System.Collections.Generic;
using System.Linq;
using GT.Characters;
using GT.Items;

namespace GT.Trades
{
    public sealed class Trade
    {
        // Items are the items the player receives
        // Price is the items the player needs to "give" for the trade
        private readonly IReadOnlyDictionary<IItem, int> _items;
        private readonly IReadOnlyDictionary<IItem, int> _price;

        public Trade(IReadOnlyDictionary<IItem, int> items, IReadOnlyDictionary<IItem, int> price)
        {
            _price = price;
            _items = items;
        }

        /// <summary>
        /// Used for displaying to UI
        /// </summary>
        /// <returns>Items required for trade as well as count of each</returns>
        public IReadOnlyDictionary<IItem, int> GetPrice()
        {
            return _price;
        }
        
        /// <summary>
        /// Used for displaying to UI
        /// </summary>
        /// <returns>Items player gets when trade is accepted</returns>
        public IReadOnlyDictionary<IItem, int> GetItems()
        {
            return _items;
        }
        
        public bool MeetsRequirements(Player player)
        {
            // omg i love linqy
            //TODO: check to see if this works with money items
            return _price.All(pair => player.NumberOfItem(pair.Key) >= pair.Value);
        }

        public void AcceptTrade(Player player)
        {
            // Add items in trade to the player
            foreach (var pair in _items)
            {
                for (int i = 0; i < pair.Value; i++)
                {
                    player.GiveItem(pair.Key);
                }
            }
            
            // Remove items from player's inventory
        }
    }
}

// How to store trades:
/*
 * Need to have item(s) for which the player trades
 * Could have a system where each item has a base "value"
 * This value can then be used to generate a request
 * E.g. Money has value 1, C1 has value 5 and C2 has value 20
 * This means that to trade for C2 one possible trade is 2 x C1 and 10 x Money
 * Based on the value of the items to trade for, a different attribute called
 * something like "merchantBahvaiour" can determine what to change trade value by:
 * Generous - 
 * Neutral  -
 * Stingy   -
 */