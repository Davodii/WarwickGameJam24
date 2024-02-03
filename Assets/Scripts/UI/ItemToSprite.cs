using System;
using System.Collections.Generic;
using GT.Items;
using UnityEngine;

namespace UI
{
    [Serializable]
    public class ItemToSprite
    {
        // contain information about 
        [SerializeField] private List<Sprite> _sprites;
        [SerializeField] private EItemType _type;

        public List<Sprite> GetSprites()
        {
            return _sprites.GetRange(0, _sprites.Count);
        }

        public EItemType GetType()
        {
            return _type;
        }
    }
}