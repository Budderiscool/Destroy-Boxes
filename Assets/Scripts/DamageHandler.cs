using UnityEngine;

namespace TakeDamage
{


    public class DamageHandler : MonoBehaviour
    {
        public static void TakeDamageEnemy(float damage, GameObject targetBody)
        {
            targetBody.GetComponent<EnemyHealth>().health -= damage;
        }
        public static void TakeDamagePlayer(float damage, GameObject targetBody)
        {
            targetBody.GetComponent<PlayerHealth>().health -= damage;
        }
    }
}