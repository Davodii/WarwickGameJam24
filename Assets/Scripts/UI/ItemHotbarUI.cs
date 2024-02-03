using System.Collections.Generic;
using GT;
using GT.Items.Cards;
using UnityEngine;

namespace UI
{
    public class ItemHotbarUI : MonoBehaviour
    {
        private Game _game;
        
        [SerializeField] private List<ItemUIGroup> inventorySlots;
        private List<Card> _cards;
        
        public void Awake()
        {
            // Get reference of game
            _game = new Game();
            
            // Add cards to list
            _cards.Add(new Card(ECardValue._1));
            _cards.Add(new Card(ECardValue._2));
            _cards.Add(new Card(ECardValue._3));
            _cards.Add(new Card(ECardValue._4));
            _cards.Add(new Card(ECardValue._5));
        }

        public void FixedUpdate()
        {
            // Get the player's items and assign to the inventory slots
            // Cards
            var invSlotIndex = 0;

            foreach (var card in _cards)
            {
                int count = _game.GetPlayer().NumberOfCard(card);
                if (count > 0)
                {
                    // Set the card and count at the current inventory slot
                    inventorySlots[invSlotIndex].SetItem(card, count);
                    invSlotIndex++;
                }
            }
            // Misc
        }
    }
}
