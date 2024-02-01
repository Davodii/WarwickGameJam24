using System.Collections.Generic;
using GT.Characters;
using GT.Characters.Npcs;
using GT.Items;

namespace GT.Quests.Concrete
{
    public class BullyQuest : Quest
    {
        private readonly List<Npc> _toBully;
        
        public BullyQuest(
            string request,
            string completion, List<Npc> toBully,
            Dictionary<IItem, int> rewards)
                : base(request, completion, null!, rewards)
        {
            _toBully = toBully;
            
            // Assign the quest type
            QuestType = EQuestType.Bully;
        }

        public override bool MeetsRequirements(Player player)
        {
            bool bullied = true;
            foreach (Npc npc in _toBully)
            {
                if (!player.HasBullied(npc))
                {
                    bullied = false;
                }
            }

            return bullied;
        }

        public override string ToString()
        {
            string result = string.Empty;
            foreach (Npc npc in _toBully)
            {
                string bulliedName = npc.ToString();
                result += "Bully " + bulliedName + "\n";
            }
            
            // Get the base result
            result += base.ToString();
            
            return result;
        }
    }
}