using GT.Characters;
using GT.Quests.Concrete;
using System;
using GT.Items;
using GT.Items.Cards;
using GT.Items.Money;

namespace GT.Quests
{
    public class QuestFactory
    {
        private readonly Random _rng;
        private readonly List<Npc> _npcs;
        
        public QuestFactory(Random rng, List<Npc> npcs)
        {
            _rng = rng;
            _npcs = npcs;
        }
        
        // Create a random quest based on the inputs to the function.
        // This function should only be called when the game needs a quest
        // to assign to an npc/ give to player.

        //TODO: Find a way of arbitrarily increasing the difficulty of a quest
        //      This should be something like an enum that increases the maximum
        //      number of required items

        public Quest CreateQuest()
        {
            // TODO: actual randomness
            int randomNumber = _rng.Next(100);

            if (randomNumber < 50)
            {
                return CreateFetchQuest();
            }
            else
            {
                return CreateBullyQuest();
            }
        }

        private FetchQuest CreateFetchQuest()
        {
            // TODO: formalise
            Dictionary<IItem, int> requirements = new Dictionary<IItem, int>();
            requirements.Add(new Card(ECardValue._2), 2);
            Dictionary<IItem, int> rewards = new Dictionary<IItem, int>();
            rewards.Add(new Money(500), 1);

            return new FetchQuest(
                "Get me this",
                "Thank you",
                requirements,
                rewards);
        }

        private BullyQuest CreateBullyQuest()
        {
            // TODO: formalise
            List<Npc> victims = new List<Npc>();
            Npc victim = _npcs[_rng.Next(_npcs.Count)]; // add a single target for now
            victims.Add(victim);

            return new BullyQuest($"Bully {victim}",
                "Thank you",
                victims,
                new Dictionary<IItem, int>());
        }
    }
}