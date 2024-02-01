using GT.Items;
using UnityEngine;

namespace UI
{
    public class TradeSectionContextMenu : MonoBehaviour
    {
        [SerializeField] private GameObject tradeGroup;
        [SerializeField] private GameObject leftPanel;
        [SerializeField] private GameObject middlePanel;
        [SerializeField] private GameObject rightPanel;

        public void AddRequest(IItem item, int count)
        {
            // Create new trade group
            // Set item to trade group
            GameObject newGroup = Instantiate(tradeGroup, leftPanel.transform, false);
            newGroup.GetComponent<TradeGroup>().SetItem(item, count);
        }

        public void AddReward(IItem item, int count)
        {
            // Add icon for reward
            GameObject newGroup = Instantiate(tradeGroup, rightPanel.transform, false);
            newGroup.GetComponent<TradeGroup>().SetItem(item, count);
        }
    }
}
