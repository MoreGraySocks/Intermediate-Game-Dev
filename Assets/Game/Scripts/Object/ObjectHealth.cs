using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectHealth : MonoBehaviour
{
    public int maxHealth;
    private int currentHealth;


    void Start()
    {
        currentHealth = maxHealth;
    }

    void Update()
    {
        
    }

    //public void PlayerWeaponDamage(Collision collision)
    //{
    //    if (collision.gameObject.CompareTag("PlayerWeapon"))
    //    {
    //        currentHealth -= collision.gameObject.GetComponent<HandlePlayerWeapon>().damage;
    //        if (currentHealth <= 0)
    //        {
    //            Deactivate();
    //        }
    //    }
    //}

    //public void ProjectileDamage(Collision collision)
    //{
    //    if (collision.gameObject.CompareTag("Projectile"))
    //    {
    //        currentHealth -= collision.gameObject.GetComponent<HandleRanged>().damage;
    //        if (currentHealth <= 0)
    //        {
    //            Deactivate();
    //        }
    //    }
    //}

    //public void EnemyWeaponDamage(Collision collision)
    //{
    //    if (collision.gameObject.CompareTag("EnemyWeapon"))
    //    {
    //        currentHealth -= collision.gameObject.GetComponent<HandleEnemyWeapon>().damage;
    //        if (currentHealth <= 0)
    //        {
    //            Deactivate();
    //        }
    //    }
    //}

    public void Deactivate()
    {
        gameObject.SetActive(false);
    }

    public void Death()
    {
        Destroy(gameObject);
    }
}
