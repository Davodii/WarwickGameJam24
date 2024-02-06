using System;
using System.Collections.Generic;
using GT;
using GT.Items.Cards;
using UnityEngine;
using UnityEngine.UI;

namespace UI.Interactions
{
    public class TeacherInteractionMenu : MonoBehaviour
    {
        [SerializeField] private List<Button> incrementButtons;
        [SerializeField] private List<Button> decrementButtons;
        [SerializeField] private List<ItemUIGroup> cardIcons;
        [SerializeField] private GameObject background, content;

        private Game _game;
        private void Awake()
        {
            _game = Game.GetInstance();
            
            DisableMenu();
            
            /* TESTING */
            Card c1 = new Card(ECardValue._1);
            c1.Give(_game.GetPlayer());
            c1.Give(_game.GetPlayer());
            c1.Give(_game.GetPlayer());
            c1 = new Card(ECardValue._2);
            c1.Give(_game.GetPlayer());
            c1.Give(_game.GetPlayer());
            c1 = new Card(ECardValue._4);
            c1.Give(_game.GetPlayer());
            c1.Give(_game.GetPlayer());
            c1.Give(_game.GetPlayer());
            c1.Give(_game.GetPlayer());
            /* END */
        }

        public void EnableMenu()
        {
            
            // Enable highest parent
            background.SetActive(true);
            content.SetActive(true);
            
            // Disable all decrement buttons
            foreach (var button in decrementButtons)
            {
                button.interactable = false;
            }

            // Set the corresponding item to each card UI element
            // Enable buttons if the player has 
            for (int i = 0; i < cardIcons.Count; i++)
            {
                var card = new Card((ECardValue)i);
                // Set the card
                cardIcons[i].SetItem(new Card((ECardValue)i), 0, true);

                Debug.Log(_game.GetPlayer().HasCard(card));
                incrementButtons[i].interactable = _game.GetPlayer().HasCard(card);
            }
        }

        public void DisableMenu()
        {
            background.SetActive(false);
            content.SetActive(false);
        }

        public void IncrementCard(int cardIconIndex)
        {
            // Increment the card ui
            var card = (Card)cardIcons[cardIconIndex].GetItem();
            var count = cardIcons[cardIconIndex].GetCount();
            
            // Check to see if the player has the card
            if (_game.GetPlayer().NumberOfCard(card) < count + 1) return;
            
            // Increment the card
            cardIcons[cardIconIndex].SetItem(card, count + 1, false);
            
            if (_game.GetPlayer().NumberOfCard(card) == count + 1)
            {
                // Disable the increment button
                incrementButtons[cardIconIndex].interactable = false;
            }
                
            // Enable the decrement button
            decrementButtons[cardIconIndex].interactable = true;
        }

        public void DecrementCard(int cardIconIndex)
        {
            // Decrement the card ui
            var card = (Card)cardIcons[cardIconIndex].GetItem();
            var count = cardIcons[cardIconIndex].GetCount();

            if (count - 1 < 0) return;
            
            // Decrement the card
            cardIcons[cardIconIndex].SetItem(card, count - 1, false);

            if (count - 1 <= 0)
            {
                // Disable the decrement button
                decrementButtons[cardIconIndex].interactable = false;
            }
                
            // Enable the increment button
            incrementButtons[cardIconIndex].interactable = true;
        }

        public void Accept()
        {
            // Give the cards to the teacher
            foreach (var item in cardIcons)
            {
                int cardCount = item.GetCount();
                Card card = (Card)item.GetItem();
                
                for(int i = 0; i < cardCount; i++)
                {
                    // Give this card to the teacher
                    // Change the count to zero
                    _game.DepositCard(card);
                }
            }
            
            // Testing (maybe)
            // "Re-draw" to enable/disable buttons
            EnableMenu();
        }
    }
}