using System;
using System.Collections.Generic;
using System.Linq;
using GT.Items;
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
            if (item.GetItemType() == EItemType.Misc)
            {
                return GetMiscSprite(item, randomSprite);
            }

            return GetSprite(item, randomSprite);
        }

        private Sprite GetMiscSprite(IItem item, bool randomSprite)
        {
            foreach (var mapping in miscItemSpriteMappings.Where(mapping => mapping.GetType() == ((MiscItem)item).GetMiscItemType()))
            {
                if (randomSprite)
                {
                    return mapping.GetSprites()[_rand.Next(mapping.GetSprites().Count)];
                }

                return mapping.GetSprites()[0];
            }

            return null;
        }

        private Sprite GetSprite(IItem item, bool randomSprite)
        {
            foreach (var mapping in itemSpriteMappings.Where(mapping => mapping.GetType() == item.GetItemType()))
            {
                if (randomSprite)
                {
                    return mapping.GetSprites()[_rand.Next(mapping.GetSprites().Count)];
                }

                return mapping.GetSprites()[0];
            }

            return null;
        }
    }
}
