using System;
using System.Collections.Generic;
using System.Linq;
using GT;
using UnityEngine;

namespace UI
{
    public class QuestUIGroupManager : MonoBehaviour
    {
        [SerializeField] private GameObject questUIGroupTemplate;
        [SerializeField] private GameObject content;
        private List<QuestUIGroup> _groups = new List<QuestUIGroup>();
        private Game _game;

        public void Awake()
        {
            _game = Game.GetInstance();
        }

        public void FixedUpdate()
        {
            // Check to see if there are any quests that are not associated with any UI groups
            foreach (var quest in _game.GetPlayer().GetStartedQuests())
            {
                var exists = false;
                foreach (var group in _groups.Where(group => group.GetQuest().Equals(quest)))
                {
                    exists = true;

                    if (quest.Completed())
                    {
                        // Remove this 
                        _groups.Remove(group);
                        Destroy(group.gameObject);
                        return;
                    }
                }

                if (exists || quest.Completed()) continue;
                // Add a new UI group
                var newGroup = Instantiate(questUIGroupTemplate, content.transform);
                var uiGroup = newGroup.GetComponent<QuestUIGroup>();
                uiGroup.SetQuest(quest);
                _groups.Add(uiGroup);
            }
        }
    }
}