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

        public override string ToString()
        {
            return _name;
        }
    }
}