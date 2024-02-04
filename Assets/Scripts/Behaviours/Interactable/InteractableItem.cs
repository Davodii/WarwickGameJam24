using System;
using GT;
using GT.Items;
using GT.Items.Cards;
using GT.Items.Misc;
using UnityEngine;

namespace Behaviours.Interactable
{
    public class InteractableItem : MonoBehaviour
    {
        private Game _game;
        private IItem _item;
        private int _count;

        public void Awake()
        {
            _game = Game.GetInstance();
            
            //TESTING
            _item = new MiscItem(EMiscItemType.Rock);
            _count = 3;
        }

        public void SetItem(IItem item, int count)
        {
            _item = item;
            _count = count;
            
            // Set Sprite?
        }

        public void CollectItem()
        {
            var player = _game.GetPlayer();
            if (_item.GetItemType() == EItemType.Card)
            {
                for (int i = 0; i < _count; i++)
                {
                    player.GiveCard((Card)_item);
                }
            } else if (_item.GetItemType() == EItemType.Money)
            {
                player.ModifyMoney(_count);
            } else if (_item.GetItemType() == EItemType.Misc)
            {
                for (int i = 0; i < _count; i++)
                {
                    player.GiveItem(_item);
                }
            }
        }
    }
}