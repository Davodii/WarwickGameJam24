using GT.Characters;

namespace GT.Items
{
    public interface IItem
    {
        EItemType GetItemType();
        void Give(Player player);
    }
}