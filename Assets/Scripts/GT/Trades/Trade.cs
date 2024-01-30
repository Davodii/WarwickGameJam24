using GT.Items;

namespace GT.Trades
{
    public sealed class Trade
    {
        private readonly IReadOnlyDictionary<IItem, int> _requirements;
        private readonly IReadOnlyDictionary<IItem, int> _rewards;

        public Trade(IReadOnlyDictionary<IItem, int> requirements, IReadOnlyDictionary<IItem, int> rewards)
        {
            _rewards = rewards;
            _requirements = requirements;
        }
    }
}