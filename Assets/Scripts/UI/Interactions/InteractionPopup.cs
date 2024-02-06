using UnityEngine;

namespace UI.Interactions
{
    public class InteractionPopup : MonoBehaviour
    {
        private SpriteRenderer _spriteRenderer;
        private bool _tracking;

        public void Awake()
        {
            _spriteRenderer = GetComponent<SpriteRenderer>();
            _tracking = false;
        }

        public void TrackObject(Transform objectTransform)
        {
            _tracking = true;
            transform.position = objectTransform.position + new Vector3(0, 3, 0);
        }

        public void StopTracking()
        {
            // Stop tracking
            _tracking = false;
        }

        public void Update()
        {
            // Animate somehow
            if (_spriteRenderer.enabled != _tracking)
            {
                _spriteRenderer.enabled = _tracking;
            }
        }
    }
}