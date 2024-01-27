namespace GT.Events
{
    public interface IEvent
    {
        bool WillHappen();
        string GetPrompt();
        void Result(Game game);
    }
}