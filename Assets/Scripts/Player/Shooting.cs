using Mono.Cecil;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private GameObject Player;
    [SerializeField] private GameObject Enemy;
    [SerializeField] private float bulletSpeed = 10f;
    [SerializeField] private float maxNumOfBullets = 1f;
    [SerializeField] private float fireRate = 0.5f;
    private float cd = 0.5f;


    void Start()
    {
        if (bulletPrefab == null || Player == null || Enemy == null)
        {
            Debug.LogError("One or more required components are not assigned");
        }
    }

    private void Shoot()
    {
        for (int i = 0; i < maxNumOfBullets; i++)
        {
            GameObject prefabClone = Instantiate(bulletPrefab, Player.transform.position, Player.transform.rotation);
        }

        bulletPrefab.transform.position = Vector2.MoveTowards(bulletPrefab.transform.position, Enemy.transform.position, bulletSpeed * Time.deltaTime);

    }


    void Update()
    {
        if (cd > 0)
        {
            cd -= Time.deltaTime;

        }

        if ((Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Mouse0)) && cd <= 0)
        {
            Shoot();
            cd = fireRate;
        }
    }
}
