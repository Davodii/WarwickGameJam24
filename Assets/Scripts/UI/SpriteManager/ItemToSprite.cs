using System;
using System.Collections.Generic;
using GT.Items;
using UnityEngine;

namespace UI.SpriteManager
{
    [Serializable]
    public class ItemToSprite
    {
        // contain information about 
        [SerializeField] private List<Sprite> sprites;
        [SerializeField] private EItemType type;

        public List<Sprite> GetSprites()
        {
            return sprites.GetRange(0, sprites.Count);
        }

        public new EItemType GetType()
        {
            return type;
        }
    }
}