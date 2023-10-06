using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundScroll : MonoBehaviour
{
    public Transform uiTransform;
    public int speed = 20;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        uiTransform.Translate(-Vector3.right * Time.deltaTime * speed);
    }

    private void FixedUpdate()
    {
        
    }
}
