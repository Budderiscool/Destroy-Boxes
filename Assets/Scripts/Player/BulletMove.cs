using TakeDamage;
using Unity.VisualScripting;
using UnityEngine;

public class BulletMove : MonoBehaviour
{
    private Shooting bulletPrefab;
    private EnemyHealth maxHealth;
    private FollowPlayer enemyBody;
    private float bulletSpeed = 5;
    private float bulletDamage = 1;
    private float lifetime = 3;

    private bool isDestroyed = false;





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


    

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Enemy"))
        {
           DamageHandler.TakeDamageEnemy(bulletDamage, collision.gameObject);
        }
    }
}
