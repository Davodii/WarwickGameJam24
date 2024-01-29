using GT.Characters;
using GT.Items;

namespace GT.Quest;

public abstract class Quest : IQuest
{
    private bool _completed = false;
    private bool _started = false;
    private readonly Dictionary<IItem, int> _rewards;

    public Quest(Dictionary<IItem, int> rewards)
    {
        _rewards = rewards;
    }
    
    public bool Completed()
    {
        return _completed;
    }

    public void Complete()
    {
        _completed = true;
    }

    public bool Started()
    {
        return _started;
    }

    public void Start()
    {
        _started = true;
    }

    public IReadOnlyDictionary<IItem, int> Rewards()
    {
        return _rewards;
    }

    public bool MeetsRequirements(Player player)
    {
        foreach (KeyValuePair<IItem, int> pair in _rewards)
        {
            // pair.Key = IItem type
            // pair.Value = number of item required
            int numberOfRequiredItem = player.NumberOfItem(pair.Key);

            if (numberOfRequiredItem < pair.Value)
            {
                return false;
            }
        }

        return true;
    }
}