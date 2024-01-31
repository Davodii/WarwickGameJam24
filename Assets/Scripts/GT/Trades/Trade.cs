using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using GT.Characters;
using GT.Items;
using GT.Items.Cards;
using GT.Items.Money;

namespace GT.Trades
{
    public sealed class Trade
    {
        // Items are the items the player receives
        // Price is the items the player needs to "give" for the trade
        private readonly IReadOnlyDictionary<IItem, int> _rewards;
        private readonly IReadOnlyDictionary<IItem, int> _requirements;

        public Trade(IReadOnlyDictionary<IItem, int> rewards, IReadOnlyDictionary<IItem, int> requirements)
        {
            _requirements = requirements;
            _rewards = rewards;
        }

        /// <summary>
        /// Used for displaying to UI
        /// </summary>
        /// <returns>Items required for trade as well as count of each</returns>
        public IReadOnlyDictionary<IItem, int> GetPrice()
        {
            return _requirements;
        }
        
        /// <summary>
        /// Used for displaying to UI
        /// </summary>
        /// <returns>Items player gets when trade is accepted</returns>
        public IReadOnlyDictionary<IItem, int> GetItems()
        {
            return _rewards;
        }
        
        public bool MeetsRequirements(Player player)
        {
            return _requirements.All(pair =>
            {
                IItem item = pair.Key;
                EItemType itemType = item.GetItemType();
                int number = pair.Value;

                // only trade-able items should be included in requirements
                if (itemType != EItemType.Card
                    && itemType != EItemType.Money
                    && itemType != EItemType.Misc)
                {
                    throw new Exception("Not trade-able item attempted as trade requirement." + itemType);
                }
                
                switch (itemType)
                {
                    case EItemType.Money:
                        return player.GetMoney() >= ((Money)item).GetValue();
                    case EItemType.Card:
                        return player.HasCard((Card)item);
                    default:
                        return player.NumberOfItem(item) >= number;
                }
            });
        }

        public void AcceptTrade(Player player)
        {
            // Add items in trade to the player
            foreach (var pair in _rewards)
            {
                IItem item = pair.Key;
                int count = pair.Value;
                for (int i = 0; i < count; i++)
                {
                    item.Give(player);
                }
            }
            
            // Remove items from player's inventory
            foreach (var pair in _requirements)
            {
                IItem item = pair.Key;
                int count = pair.Value;
                for (int i = 0; i < count; i++)
                {
                    item.Remove(player);
                }
            }
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