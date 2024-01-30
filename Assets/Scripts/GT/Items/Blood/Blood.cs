using System;
using GT.Characters;

namespace GT.Items.Blood
{
    public sealed class Blood : IItem, IEquatable<Blood>
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
        public string GetOwner()
        {
            return _owner.ToString();
        }

        public EItemType GetItemType()
        {
            return EItemType.Blood;
        }

        public void Give(Player player)
        {
            player.CollectBlood(this);
        }

        public bool Equals(Blood? other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return _owner.ToString().Equals(other._owner.ToString());
        }

        public override int GetHashCode()
        {
            return _owner.GetHashCode();
        }
    }
}