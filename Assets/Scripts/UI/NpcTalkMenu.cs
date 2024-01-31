using System;
using GT;
using GT.Characters;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;

namespace UI
{
    public class NpcTalkMenu : MonoBehaviour
    {
        // Need to :
        // Enable the menu 
        // Change the text/properties of each element

        [FormerlySerializedAs("name")]
        [Header("Text")]
        [SerializeField] private TMP_Text npcName;
        [SerializeField] private TMP_Text speech;

        [FormerlySerializedAs("buttonSection")]
        [Header("Buttons")] 
        [SerializeField] private GameObject initialButtons;
        [SerializeField] private GameObject tradeButtons;
        [SerializeField] private GameObject questButtons;

        [Header("Misc.")] 
        [SerializeField] private GameObject background;
        
        // Privates
        private Npc _npc;

        public void EnableMenu()
        {
            // Enable the menu
            background.SetActive(true);
            npcName.gameObject.SetActive(true);
            speech.gameObject.SetActive(true);
            
            // Button Section
            initialButtons.SetActive(true);
            tradeButtons.SetActive(false);
            questButtons.SetActive(false);
        }

        public void DisableMenu()
        {
            // Disable the menu
            background.SetActive(false);
            npcName.gameObject.SetActive(false);
            speech.gameObject.SetActive(false);
            
            // Buttons
            initialButtons.SetActive(false);
            tradeButtons.SetActive(false);
            questButtons.SetActive(false);
            
            // Remove reference to npc
            // since the menu is closed and the player went away
            _npc = null;
        }

        
        public void Trade()
        {
            // Called externally by the "see trade" button
            
            // Check if there is no trade
            if (!_npc.HasQuest())
            {
                //TODO: Auto generate this
                speech.text = "Fuck off I don't have anything for you";
                return;
            }
            
            
            // Update buttons
            initialButtons.SetActive(false);
            tradeButtons.SetActive(true);
            
            // Update Text / Screen things
        }

        public void AcceptTrade()
        {
            // Check if can trade
            // testuing
        }

        public void Quest()
        {
            // Called externally by the "see quest" button
            
            // Get Quest to display
            // Quest requires:
            //  - quest dialogue
            //  - requirements
            //  - rewards
            //  - accept quest button
            //      - this can turn into a "complete quest" button after the quest is accepted
            
            // Check if there is no quest
            Debug.Log(_npc.HasQuest());
            if (!_npc.HasQuest())
            {
                //TODO: Auto generate this
                speech.text = "What the hell am i supposed to tell you to do?";
                return;
            }
            
            // Update buttons
            initialButtons.SetActive(false);
            questButtons.SetActive(true);
            
            // Show requirements
        }

        public void AcceptQuest()
        {
            // Check if can complete quest
            
            
        }

        public void Bully()
        {
            // Bully the kid
            // Give "blood" to the player
            // Potentially: Give items to player
            // Change what the NPC has said
            // Trigger teacher seeing the bully happen event
            
            // This button should be removed if this kid has already been bullied
            
            // Bully the kid
        }

        public void Back()
        {
            // Go back to initial screen 
            
            // Update buttons
            initialButtons.SetActive(true);
            questButtons.SetActive(false);
            tradeButtons.SetActive(false);
            
            // Update text
            speech.text = GenerateString();
        }

        public void Awake()
        {
            DisableMenu();
        }

        //TODO: maybe move this out of here
        private string GenerateString()
        {
            return
                "My golly gosh, who in the dickens are you? You have given me a right scare! You should be very ashamed";
        }

        
        /// <summary>
        /// Use this to set the required information depending on the
        /// character the player is talking to
        /// </summary>
        public void SetNpc(Npc npc)
        {
            // Update variables
            _npc = npc;
            npcName.text = _npc.ToString();
            //TODO: "Conversation dialogue" generation
            speech.text = GenerateString();
            
            
        }
        
        
    }
}
