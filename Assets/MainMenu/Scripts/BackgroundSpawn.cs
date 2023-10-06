using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BackgroundSpawn : MonoBehaviour
{
    public Transform transform;
    public Image background;
    public Transform spawn;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (transform.position.x <= -3500)
        {
            Debug.Log("Transform Destroyed");
            Destroy(transform);
            Image temp = Instantiate(background, spawn.position, spawn.rotation);
        }

    }
}
