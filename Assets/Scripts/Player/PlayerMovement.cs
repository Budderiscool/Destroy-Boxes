using UnityEngine;
using UnityEngine.InputSystem;

    public class PlayerMovement : MonoBehaviour
    {
        public float speed = 8f;
        [SerializeField] private Rigidbody2D body;
        
        [SerializeField] private float acceleration = 20f;
        [SerializeField] private float deceleration = 25f;

        private void FixedUpdate()
        {
            float xInput = Input.GetAxisRaw("Horizontal");
            float yInput = Input.GetAxisRaw("Vertical");

            Vector2 inputDirection = new Vector2(xInput, yInput).normalized;
            Vector2 targetVelocity = inputDirection * speed;

            float rate = inputDirection.sqrMagnitude > 0f ? acceleration : deceleration;
            body.linearVelocity = Vector2.MoveTowards(body.linearVelocity, targetVelocity, rate * Time.fixedDeltaTime);

            body.rotation = MousePositionToAngle();
        }

        private float MousePositionToAngle()
        {
            Vector2 mouseScreenPos = Mouse.current.position.ReadValue();
            Vector3 mouseWorldPos = Camera.main.ScreenToWorldPoint(
                new Vector3(mouseScreenPos.x, mouseScreenPos.y, -Camera.main.transform.position.z));

            Vector2 direction = (Vector2)mouseWorldPos - body.position;
            return Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 90f;
        }
    }