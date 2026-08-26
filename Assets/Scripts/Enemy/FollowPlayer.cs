using UnityEngine;
using UnityEngine.EventSystems;

public class FollowPlayer : MonoBehaviour
{
    [SerializeField] private PlayerMovement speed;
    [SerializeField] private float monsterSpeed;
    [SerializeField] private Rigidbody2D playerbody;
    [SerializeField] private Rigidbody2D enemybody;
    [SerializeField] private GameObject target;
    
    void FixedUpdate()
    {
        if (target != null)
        {
            monsterSpeed = speed.speed / 4;
            Vector2 direction = (Vector2)target.transform.position - enemybody.position;
            enemybody.linearVelocity = direction.normalized * monsterSpeed;
            enemybody.rotation = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 90f;
            Vector2.MoveTowards(playerbody.position, target.transform.position, monsterSpeed * Time.fixedDeltaTime);
        }
    }
}
