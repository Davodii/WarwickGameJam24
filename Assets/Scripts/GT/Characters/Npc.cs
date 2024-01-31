using System;
using GT.Quests;
using GT.Trades;

namespace GT.Characters
{
    public sealed class Npc
    {
        private readonly string _name;
        private readonly Trade? _trade = null;
        private readonly Quest? _quest = null;

        public Npc(string name, Trade? dailyTrade, Quest? quest)
        {
            _name = name;
            _trade = dailyTrade;
            _quest = quest;
        }

        public bool HasQuest()
        {
            return _quest == null;
        }

        public bool HasTrade()
        {
            return _trade == null;
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
        
        public override string ToString()
        {
            return _name;
        }
    }
}