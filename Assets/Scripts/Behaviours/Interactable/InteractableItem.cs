using System;
using GT;
using GT.Items;
using GT.Items.Cards;
using GT.Items.Misc;
using UI.SpriteManager;
using UnityEngine;

namespace Behaviours.Interactable
{
    public class InteractableItem : MonoBehaviour
    {
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
                    player.GiveCard((Card)_item);
                }
            } else if (_item.GetItemType() == EItemType.Money)
            {
                Debug.Log("Collected money");
                player.ModifyMoney(_count);
            } else if (_item.GetItemType() == EItemType.Misc)
            {
                for (int i = 0; i < _count; i++)
                {
                    Debug.Log("Collected misc item");
                    player.GiveItem(_item);
                }
            }
            
            // remove this game instance
            Destroy(this.gameObject);
        }
    }
}