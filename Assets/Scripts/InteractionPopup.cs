using UnityEngine;

public class InteractionPopup : MonoBehaviour
{
    private SpriteRenderer _spriteRenderer;

    public void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _spriteRenderer.enabled = false;
    }

    public void TrackObject(Transform objectTransform)
    {
        _spriteRenderer.enabled = true;
        transform.position = objectTransform.position + new Vector3(0, 3, 0);
    }

    public void StopTracking()
    {
        // Stop tracking
        _spriteRenderer.enabled = true;
    }

    public void Update()
    {
        // Animate somehow
    }
}