using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeadSpin : MonoBehaviour
{
    public Transform helpmerig;

    void Start()
    {
        
    }

    void Update()
    {
        transform.rotation = Quaternion.Euler(0, helpmerig.eulerAngles.y, 0);
    }
}
