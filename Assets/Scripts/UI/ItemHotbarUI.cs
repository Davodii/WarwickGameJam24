using System.Collections.Generic;
using GT;
using GT.Items.Cards;
using GT.Items.Misc;
using UnityEngine;

namespace UI
{
    public class ItemHotbarUI : MonoBehaviour
    {
        private Game _game;
        
        [SerializeField] private List<ItemUIGroup> inventorySlots;
        
        public void Awake()
        {
            // Get reference of game
            _game = Game.GetInstance();
        }

        public void FixedUpdate()
        {
            //TODO: only update the ui when the player's inventory changes
            //TODO:^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^
            
            // Get the player's items and assign to the inventory slots
            // Cards
            var invSlotIndex = 0;

            // Cards
            for (int i = 0; i < (int)ECardValue._5; i++)
            {
                int cardCount = _game.GetPlayer().NumberOfCard(new Card((ECardValue)i));
                if (cardCount > 0)
                {
                    inventorySlots[invSlotIndex].SetItem(new Card((ECardValue)i), cardCount, true);
                    invSlotIndex++;
                }
            }
            
            // Misc Items
            int miscItemCount = _game.GetPlayer().NumberOfItem(new MiscItem(EMiscItemType.Rock));
            if (miscItemCount > 0)
            {
                inventorySlots[invSlotIndex].SetItem(new MiscItem(EMiscItemType.Rock), miscItemCount, true);
                invSlotIndex++;
            }
            
            // Clear the remaining items
            //TODO: Create better system to clear the inventory slots
            for (int i = invSlotIndex; i < inventorySlots.Count; i++)
            {
                inventorySlots[i].SetItem(null, -1, true);
            }
        }
    }
}
