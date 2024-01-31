using System;
using System.Collections.Generic;
using GT.Characters;
using GT.Items;
using GT.Items.Cards;
using GT.Items.Money;
using GT.Quests.Concrete;
using GT.Trades;
using UI;
using UnityEngine;

namespace Behaviours
{
    public class PlayerController : MonoBehaviour
    {
        // Control player movement
        [Header("Movement Variables")] 
        [SerializeField] private float movementSpeed;
    
        
        //TODO: Setup a UI manager that the player can use to 
        //      enable/disable UI elements
        [Header("UI")] 
        [SerializeField] private NpcTalkMenu talkMenu;
        
        // Privates
        private Rigidbody2D _rb2d;
        
        public void Awake()
        {
            _rb2d = this.GetComponent<Rigidbody2D>();
        }

        private Vector2 GetInput()
        {
            Vector2 input = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));

            return input.normalized;
        }        

        public void FixedUpdate()
        {
            // Get the input
            Vector2 input = GetInput();
            
            // Get the next position
            Vector2 newPosition = (Vector2)transform.position + (input * (movementSpeed * Time.fixedDeltaTime));
            
            // Move the player
            _rb2d.MovePosition(newPosition);
        }

        //TODO: remove everything after this comment
        public void OnTriggerStay2D(Collider2D other)
        {
            if (other.gameObject.tag.Equals("NPC"))
            {
                // Player is in NPC talk range
                if (Input.GetKey(KeyCode.E))
                {
                    if (talkMenu != null)
                    {
                        // Generate a random npc
                        Npc empty = new Npc("empty", null, null);
                        
                        // Trade
                        Dictionary<IItem, int> rewards = new Dictionary<IItem, int>();
                        rewards.Add(new Card(ECardValue._1), 2);
                        Dictionary<IItem, int> requirements = new Dictionary<IItem, int>();
                        rewards.Add(new Money(100), 2);
                        Trade trade = new Trade(rewards, requirements);
                        
                        // Quest
                        BullyQuest quest = new BullyQuest("Plss bully this kid called PENIS HEAD",
                            "thx, really needed that :)", new List<Npc>() { empty }, requirements, rewards);
                        
                        // Initialize npc and talk menu
                        Npc rando = new Npc("Bob", trade, quest);
                        talkMenu.SetNpc(rando);
                        talkMenu.EnableMenu();
                    }
                }
            }
        }

        public void Update()
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                if (talkMenu != null)
                {
                    talkMenu.DisableMenu();
                }
            }
        }
    }
}
