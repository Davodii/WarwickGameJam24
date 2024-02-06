using System;
using System.Collections.Generic;
using GT.Items;
using GT.Items.Misc;
using UnityEngine;

namespace UI.SpriteManager
{
    [Serializable]
    public class MiscItemToSprite
    {
        // contain information about 
        [SerializeField] private List<Sprite> sprites;
        [SerializeField] private EMiscItemType type;

        public List<Sprite> GetSprites()
        {
            return sprites.GetRange(0, sprites.Count);
        }

        public new EMiscItemType GetType()
        {
            return type;
        }
    }
}