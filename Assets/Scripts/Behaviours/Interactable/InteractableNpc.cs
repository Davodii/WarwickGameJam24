using System.Collections.Generic;
using GT;
using GT.Characters.Npcs;
using GT.Items;
using GT.Items.Cards;
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
            
            // Trade
            Dictionary<IItem, int> rewards = new Dictionary<IItem, int>();
            rewards.Add(new Card(ECardValue._1), 2);
            Dictionary<IItem, int> requirements = new Dictionary<IItem, int>();
            requirements.Add(new Money(100), 10);
            Trade trade = new Trade(rewards, requirements);

            // Quest
            BullyQuest quest = new BullyQuest(
                "Plss bully this kid called <color=\"red\">PENIS HEAD!!?!</color>",
                "thx, really needed that :)", new List<Npc>() { null }, rewards);

            // Initialize npc and talk menu
            _npcReference = new Npc("Rando Bob", trade, quest, null);

        }

        public Npc GetNpc()
        {
            return _npcReference; 
        }
    }
}