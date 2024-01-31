using UnityEngine;

namespace Behaviours
{
    public class PlayerController : MonoBehaviour
    {
        // Control player movement
        [Header("Movement Variables")] 
        [SerializeField] private float movementSpeed;
    
        // Privates
        private Rigidbody2D _rb2d;
        
        public void Awake()
        {
            _rb2d = this.GetComponent<Rigidbody2D>();
        }

        public void Initialize()
        {
            // Initialize variables
            // called externally by other scripts ?
        }

        private Vector2 GetInput()
        {
            Vector2 input = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));

            return input.normalized;
        }        

        public void FixedUpdate()
        {
            // Get the input
            Vector2 input = GetInput();
            
            // Get the next position
            Vector2 newPosition = (Vector2)transform.position + (input * (movementSpeed * Time.fixedDeltaTime));
            
            // Move the player
            _rb2d.MovePosition(newPosition);
        }
    }
}
