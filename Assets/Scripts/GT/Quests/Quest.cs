using GT.Items;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using GT.Characters;
using GT.Items.Blood;
using GT.Items.Cards;
using GT.Items.Money;
using Debug = UnityEngine.Debug;

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

        public void Start(Player player)
        {
            _started = true;
            player.StartQuest(this);
        }

        public EQuestType GetQuestType()
        {
            return QuestType;
        }

        public abstract bool MeetsRequirements(Player player);

        public void CompleteQuest(Player player)
        {
            Complete();
            
            // Remove requirements from player
            foreach (var requirement in Requirements)
            {
                for (int i = 0; i < requirement.Value; i++)
                {
                    requirement.Key.Remove(player);
                }
            }
            
            // Add rewards to player
            foreach (var reward in _rewards)
            {
                for (int i = 0; i < reward.Value; i++)
                {
                    Debug.Log("Giving player " + reward.Key.ToString());
                    reward.Key.Give(player);
                }
            }
        }

        public abstract string ToString();

        public string GetRequest()
        {
            return _request;
        }
    }
}