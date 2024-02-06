using System.Collections.Generic;
using GT.Characters;
using GT.Items;

namespace GT.Quests
{
    public interface IQuest
    {
        void Complete();
        bool Completed();
        void Start(Player player);
        bool Started();
        IReadOnlyDictionary<IItem, int> Rewards();
        bool MeetsRequirements(Player player);
    }
}