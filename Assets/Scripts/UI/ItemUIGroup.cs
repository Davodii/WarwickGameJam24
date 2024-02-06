using System;
using System.Collections.Generic;
using System.Linq;
using GT.Items;
using GT.Items.Cards;
using GT.Items.Misc;
using TMPro;
using UI.SpriteManager;
using UnityEngine;
using UnityEngine.UI;
using Random = System.Random;

namespace UI
{
    public class ItemUIGroup : MonoBehaviour
    {
        // Stores items required for a trade / other things

        [Header("Background")] [SerializeField]
        private List<Sprite> backgroundSprites;
        
        [Header("UI Elements")]
        [SerializeField] private RawImage background;
        [SerializeField] private RawImage itemSprite;
        [SerializeField] private TMP_Text itemCount;

        private SpriteManager.SpriteManager _spriteManager;
        private Random _rng;
        private IItem _item = null;
        private int _count = -1;

        public void SetItem(IItem item, int count, bool changeIcon)
        {
            // Set the correct UI for the item and the count
            if (item != null)
            {
                
                // Ensure gameobjects are enabled
                itemSprite.gameObject.SetActive(true);
                itemCount.gameObject.SetActive(true);

                // Ensure the item and count is different
                if (_item != null && (_item.Equals(item) && _count == count)) return;
                if (changeIcon)
                {
                    // Generate texture of sprite of item
                    var correspondingSprite = _spriteManager.GetSpriteFromItem(item, true);
                    var texture = SpriteToTexture2D(correspondingSprite);
                    itemSprite.texture = texture;
                    _item = item;
                }

                // Set count text
                _count = count;
                itemCount.text = "x" + _count.ToString();
            }
            else
            {
                // No item assigned
                // Empty cell
                itemSprite.gameObject.SetActive(false);
                itemCount.gameObject.SetActive(false);
            }
        }

        public IItem GetItem()
        {
            return _item;
        }

        public int GetCount()
        {
            return _count;
        }

        public void Awake()
        {
            _spriteManager = FindObjectOfType<SpriteManager.SpriteManager>();
            if(_spriteManager == null)
                Debug.LogError("No sprite manager found in scene!");

            _rng = new Random();
            
            // Set the background sprite randomly when teh object is created
            Sprite sprite = backgroundSprites[_rng.Next(backgroundSprites.Count)];
            background.texture = SpriteToTexture2D(sprite);
        }

        private Texture2D SpriteToTexture2D(Sprite sprite)
        {
            // Create a new texture
            var texture2D = new Texture2D((int)sprite.rect.width, (int)sprite.rect.height);
            
            // Apply pixels of the sprite to the texture
            var pixels = sprite.texture.GetPixels(
                (int)sprite.rect.x, 
                (int)sprite.rect.y, 
                (int)sprite.rect.width, 
                (int)sprite.rect.height );
            texture2D.SetPixels( pixels );
            
            // Apply and return the texture
            texture2D.Apply();
            return texture2D;
        }
    }
}