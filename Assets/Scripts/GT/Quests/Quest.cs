using GT.Items;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using GT.Characters;
using GT.Items.Blood;
using GT.Items.Cards;
using GT.Items.Money;

namespace GT.Quests
{
    public abstract class Quest : IQuest
    {
        private bool _completed = false;
        private bool _started = false;
        private string _request;
        private string _completion;
        protected readonly Dictionary<IItem, int> Requirements;
        private readonly Dictionary<IItem, int> _rewards;
        protected EQuestType QuestType;

        protected Quest(string request, string completion, Dictionary<IItem, int> requirements, Dictionary<IItem, int> rewards)
        {
            _rewards = rewards;
            Requirements = requirements;
            _request = request;
            _completion = completion;
        }

        public bool Completed()
        {
            return _completed;
        }

        public void Complete()
        {
            _completed = true;
        }

        public bool Started()
        {
            return _started;
        }

        public IReadOnlyDictionary<IItem, int> Rewards()
        {
            return _rewards;
        }

        public void Start()
        {
            _started = true;
        }

        public IReadOnlyDictionary<IItem, int> GetRewards()
        {
            return _rewards;
        }

        public EQuestType GetQuestType()
        {
            return QuestType;
        }

        public abstract bool MeetsRequirements(Player player);

        public void CompleteQuest()
        {
            Complete();
        }

        public override string ToString()
        {
            string result = "";
            // Any other requirements
            if (Requirements.Count > 0)
            {
                result += "Fetch: \n";
                foreach (var requirement in Requirements)
                {
                    result += " - " + requirement.Key.ToString() + "\n";
                }
            }

            return result;
        }

        public string GetRequest()
        {
            return _request;
        }
    }
}