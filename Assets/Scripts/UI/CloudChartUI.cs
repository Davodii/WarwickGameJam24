using System;
using GT;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class CloudChartUI : MonoBehaviour
    {
        // Get the current cloud chart status
        [SerializeField] private RectTransform needleTransform;
        [SerializeField] private Slider slider;

        public void FixedUpdate()
        {
            // Get the value
            //TODO: Substitute this with player cloud chart
            float value =  slider.value / 100f;
            //TODO: idk
            float degree = GetDegree(1 - value);
            
            // Adjust needle
            var eulerAngles = needleTransform.eulerAngles;
            eulerAngles =
                new Vector3(eulerAngles.x, eulerAngles.y, degree);
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
