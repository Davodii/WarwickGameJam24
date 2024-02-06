using System;
using System.Runtime.CompilerServices;
using GT.Characters;

namespace GT.Items.Misc
{
    public sealed class MiscItem : IItem
    {
        private const int HashDispersionMultiplier = 1000;
        private readonly EMiscItemType _miscItemType;
        
        public MiscItem(EMiscItemType miscItemType)
        {
            _miscItemType = miscItemType;
        }
        
        public EItemType GetItemType()
        {
            return EItemType.Misc;
        }

        public void Give(Player player)
        {
            player.GiveItem(this);
        }

        public void Remove(Player player)
        {
            player.RemoveItem(this);
        }
        
        public EMiscItemType GetMiscItemType()
        {
            return _miscItemType;
        }

        public bool Equals(IItem? other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;

            if (other.GetItemType() != EItemType.Misc) return false;
            return ((MiscItem)other).GetMiscItemType() == GetMiscItemType();
        }

        public override int GetHashCode()
        {
            return (int)_miscItemType * HashDispersionMultiplier;
        }

        public override string ToString()
        {
            return _miscItemType switch
            {
                EMiscItemType.Rock => "Rock",
                _ => throw new ArgumentOutOfRangeException()
            };
        }
    }
}