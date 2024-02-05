using System;
using Behaviours.Interactable;
using GT;
using GT.Items.Misc;
using UI;
using UI.NpcInteractionMenu;
using UnityEngine;

namespace Behaviours
{
    public class PlayerController : MonoBehaviour
    {
        // Control player movement
        [Header("Movement Variables")] 
        [SerializeField] private float movementSpeed;
    
        
        //TODO: Setup a UI manager that the player can use to 
        // enable/disable UI elements
        [Header("UI")] 
        [SerializeField] private NpcTalkMenu talkMenu;
        [SerializeField] private InteractionPopup interactionPopup;
        
        // Privates
        private Rigidbody2D _rb2d;
        private EPlayerInteractionState _interactionState;
        private GameObject _interactable;
        
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
            
            Debug.Log(Game.GetInstance().GetPlayer().NumberOfItem(new MiscItem(EMiscItemType.Rock)));
        }
        
        public void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject.layer != 8 /* Interactable */) return;
            
            var o = other.gameObject;
            _interactable = o;
            _interactionState = o.tag switch
            {
                "NPC" => EPlayerInteractionState.Npc,
                "Item" => EPlayerInteractionState.Item,
                "Teacher" => EPlayerInteractionState.Teacher,
                _ => _interactionState
            };
            
            interactionPopup.TrackObject(other.transform);
        }

        public void OnTriggerExit2D(Collider2D other)
        {
            if (other.gameObject.layer != 8 /* Interactable */) return;
            _interactable = null;
            _interactionState = EPlayerInteractionState.None;
                
            interactionPopup.StopTracking();
        }

        public void Update()
        {
            if (talkMenu == null) return;
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                talkMenu.DisableMenu();
            }
            if (!Input.GetKeyDown(KeyCode.E)) return;
            Debug.Log("E pressed");
            switch (_interactionState)
            {
                case EPlayerInteractionState.None:
                    Debug.Log("No interaction");
                    return;
                case EPlayerInteractionState.Npc:
                {
                    Debug.Log("NPC interaction");
                    var npc = _interactable.GetComponent<InteractableNpc>().GetNpc();
                    talkMenu.EnableMenu();
                    talkMenu.SetNpc(npc);
                    break;
                }
                case EPlayerInteractionState.Item:
                    Debug.Log("Item interaction");
                    var item = _interactable.GetComponent<InteractableItem>();
                    item.CollectItem();
                    break;
                case EPlayerInteractionState.Teacher:
                    // Bring up the teacher UI to trade cards
                    Debug.LogWarning("Teacher UI not implemented yet...");
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }
}
