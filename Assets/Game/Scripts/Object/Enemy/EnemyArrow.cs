using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyArrow : MonoBehaviour
{
    public float damage = 1;

    void Start()
    {
        Destroy(gameObject, 3);
    }

    private void OnCollisionEnter(Collision other)
    {
        PlayerHealth player = other.gameObject.GetComponentInParent<PlayerHealth>();
        if (player)
        {
            player.TakeDamage(damage);
            Destroy(gameObject);
        }
    }
}
