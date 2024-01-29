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
        public string GetOwner()
        {
            return _owner.ToString();
        }
        
        public void Give(Player player)
        {
            player.GiveItem(this);
        }
    }
}