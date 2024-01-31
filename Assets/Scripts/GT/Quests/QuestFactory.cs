using GT.Characters;
using GT.Quests.Concrete;
using System;

namespace GT.Quests
{
    public class QuestFactory
    {
        private readonly Random _rng;
        
        public QuestFactory(Random rng)
        {
            _rng = rng;
        }
        
        // Create a random quest based on the inputs to the function.
        // This function should only be called when the game needs a quest
        // to assign to an npc/ give to player.

        //TODO: Find a way of arbitrarily increasing the difficulty of a quest
        //      This should be something like an enum that increases the maximum
        //      number of required items
        
        public BullyQuest CreateBullyQuest()
        {
            // Create a bully quest
            
            // make sure the "giver" is not the same as the kid to bully
            return null;
        }

        public FetchQuest CreateFetchQuest()
        {
            // Create a fetch quest
            
            return null;
        }
    }
}