using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BackgroundScroll : MonoBehaviour
{
    public Transform uiTransform;
    public int speed = 20;
    public Transform spawn;
    public Image background;
    public Transform canvas;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        uiTransform.Translate(-Vector3.right * Time.deltaTime * speed);

        if (transform.position.x <= -3500)
        {
            SpawnBackground();
            Destroy(gameObject);
            Debug.Log("Transform Destroyed");
        }
    }

    void SpawnBackground()
    {
        Image temp = Instantiate(background, spawn.position, spawn.rotation);
        temp.transform.SetParent(canvas);
        temp.transform.SetSiblingIndex(1);
        Debug.Log("New Background Spawned");
    }
}
