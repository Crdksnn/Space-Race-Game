using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSpawner : MonoBehaviour
{

    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private float bulletSpawnTime;
    [SerializeField] private Vector3 direction;
    [SerializeField] private float bulletSpeed;

    private GameObject bullet;
    private float bulletSpawnWaitTime;
    void Start()
    {
        bulletSpawnWaitTime = 0;
    }

    
    void Update()
    {

        bulletSpawnWaitTime -= Time.deltaTime;
        
        if (bulletSpawnWaitTime <= 0)
        {
            
            bullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity);
            bullet.GetComponent<Bullet>().BulltetProperties(bulletSpeed, direction);
            bulletSpawnWaitTime = bulletSpawnTime;
        }
        
    }
    
    
}
