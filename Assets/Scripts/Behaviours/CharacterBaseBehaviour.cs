using System;
using GT.Characters;
using UnityEngine;

namespace Behaviours
{
    public class CharacterBaseBehaviour : MonoBehaviour
    {
        // Handles base character behaviour
        
        // Contains public accessors of sprites
        // Contains animators for each "limb"

        [Header("Sprites")] 
        public SpriteRenderer hair;
        public SpriteRenderer head;
        public SpriteRenderer torso;
        public SpriteRenderer legs;

        [Header("Animators")]
        public string aaah = "aaah";
        
    }
}