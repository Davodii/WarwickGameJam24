using System;
using System.Collections.Generic;
using GT.Items;
using GT.Items.Blood;
using GT.Quests;
using GT.Trades;

namespace GT.Characters.Npcs
{
    public sealed class Npc
    {
        private readonly string _name;
        private readonly Trade? _trade = null;
        private readonly Quest? _quest = null;
        private readonly IReadOnlyDictionary<IItem, int> _bullyRewards;

        public Npc(string name, Trade? dailyTrade, Quest? quest, IReadOnlyDictionary<IItem, int> bullyRewards)
        {
            _name = name;
            _trade = dailyTrade;
            _quest = quest;
            _bullyRewards = bullyRewards;
        }

        public bool HasQuest()
        {
            return _quest != null;
        }

        public bool HasTrade()
        {
            return _trade != null;
        }

        public Trade GetTrade()
        {
            if (!HasTrade())
            {
                throw new Exception("No trade exists to give.");
            }
            return _trade!;
        }

        public Quest GetQuest()
        {
            if (!HasQuest())
            {
                throw new Exception("No quest exists to give.");
            }
            return _quest!;
        }

        public bool AcceptTrade(Player player)
        {
            // Complete a trade based on the items in the trade
            if (!HasTrade())
            {
                throw new Exception("No trade exists to accept.");
            }

            // This function should only be called when the trade can be completed
            if (!_trade!.MeetsRequirements(player))
            {
                return false;
            }

            _trade.AcceptTrade(player);
            return true;
        }

        /// <summary>
        /// Give items that were taken off NPC as they were bullied,
        /// to the player.
        /// </summary>
        /// <param name="player">The player object that bullied the NPC.</param>
        public void GetBullied(Player player)
        {
            // Add items in trade to the player
            foreach (var pair in _bullyRewards)
            {
                IItem item = pair.Key;
                int count = pair.Value;
                for (int i = 0; i < count; i++)
                {
                    item.Give(player);
                }
            }
            
            // give the player a Blood object to prove they
            // have bullied this NPC
            new Blood(this).Give(player);
        }
        
        public override string ToString()
        {
            return _name;
        }
    }
}