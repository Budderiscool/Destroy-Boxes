using DamageHandler;
using Unity.VisualScripting;
using UnityEngine;

public class BulletMove : MonoBehaviour
{
    private DamageHandler TakeDamage;
    private Shooting bulletPrefab;
    private EnemyHealth maxHealth;
    private FollowPlayer enemyBody;
    [SerializeField] private FollowPlayer targetBody;
    [SerializeField] private float bulletSpeed = 5;
    [SerializeField] private float bulletDamage = 5;
    [SerializeField] private float lifetime = 3;





    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.up * bulletSpeed * Time.deltaTime);
        if (lifetime > 0)
        {
            lifetime -= Time.deltaTime;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D enemyBody)
    {
        if(enemyBody.gameObject.CompareTag("Bullet"))
        {
           DamageHandler.TakeDamage(bulletDamage, targetBody);
        }
    }
}
