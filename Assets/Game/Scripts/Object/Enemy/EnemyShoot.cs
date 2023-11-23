using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShoot : MonoBehaviour
{
    public Rigidbody enemyArrow;
    public Transform fireTransform;

    public float force;
    public float shootDelay = 1;

    private bool canShoot;
    private float shootTimer;

    void Start()
    {
        canShoot = false;
        shootTimer = 0;
    }

    void Update()
    {
        if (canShoot)
        {
            shootTimer -= Time.deltaTime;
            if (shootTimer <= 0)
            {
                shootTimer = shootDelay;
                Fire();
            }
        }
    }

    void Fire()
    {
        Rigidbody enemyArrowInstance = Instantiate(enemyArrow, fireTransform.position, fireTransform.rotation) as Rigidbody;
        enemyArrowInstance.velocity = force * fireTransform.forward;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            canShoot = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            canShoot = false;
        }
    }
}
