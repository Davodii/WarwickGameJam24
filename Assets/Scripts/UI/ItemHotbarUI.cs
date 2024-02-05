using System.Collections.Generic;
using GT;
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
            //TODO: FIX THIS <===
            
            // Get the player's items and assign to the inventory slots
            // Cards
            var invSlotIndex = 0;

            // Cards
            /*
            for (int i = 0; i < (int)ECardValue._5; i++)
            {
                int cardCount = _game.GetPlayer().NumberOfCard(new Card((ECardValue)i));
                if (cardCount > 0)
                {
                    inventorySlots[++invSlotIndex].SetItem(new Card((ECardValue)i), cardCount);
                }
            }
            */
            
            // Misc Items
            int miscItemCount = _game.GetPlayer().NumberOfItem(new MiscItem(EMiscItemType.Rock));
            Debug.Log(_game.GetPlayer().HasItem(new MiscItem(EMiscItemType.Rock)));
            if (miscItemCount > 0)
            {
                Debug.LogWarning("AAA");
                inventorySlots[++invSlotIndex].SetItem(new MiscItem(EMiscItemType.Rock), miscItemCount);
            }
            
            // Clear the remaining items
            for (int i = invSlotIndex; i < inventorySlots.Count; i++)
            {
                inventorySlots[i].SetItem(null, -1);
            }
        }
    }
}
