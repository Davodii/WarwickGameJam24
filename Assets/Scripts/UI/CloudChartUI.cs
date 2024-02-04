using GT;
using UnityEngine;

namespace UI
{
    public class CloudChartUI : MonoBehaviour
    {
        // Get the current cloud chart status
        [SerializeField] private RectTransform needleTransform;
        private int _previousValue;

        private Game _game;

        public void Awake()
        {
            _game = Game.GetInstance();
        }

        public void FixedUpdate()
        {
            var currentValue = _game.GetPlayer().GetCloudChartValue();
            if (_previousValue == currentValue) return;
            
            // Get the cloud chart value
            _previousValue = currentValue;
            var value = currentValue / 100f;
            var degree = GetDegree(1 - value);
            
            // Adjust needle
            var eulerAngles = needleTransform.eulerAngles;
            eulerAngles = new Vector3(
                eulerAngles.x,
                eulerAngles.y,
                degree);
            
            needleTransform.eulerAngles = eulerAngles;
        }

        private float GetDegree(float value)
        {
            // Convert value in range 0 - 1 into degree
            // Assumes north is 0 degrees

            float degree = value * 360;
            degree -= 90;
            
            // Wrap around
            if (degree < 0)
            {
                degree += 360;
            }

            return degree;
        }
    }
}
