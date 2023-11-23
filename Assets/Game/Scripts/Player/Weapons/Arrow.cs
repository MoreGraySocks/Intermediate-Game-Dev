using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    static public float damage = 1f;

    void Start()
    {
        Destroy(gameObject, 3);
    }

    private void OnCollisionEnter(Collision other)
    {
        ObjectHealth object1 = other.gameObject.GetComponentInParent<ObjectHealth>();
        if (object1)
        {
            object1.TakeDamage(damage);
            Destroy(gameObject);
        }
    }
}
