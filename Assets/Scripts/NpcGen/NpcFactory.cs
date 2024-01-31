using System.Collections.Generic;
using Behaviours;
using UnityEngine;
using UnityEngine.Serialization;
using Random = System.Random;

namespace NpcGen
{
    public class NpcFactory : MonoBehaviour
    {
        // Generate an NPC gameobject to use in the game world
        // this will not generate an NPC with which the user can 
        // interact on the playground
        
        // NPCs should include the following:
        //  - Set sprites for their
        //      - hair, head, torso/arms, legs
        //  - Include animators to animate the character when
        //    moving and performing "actions"
        //      - this would probably just be part of a script on the npc
        
        // Generation requires:
        //  - skin colour
        //  - hair colour
        
        // The NPC generator should also be able to generate NPCs
        // outside of the game

        [SerializeField] private GameObject npcBasePrefab;
        
        // TODO change this to animations instead of just sprites
        [SerializeField] private List<Sprite> hairSprites;
        [SerializeField] private List<Sprite> headSprites;
        [SerializeField] private List<Sprite> torsoSprites;
        [SerializeField] private List<Sprite> legSprites;
        
        public GameObject GenerateNpc(string id, NpcSkinColour skinColour, NpcHairColour hairColour)
        {
            // Generate an NPC as per the requirements
            GameObject npc = Instantiate(npcBasePrefab, Vector3.zero, transform.rotation);
            
            // Get the NPC base behaviour
            CharacterBaseBehaviour baseBehaviour = npc.GetComponent<CharacterBaseBehaviour>();
            
            // Update npc based on properties
            Random rand = new Random();
            npc.name = id;
            
            //TODO: Yeh, maybe just change this to actually be good
            
            baseBehaviour.hair.sprite = hairSprites[rand.Next(hairSprites.Count)];
            baseBehaviour.head.sprite = headSprites[rand.Next(headSprites.Count)];
            baseBehaviour.torso.sprite = torsoSprites[rand.Next(torsoSprites.Count)];
            baseBehaviour.legs.sprite = legSprites[rand.Next(legSprites.Count)];
            
            return npc;
        }
    }
}