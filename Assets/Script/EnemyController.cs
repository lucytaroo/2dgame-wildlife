using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform firePoint;
    public float bulletSpeed = 5f;
    public float detectionRange = 10f;
    public float fireRate = 1f;
    public float nextFireTime = 0f;
    private Transform player;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update()
    {
        DetectAndShootPlayer();
    }

    void DetectAndShootPlayer()
    {
       
        if (Mathf.Abs(transform.position.y - player.position.y) < 0.1f && Mathf.Abs(transform.position.x - player.position.x) <= detectionRange)
        {
            if(Time.time >= nextFireTime) 
            {
                Shoot();
                nextFireTime = Time.time + fireRate;
            }
            
        }
    }

    void Shoot()
    {
        
        if (bulletPrefab != null && firePoint != null)
        {
            GameObject bullet = Instantiate(bulletPrefab, firePoint.position, Quaternion.identity);
            Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
            if (rb != null)
            {
                float direction = player.position.x > transform.position.x ? 1f : -1f;
                rb.velocity = new Vector2(direction * bulletSpeed, 0);
            }
        }
    }
}

