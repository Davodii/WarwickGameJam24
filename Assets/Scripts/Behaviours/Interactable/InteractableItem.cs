using System;
using GT;
using GT.Items;
using GT.Items.Cards;
using GT.Items.Misc;
using GT.Items.Money;
using UI.SpriteManager;
using UnityEngine;

namespace Behaviours.Interactable
{
    public class InteractableItem : MonoBehaviour
    {
        
        // Assume if the item is money, then the money amount is stored 
        // within the money object and count is 1.
        private Game _game;
        private IItem _item;
        private int _count;

        private SpriteRenderer _spriteRenderer;
        private SpriteManager _spriteManager;

        public void Awake()
        {
            _game = Game.GetInstance();
            _spriteManager = FindObjectOfType<SpriteManager>();
            _spriteRenderer = GetComponent<SpriteRenderer>();
            
            //TESTING
            _item = new MiscItem(EMiscItemType.Rock);
            _count = 3;
        }

        public void SetItem(IItem item, int count)
        {
            _item = item;
            _count = count;
            
            // Set sprite to the new item
            _spriteRenderer.sprite = _spriteManager.GetSpriteFromItem(item, false);

        }

        public void CollectItem()
        {
            Debug.Log("Collect item");
            
            var player = _game.GetPlayer();
            if (_item.GetItemType() == EItemType.Card)
            {
                for (int i = 0; i < _count; i++)
                {
                    Debug.Log("Collected card");
                    ((Card)_item).Give(player);
                }
            } else if (_item.GetItemType() == EItemType.Money)
            {
                Debug.Log("Collected money");
                ((Money)_item).Give(player);
            } else if (_item.GetItemType() == EItemType.Misc)
            {
                for (int i = 0; i < _count; i++)
                {
                    Debug.Log("Collected misc item");
                    ((MiscItem)_item).Give(player);
                }
            }
            
            // remove this game instance
            Destroy(this.gameObject);
        }
    }
}