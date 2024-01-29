using GT.Items;
using System.Collections.Generic;
using GT.Characters;

namespace GT.Quests
{
    public abstract class Quest : IQuest
    {
        private bool _completed = false;
        private bool _started = false;
        private string _request;
        private string _completion;
        private readonly Dictionary<IItem, int> _requirements;
        private readonly Dictionary<IItem, int> _rewards;

        public Quest(string request, string completion, Dictionary<IItem, int> requirements, Dictionary<IItem, int> rewards)
        {
            _rewards = rewards;
            _requirements = requirements;
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
            foreach (KeyValuePair<IItem, int> pair in _requirements)
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
            if (_requirements.Count > 0)
            {
                result += "Fetch: \n";
                foreach (var requirement in _requirements)
                {
                    result += " - " + requirement.Key.ToString() + "\n";
                }
            }

            return result;
        }
    }
}