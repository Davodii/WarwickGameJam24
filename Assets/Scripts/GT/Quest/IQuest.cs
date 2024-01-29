using System.Collections.Generic;
using GT.Characters;
using GT.Items;

namespace GT.Quest
{
    public interface IQuest
    {
        void Complete();
        bool Completed();
        void Start();
        bool Started();
        IReadOnlyDictionary<IItem, int> Rewards();
        bool MeetsRequirements(Player player);
    }
}