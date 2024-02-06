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
        private bool _completed;

        public Trade(IReadOnlyDictionary<IItem, int> rewards, IReadOnlyDictionary<IItem, int> requirements)
        {
            _requirements = requirements;
            _rewards = rewards;
            _completed = false;
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

        public bool Completed()
        {
            return _completed;
        }

        public void AcceptTrade(Player player)
        {
            if (!_completed)
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

            // Complete the trade
            _completed = true;
        }
    }
}
