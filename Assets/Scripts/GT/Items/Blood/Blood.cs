using System;
using GT.Characters;

namespace GT.Items.Blood
{
    public sealed class Blood : IItem
    {
        private readonly Npc _owner;
        
        public Blood(Npc owner)
        {
            _owner = owner;
        }

        /// <summary>
        /// Get the name of the kid who the blood belongs to.
        /// </summary>
        /// <returns>The name of the Npc</returns>
        public Npc GetOwner()
        {
            return _owner;
        }

        public EItemType GetItemType()
        {
            return EItemType.Blood;
        }

        public void Give(Player player)
        {
            player.CollectBlood(this);
        }

        public void Remove(Player player)
        {
            throw new NotImplementedException();
        }

        public bool Equals(IItem? other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            
            if (other.GetItemType() != EItemType.Blood) return false;

            Blood otherBlood = (Blood)other;
            return _owner.ToString().Equals(otherBlood.GetOwner().ToString());
        }

        public override int GetHashCode()
        {
            return _owner.GetHashCode();
        }
    }
}