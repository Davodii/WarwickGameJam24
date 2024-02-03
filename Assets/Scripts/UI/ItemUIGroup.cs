using System;
using System.Collections.Generic;
using System.Linq;
using GT.Items;
using GT.Items.Cards;
using GT.Items.Misc;
using TMPro;
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

        [Header("Items")] [SerializeField] private List<ItemToSprite> itemToSpriteMapping;

        private Random _rng;
        private IItem _item = null;
        private int _count = 0;

        public void SetItem(IItem item, int count)
        {
            // Set the correct UI for the item and the count
            if (item != null)
            {
                // Ensure gameobjects are enabled
                itemSprite.gameObject.SetActive(true);
                itemCount.gameObject.SetActive(true);

                // Ensure the item and count is different
                if (_item == null || !(_item.Equals(item) && _count == count))
                {
                    // Generate texture of sprite of item
                    Sprite correspondingSprite = GetSprite(item);
                    var texture = SpriteToTexture2D(correspondingSprite);
                    itemSprite.texture = texture;
                    _item = item;

                    // Set count text
                    _count = count;
                    itemCount.text = "x" + _count.ToString();
                }
            }
            else
            {
                // No item assigned
                // Empty cell
                itemSprite.gameObject.SetActive(false);
                itemCount.gameObject.SetActive(false);
            }
        }

        public void Awake()
        {
            _rng= new Random();
            
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

        private Sprite GetSprite(IItem item)
        {
            EItemType type = item.GetItemType();
            List<Sprite> availableSprites = new List<Sprite>();
            Sprite sprite = null;
            
            // Get the list of possible sprites
            foreach (var mapping in itemToSpriteMapping.Where(mapping => type == mapping.GetType()))
            {
                availableSprites.AddRange(mapping.GetSprites());
            }
            
            // Get the sprite depending on the item type
            if (type == EItemType.Card)
            {
                // Use the card enum to get the corresponding sprite
                Card card = (Card)item;
                sprite = availableSprites[(int)card.GetValue() * 3 + _rng.Next(3)];
            }
            else
            {
                // TODO: make this work with acutal misc items
                var miscItem = (MiscItem) item;
                sprite = availableSprites[_rng.Next(availableSprites.Count) + (int)miscItem.GetMiscItemType()];
            }

            return sprite;
        }
    }
}