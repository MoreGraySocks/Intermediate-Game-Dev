using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStopSpin : MonoBehaviour
{
    public Transform head;
    public Transform body;

    void Update()
    {
        transform.rotation = Quaternion.Euler(0, 0, 0);
        head.rotation = Quaternion.Euler(head.rotation.x, body.rotation.y, head.rotation.z);
    }
}
