using System;
using System.Collections.Generic;
using System.Linq;
using GT.Characters;
using GT.Items;
using GT.Items.Blood;
using GT.Items.Cards;

namespace GT.Quests.Concrete
{
    public sealed class FetchQuest : Quest
    {
        public FetchQuest(string request,
            string completion,
            Dictionary<IItem, int> requirements,
            Dictionary<IItem, int> rewards)
                : base(request, completion, requirements, rewards)
        {
            QuestType = EQuestType.Fetch;
        }
        
        public override bool MeetsRequirements(Player player)
        {
            return Requirements.All(pair =>
            {
                IItem item = pair.Key;
                EItemType itemType = item.GetItemType();
                int number = pair.Value;

                // only quest-able items should be included in requirements
                if (itemType != EItemType.Money
                    && itemType != EItemType.Card
                    && itemType != EItemType.Misc)
                {
                    throw new Exception("Not quest-able item attempted as quest requirement." + itemType);
                }

                switch (itemType)
                {
                    case EItemType.Money:
                        return player.HasBullied(((Blood)item).GetOwner());
                    case EItemType.Card:
                        return player.HasCard((Card)item);
                    default:
                        return player.NumberOfItem(item) >= number;
                }
            });
        }

        public override string ToString()
        {
            string result = "";
            foreach (var requirement in Requirements)
            {
                if (requirement.Key.GetItemType() == EItemType.Money)
                {
                    result += "- " + requirement.Key.ToString() + "\n";
                }
                else
                {
                    result += "- " + requirement.Value + "x " + requirement.Key.ToString() + "\n";
                }
                
            }

            return result;
        }
    }
}