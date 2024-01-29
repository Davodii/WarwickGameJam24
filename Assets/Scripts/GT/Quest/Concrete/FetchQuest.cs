using GT.Items;

namespace GT.Quest.Concrete
{
    public sealed class FetchQuest : Quest
    {
        public FetchQuest(string request, string completion, Dictionary<IItem, int> requirements, Dictionary<IItem, int> rewards) : base(request, completion, requirements, rewards)
        {
        }
    }
}