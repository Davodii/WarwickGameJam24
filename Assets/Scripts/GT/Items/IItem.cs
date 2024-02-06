using System;
using GT.Characters;

namespace GT.Items
{
    public interface IItem : IEquatable<IItem>
    {
        EItemType GetItemType();
        void Give(Player player);
        void Remove(Player player);
        int GetHashCode();
    }
}