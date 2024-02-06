using GT;
using GT.Characters.Npcs;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Random = System.Random;

namespace UI.Interactions
{
    public class NpcTalkMenu : MonoBehaviour
    {
        // Need to :
        // Enable the menu 
        // Change the text/properties of each element

        [Header("Text")] [SerializeField]
        private TMP_Text npcName;

        [SerializeField] private TMP_Text speech;

        [Header("Trading")] [SerializeField] private TradeSectionContextMenu tradeSection;

        [Header("Button Groups")] 
        [SerializeField] private GameObject initialButtons;
        [SerializeField] private GameObject tradeButtons;
        [SerializeField] private GameObject questButtons;
        [SerializeField] private GameObject background;

        [Header("Buttons")] 
        [SerializeField] private Button questButton;
        [SerializeField] private Button tradeButton;
        [SerializeField] private Button bullyButton;
        [SerializeField] private Button acceptQuestButton;
        [SerializeField] private Button acceptTradeButton;

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

            // Disable/Enable the quest/trade/bully button
            questButton.interactable = _npc.HasQuest() && !_npc.GetQuest().Completed();
            tradeButton.interactable = _npc.HasTrade() && !_npc.GetTrade().Completed();
            bullyButton.interactable = !_game.GetPlayer().HasBullied(_npc);
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
            if (!_npc.HasTrade() || _npc.GetTrade().Completed())
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
            
            // Update trade button
            acceptTradeButton.interactable = _npc.GetTrade().MeetsRequirements(_game.GetPlayer());
        }

        public void AcceptTrade()
        {
            // Check if can trade
            // I.e. if the player has the requirements for the trade
            if(_npc.GetTrade().MeetsRequirements(_game.GetPlayer()) && !_npc.GetTrade().Completed())
            {
                // Accept the trade
                // Update the trade button
                acceptTradeButton.interactable = false;
                
                _npc.GetTrade().AcceptTrade(_game.GetPlayer());
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
            // Check if there is no quest
            
            if (!_npc.HasQuest() || _npc.GetQuest().Completed())
            {
                Random rand = new Random();
                speech.text = _noQuestResponses[rand.Next(_noQuestResponses.Length)];
                return;
            }
            
            // Update buttons
            initialButtons.SetActive(false);
            questButtons.SetActive(true);
            acceptQuestButton.interactable = true;
            var buttonText = acceptQuestButton.GetComponentInChildren<TMP_Text>();
            buttonText.text = "Accept Quest";

            if (_npc.GetQuest().Started())
            {
                // Change the accept quest text to "complete quest"
                buttonText.text = "Complete Quest";
                
                // Disable button if the player does not meet requirements
                if (!_npc.GetQuest().MeetsRequirements(_game.GetPlayer()))
                {
                    acceptQuestButton.interactable = false;
                }
            }
            
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

            var buttonText = acceptQuestButton.GetComponentInChildren<TMP_Text>();
            buttonText.text = "Complete Quest";

            if (_npc.GetQuest().Completed())
            {
                acceptQuestButton.interactable = false;
            } 
            else if (!_npc.GetQuest().Started())
            {
                _npc.GetQuest().Start(_game.GetPlayer());
                // Disable button if the player does not meet the requirements
                if (!_npc.GetQuest().MeetsRequirements(_game.GetPlayer()))
                {
                    acceptQuestButton.interactable = false;
                }
            }
            else
            {
                if (_npc.GetQuest().MeetsRequirements(_game.GetPlayer()))
                {
                    // Add rewards to the player
                    // Complete the quest
                    _npc.GetQuest().CompleteQuest(_game.GetPlayer());
                    acceptQuestButton.interactable = false;
                }
            }
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
            _npc.GetBullied(_game.GetPlayer());
            bullyButton.interactable = false;
            speech.text = "<color=\"red\">WHAT THE HELL DID I DO TO YOU??</color>";
        }

        public void Back()
        {
            // Delete any Trade icons generated
            foreach (var group in tradeSection.gameObject.GetComponentsInChildren<ItemUIGroup>())
            {
                DestroyImmediate(group.gameObject);
            }
            
            EnableMenu();
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
