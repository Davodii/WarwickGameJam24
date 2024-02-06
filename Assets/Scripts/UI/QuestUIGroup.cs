using System;
using GT.Quests;
using TMPro;
using UnityEngine;

namespace UI
{
    public class QuestUIGroup : MonoBehaviour
    {
        //TODO: Get the quests the player has started
        
        private Quest _quest;
        [SerializeField] private TMP_Text questType;
        [SerializeField] private TMP_Text requirements;
        
        public void SetQuest(Quest quest)
        {
            // Set the quest to display
            _quest = quest;
            
            // Update the UI
            questType.text = _quest.GetQuestType() switch
            {
                EQuestType.Fetch => "<color=\"green\">Fetch</color>",
                EQuestType.Bully => "<color=\"red\">Bully</color>",
                _ => throw new ArgumentOutOfRangeException()
            };

            requirements.text = _quest.ToString();
        }

        public Quest GetQuest()
        {
            return _quest;
        }
    }
}
