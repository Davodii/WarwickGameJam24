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

        [Header("Buttons")] 
        [SerializeField] private GameObject buttonSection;

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
            buttonSection.SetActive(true);
        }

        public void DisableMenu()
        {
            // Disable the menu
            background.SetActive(false);
            npcName.gameObject.SetActive(false);
            speech.gameObject.SetActive(false);
            buttonSection.SetActive(false);
            
            // Remove reference to npc
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
            
            // Show the quest Menu
        }

        public void Bully()
        {
            // Bully the kid
            // Give "blood" to the player
            // Potentially: Give items to player
            // Change what the NPC has said
            // Trigger teacher seeing the bully happen event
            
            // This button should be removed if this kid has already been bullied
        }

        public void Awake()
        {
            DisableMenu();
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
            speech.text =
                "My golly gosh, who in the dickens are you? You have given me a right scare! You should be very ashamed";
            
            
        }
        
        
    }
}
