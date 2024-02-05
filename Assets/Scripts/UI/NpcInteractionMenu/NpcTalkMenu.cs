using GT;
using GT.Characters.Npcs;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;
using Random = System.Random;

namespace UI.NpcInteractionMenu
{
    public class NpcTalkMenu : MonoBehaviour
    {
        // Need to :
        // Enable the menu 
        // Change the text/properties of each element

        [FormerlySerializedAs("name")] [Header("Text")] [SerializeField]
        private TMP_Text npcName;

        [SerializeField] private TMP_Text speech;

        [Header("Trading")] [SerializeField] private TradeSectionContextMenu tradeSection;

        [FormerlySerializedAs("buttonSection")] [Header("Buttons")] [SerializeField]
        private GameObject initialButtons;

        [SerializeField] private GameObject tradeButtons;
        [SerializeField] private GameObject questButtons;

        [Header("Misc.")] [SerializeField] private GameObject background;

        // Privates
        private Npc _npc;
        private Game _game;
        
        //TODO: Make this betterer
        private readonly string[] _noTradeResponses = new[]
        {
            "Sorry, I don't have anything.",
            "Go away.",
            "I don't want to give you anything.",
            "<color=\"red\">Fuck off!</color>"
        };
        
        private readonly string[] _noQuestResponses = new[]
        {
            "Sorry, I don't have anything.",
            "Go away.",
            "I don't want to give you anything.",
            "<color=\"blue\">Why are you like this??</color>"
        };

        public void EnableMenu()
        {
            // Enable the menu
            background.SetActive(true);
            npcName.gameObject.SetActive(true);
            speech.gameObject.SetActive(true);
            tradeSection.gameObject.SetActive(false);
            
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
            tradeSection.gameObject.SetActive(false);
            
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
            if (!_npc.HasTrade())
            {
                Random rand = new Random();
                speech.text = _noTradeResponses[rand.Next(_noTradeResponses.Length)];
                return;
            }
            
            
            // Update buttons
            initialButtons.SetActive(false);
            tradeButtons.SetActive(true);
            
            // Update Text / Screen things
            tradeSection.gameObject.SetActive(true);
            speech.gameObject.SetActive(false);
            
            //TODO: Create trade layout / items
            
            // Add request items
            foreach (var pair in _npc.GetTrade().GetPrice())
            {
                tradeSection.AddRequest(pair.Key, pair.Value);
            }
            // Add reward items
            foreach (var pair in _npc.GetTrade().GetItems())
            {
                tradeSection.AddReward(pair.Key, pair.Value);
            }
            
        }

        public void AcceptTrade()
        {
            // Check if can trade
            // I.e. if the player has the requirements for the trade
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
            // Check if there is no quest
            
            if (!_npc.HasQuest())
            {
                Random rand = new Random();
                speech.text = _noQuestResponses[rand.Next(_noQuestResponses.Length)];
                return;
            }
            
            // Update buttons
            initialButtons.SetActive(false);
            questButtons.SetActive(true);
            
            // Show requirements
            speech.text = _npc.GetQuest().GetRequest();
            
        }

        public void AcceptQuest()
        {
            // Add the quest to the player if not added before
            // return
            
            // Check if player has met requirements and complete quest
            // remove requirements from the player
            // add rewards to the player


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
            tradeSection.gameObject.SetActive(false);
            
            // Update text
            speech.gameObject.SetActive(true);
            speech.text = GenerateString();
            
            // Delete any Trade icons generated
            foreach (var group in tradeSection.gameObject.GetComponentsInChildren<ItemUIGroup>())
            {
                DestroyImmediate(group.gameObject);
            }
        }

        public void Awake()
        {
            _game = Game.GetInstance();
            
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
