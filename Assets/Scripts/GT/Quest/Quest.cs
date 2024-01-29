using GT.Items;
using System.Collections.Generic;
using GT.Characters;

namespace GT.Quest
{
    public abstract class Quest : IQuest
    {
        private bool _completed = false;
        private bool _started = false;
        private string _request;
        private string _completion;
        protected readonly Dictionary<IItem, int> Requirements;
        private readonly Dictionary<IItem, int> _rewards;

        public Quest(string request, string completion, Dictionary<IItem, int> requirements, Dictionary<IItem, int> rewards)
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

        public void Start()
        {
            _started = true;
        }

        public IReadOnlyDictionary<IItem, int> Rewards()
        {
            return _rewards;
        }

        public virtual bool MeetsRequirements(Player player)
        {
            foreach (KeyValuePair<IItem, int> pair in Requirements)
            {
                // pair.Key = IItem type
                // pair.Value = number of item required
                int numberOfRequiredItem = player.NumberOfItem(pair.Key);

                if (numberOfRequiredItem < pair.Value)
                {
                    return false;
                }
            }

            return true;
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
    }
}