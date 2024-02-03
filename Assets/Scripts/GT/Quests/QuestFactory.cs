using GT.Quests.Concrete;
using System;
using System.Collections.Generic;
using GT.Characters.Npcs;
using GT.Items;
using GT.Items.Cards;
using GT.Items.Money;

namespace GT.Quests
{
    public class QuestFactory
    {
        private readonly Random _rng;
        private List<Npc>? _npcs = null;
        
        public QuestFactory(Random rng)
        {
            _rng = rng;
        }
        
        /// <summary>
        /// This must happen before generation.
        /// </summary>
        /// <param name="npcs">List of interactive NPCs in the game.</param>
        public void SetNpcs(List<Npc> npcs)
        {
            _npcs = npcs;
        }
        
        // Create a random quest based on the inputs to the function.
        // This function should only be called when the game needs a quest
        // to assign to an npc/ give to player.

        //TODO: Find a way of arbitrarily increasing the difficulty of a quest
        //      This should be something like an enum that increases the maximum
        //      number of required items

        public Quest? CreateQuest()
        {
            if (_npcs == null)
            {
                throw new Exception("Must attach a list of NPCs to work with.");
            }
            
            int randomNumber = _rng.Next(100);

            if (randomNumber < 50)
            {
                return null;
            }

            // new random number
            randomNumber = _rng.Next(100);

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