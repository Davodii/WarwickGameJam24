using System;
using System.Collections.Generic;
using System.Linq;
using GT.Items;
using GT.Items.Cards;
using GT.Items.Misc;
using UnityEngine;
using Random = System.Random;

namespace UI.SpriteManager
{
    public class SpriteManager : MonoBehaviour
    {
        // Stores Sprite corresponding to items
        [SerializeField] private List<ItemToSprite> itemSpriteMappings;
        [SerializeField] private List<MiscItemToSprite> miscItemSpriteMappings;

        private Random _rand;

        public void Awake()
        {
            _rand = new Random();
        }

        /// <summary>
        /// Get a sprite mapped to the item provided.
        /// </summary>
        /// <param name="item"></param>
        /// <param name="randomSprite">Whether or not to use a random sprite or the first.</param>
        /// <returns></returns>
        public Sprite GetSpriteFromItem(IItem item, bool randomSprite)
        {
            return item.GetItemType() == EItemType.Misc ? GetMiscSprite(item, randomSprite) : GetSprite(item, randomSprite);
        }

        private Sprite GetMiscSprite(IItem item, bool randomSprite)
        {
            return miscItemSpriteMappings.Where(mapping => mapping.GetType() == ((MiscItem)item).GetMiscItemType()).Select(mapping => randomSprite ? mapping.GetSprites()[_rand.Next(mapping.GetSprites().Count)] : mapping.GetSprites()[0]).FirstOrDefault();
        }

        private Sprite GetSprite(IItem item, bool randomSprite)
        {
            foreach (var mapping in itemSpriteMappings.Where(mapping => mapping.GetType() == item.GetItemType()))
            {
                if (item.GetItemType() != EItemType.Card)
                    return randomSprite
                        ? mapping.GetSprites()[_rand.Next(mapping.GetSprites().Count)]
                        : mapping.GetSprites()[0];
                if (!randomSprite) return mapping.GetSprites()[0];
                var index = (int)((Card)item).GetValue() * 3 + _rand.Next(3);
                return mapping.GetSprites()[index];

            }

            return null;
        }
    }
}
