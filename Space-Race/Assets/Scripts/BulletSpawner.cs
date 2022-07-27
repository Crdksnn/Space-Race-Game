using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSpawner : MonoBehaviour
{

    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private float bulletSpawnTime;
    [SerializeField] private Vector2 direction;

    private GameObject bullet;
    private float bulletSpawnWaitTime;
    void Start()
    {
        bulletSpawnWaitTime = Random.Range(0,bulletSpawnTime);
    }

    
    void Update()
    {

        bulletSpawnWaitTime -= Time.deltaTime;
        
        if (bulletSpawnWaitTime <= 0)
        {
            
            bullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity);
            bullet.GetComponent<Bullet>().BulletDirection(direction);
            bulletSpawnWaitTime = Random.Range(0,bulletSpawnTime);
        }
        
    }
    
    
}
