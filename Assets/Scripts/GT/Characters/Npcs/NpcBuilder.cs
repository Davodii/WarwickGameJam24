using System;
using System.Collections.Generic;
using GT.Items;
using GT.Items.Money;
using GT.Quests;
using GT.Trades;

namespace GT.Characters.Npcs
{
    public class NpcBuilder
    {
        private string _name = string.Empty;
        private Trade? _dailyTrade = null;
        private Quest? _dailyQuest = null;
        private readonly Dictionary<IItem, int> _bullyRewards
            = new Dictionary<IItem, int>();

        private readonly List<string> _possibleNames = new List<string>() {
            "Ligang",
            "Alex",
            "James",
            "Richard",
            "Marcin",
            "Andrew",
            "David",
            "Kevin",
            "Clive",
            "Steven",
            "Jeff"
        };

        private readonly Stack<string> _namesRaffle = new Stack<string>();
        
        public NpcBuilder(Random rng)
        {
            // put names into stack in random order
            int numberOfNames = _possibleNames.Count;
            for (int i = 0; i < numberOfNames; i++)
            {
                int next = rng.Next(_possibleNames.Count);
                _namesRaffle.Push(_possibleNames[next]);
                // remove from selection
                _possibleNames.RemoveAt(next);
            }
        }

        public NpcBuilder GenerateName()
        {
            if (_namesRaffle.Count == 0)
            {
                throw new InvalidOperationException(
                    "Names stack is empty." +
                    "More NPCs are being generated than there are names to choose from.");
            }
            _name = _namesRaffle.Pop();
            return this;
        }

        public NpcBuilder GenerateTrade(TradeFactory tradeFactory)
        {
            _dailyTrade = tradeFactory.CreateTrade();
            return this;
        }

        public NpcBuilder GenerateQuest(QuestFactory questFactory)
        {
            _dailyQuest = questFactory.CreateQuest();
            return this;
        }

        public NpcBuilder GenerateBullyRewards()
        {
            // TODO: formalise
            _bullyRewards.Add(new Money(500), 1);
            return this;
        }

        public Npc Build()
        {
            return new Npc(_name, _dailyTrade, _dailyQuest, _bullyRewards);
        }
    }
}