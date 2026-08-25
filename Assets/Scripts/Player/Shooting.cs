using UnityEngine;

public class Shooting : MonoBehaviour
{
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private GameObject Player;
    [SerializeField] private GameObject Enemy;
    [SerializeField] private float bulletSpeed = 10f;
    [SerializeField] private float numofBullets = 1f;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (bulletPrefab == null || Player == null || Enemy == null) {
            Debug.LogError("One or more required components are not assigned!");
        }
    }

    private void Shoot()
    {
        GameObject bullet = bulletPrefab;

        if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Mouse0))
        {
            Instantiate(bullet, Player.transform.position, Player.transform.rotation);
        }
        
        bullet.transform.position = Vector2.MoveTowards(bullet.transform.position, Enemy.transform.position, bulletSpeed * Time.deltaTime);


    }



    // Update is called once per frame
    void Update()
    {
        Shoot();
        
    }
}
