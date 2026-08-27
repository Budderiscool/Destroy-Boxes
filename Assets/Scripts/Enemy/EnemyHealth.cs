using TakeDamage;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] private EnemyBoxSpawn enemyPrefab;
    public float health;

    void SpawnOnDeath(EnemyBoxSpawn enemyPrefab, float ammount)
    {
        for (int i = 0; i < ammount; i++)
        {
            Instantiate(enemyPrefab, transform.position, Quaternion.identity);
            enemyPrefab.transform.localScale = new Vector3(0.5f, 0.5f, 1);
            health = 5;
        }
        
        
    }

    void Update()
    {
        if (health > 0)
        {

        }
        else
        {
            SpawnOnDeath(enemyPrefab, 4);
            Destroy(gameObject);
        }
    }
}
