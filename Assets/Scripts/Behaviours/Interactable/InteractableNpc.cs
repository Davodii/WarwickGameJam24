using System.Collections.Generic;
using GT;
using GT.Characters.Npcs;
using GT.Items;
using GT.Items.Cards;
using GT.Items.Misc;
using GT.Items.Money;
using GT.Quests.Concrete;
using GT.Trades;
using UnityEngine;

namespace Behaviours.Interactable
{
    public class InteractableNpc : MonoBehaviour
    {
        private Game _game;
        private Npc _npcReference;
        public void Awake()
        {
            // Get game instance
            _game = Game.GetInstance();
            
            // Get the NPC reference
            // TODO: make get npc
            
            // Reward
            Dictionary<IItem, int> rewards = new Dictionary<IItem, int>();
            rewards.Add(new Card(ECardValue._5), 2);
            rewards.Add(new MiscItem(EMiscItemType.Rock), 10);
            
            // Trade           
            Dictionary<IItem, int> requirements = new Dictionary<IItem, int>();
            requirements.Add(new Card(ECardValue._4), 1);
            Trade trade = new Trade(rewards, requirements);
            
            // Quest
            BullyQuest quest = new BullyQuest(
                "Plss bully this kid called <color=\"red\">PENIS HEAD!!?!</color>",
                "thx, really needed that :)", new List<Npc>() { null }, rewards);

            Dictionary<IItem, int> fetch = new Dictionary<IItem, int>();
            fetch.Add(new Card(ECardValue._1), 1);
            FetchQuest otherQuest = new FetchQuest("Can you get me these items: 1x Card Value 1", "OMG you did it",
                fetch, rewards);

            
            
            // Initialize npc and talk menu
            _npcReference = new Npc("Rando Bob", trade, otherQuest, rewards);

        }

        public Npc GetNpc()
        {
            return _npcReference; 
        }
    }
}