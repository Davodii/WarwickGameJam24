namespace GT.Quests
{
    public interface IQuest
    {
        // Accessors for quest properties
        string GetDescription();
        // Task(s)
        void GetTasks();
        
        // Rewards
        // Penalties
        // Need a way of processing rewards and/or penalites
        // can probably use the same object to store the attribute
        // to change and the change ammount
        // e.g a penalty of money would be {money, -10}
        
        // Functions
        void CompleteTask(/* Task to mark as complete/finish */);

        // This function will check if all the tasks are completed
        //      - if they are then the "reward" can be given to the player
        //      - if not then the "penalty" can be given to the player
        // 
        void CompleteQuest();

    }
}