using System.Collections.Generic;
using GT.Characters;
using GT.Items;
using GT.Items.Blood;

namespace GT.Quest.Concrete
{
    public class BullyQuest : Quest
    {
        private List<Blood> _toBully;
        public BullyQuest(string request, string completion, List<Blood> toBully, Dictionary<IItem, int> requirements,
            Dictionary<IItem, int> rewards) : base(request, completion, requirements, rewards)
        {
            _toBully = toBully;
        }

        public override bool MeetsRequirements(Player player)
        {
            bool meetsBaseRequirements = base.MeetsRequirements(player);
            bool bullied = true;
            foreach (Blood blood in _toBully)
            {
                // TODO: Get a way of checking if the player has bullied a kid
                bullied = false;
            }

            return bullied && meetsBaseRequirements;
        }

        public override string ToString()
        {
            string result = "";
            foreach (Blood blood in _toBully)
            {
                string bullyName = blood.ToString();
                result += "Bully " + bullyName + "\n";
            }
            
            // Get the base result
            result += base.ToString();
            
            return result;
        }
    }
}