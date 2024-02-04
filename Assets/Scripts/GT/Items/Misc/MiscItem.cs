using System;
using GT.Characters;

namespace GT.Items.Misc
{
    public sealed class MiscItem : IItem
    {
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
    }
}