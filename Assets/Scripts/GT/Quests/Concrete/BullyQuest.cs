using GT.Characters;
using GT.Items;

namespace GT.Quests.Concrete
{
    public class BullyQuest : Quest
    {
        private readonly List<Npc> _toBully;
        
        public BullyQuest(string request, string completion, List<Npc> toBully, Dictionary<IItem, int> requirements,
            Dictionary<IItem, int> rewards) : base(request, completion, requirements, rewards)
        {
            _toBully = toBully;
        }

        public override bool MeetsRequirements(Player player)
        {
            // needs to meet other requirements (maybe other items)
            bool meetsBaseRequirements = base.MeetsRequirements(player);
            
            bool bullied = true;
            foreach (Npc npc in _toBully)
            {
                if (!player.HasBullied(npc))
                {
                    bullied = false;
                }
            }

            return bullied && meetsBaseRequirements;
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