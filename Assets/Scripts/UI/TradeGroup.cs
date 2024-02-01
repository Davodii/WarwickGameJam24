using System;
using System.Collections.Generic;
using GT.Items;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Random = System.Random;

namespace UI
{
    public class TradeGroup : MonoBehaviour
    {
        // Stores items required for a trade / other things

        [Header("Background")] [SerializeField]
        private List<Sprite> backgroundSprites;
        
        [Header("UI Elements")]
        [SerializeField] private RawImage background;
        [SerializeField] private RawImage itemSprite;
        [SerializeField] private TMP_Text itemCount;

        public void SetItem(IItem item, int count)
        {
            // Set the correct UI for the item and the count
            //TODO: convert Items to icons
            // Maybe some sort of script that matches IItem to sprites??
            
            // Set count text
            itemCount.text = "x" + count.ToString();
        }

        public void Awake()
        {
            // Set the background sprite randomly when teh object is created
            Random rand = new Random();
            Sprite sprite = backgroundSprites[rand.Next(backgroundSprites.Count)];
            background.texture = sprite.texture;
        }
    }
}