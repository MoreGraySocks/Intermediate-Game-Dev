using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLook : MonoBehaviour
{
    LayerMask layerMask;

    // Start is called before the first frame update
    void Start()
    {
        layerMask = LayerMask.GetMask("Ground");
    }

    // Update is called once per frame
    void Update()
    {
        Ray rayCast = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(rayCast, out hit, Mathf.Infinity, layerMask))
        {
            //Vector3 ignoreY = new Vector3 (hit.point.x, 0, hit.point.z);
            transform.LookAt(hit.point);
        }
    }
}
