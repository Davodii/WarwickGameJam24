
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

namespace NpcGen
{
    [CustomEditor(typeof(NpcFactory))]
    public class NpcFactoryEditor : Editor
    {

        private NpcSkinColour _skinColour;
        private NpcHairColour _hairColour;

        public override void OnInspectorGUI()
        {
            System.Random rand = new System.Random();
            
            NpcFactory myTarget = (NpcFactory)target;

            DrawDefaultInspector();

            _skinColour = (NpcSkinColour)EditorGUILayout.EnumPopup("Skin colour: ", _skinColour);
            _hairColour = (NpcHairColour)EditorGUILayout.EnumPopup("Hair colour: ", _hairColour);

            if (GUILayout.Button("Random Attributes"))
            {
                _skinColour = (NpcSkinColour) rand.Next(3);
                _hairColour = (NpcHairColour) rand.Next(4);
            }

            if (GUILayout.Button("Generate NPC"))
            {
                myTarget.GenerateNpc(rand.Next().ToString(),NpcSkinColour.White, NpcHairColour.Ginger);
            }
        }
    }
}