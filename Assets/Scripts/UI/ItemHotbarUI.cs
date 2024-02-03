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
        private List<Card> _cards = new List<Card>();
        
        public void Awake()
        {
            // Get reference of game
            _game = Game.GetInstance();
            
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

            //TODO: Use this in actual game
            /*
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
            */
            
            // TESTING ONLY:
            inventorySlots[0].SetItem(new Card(ECardValue._2), 3);
            inventorySlots[1].SetItem(new Card(ECardValue._4), 2);
            inventorySlots[2].SetItem(new Card(ECardValue._5), 1);
            inventorySlots[3].SetItem(new Card(ECardValue._1), 7);
            inventorySlots[4].SetItem(new MiscItem(EMiscItemType.Rock), 3);
            // Clear other items
            inventorySlots[5].SetItem(null, 0);
            inventorySlots[6].SetItem(null, 0);
        }
    }
}
