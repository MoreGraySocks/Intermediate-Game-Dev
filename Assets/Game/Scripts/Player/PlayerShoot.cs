using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{

    public GameObject arrow;        //the arrow that will be instantiated
    public Transform fireTransform; //the position the arrow spawns
    public float force;             //the force applied to the arrow
    public float drawMax;           //the maximum force that can be added from "drawing"

    public float drawTime;         //how long the bow is "drawn" for. adds extra force to the shot
    private bool isDrawing = false;

    [SerializeField] DrawBar drawbar;

    public GameObject drawBarObject;

    void Start()
    {
        drawBarObject.SetActive(false);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            isDrawing = true;
        }

        if (isDrawing)
        {
            drawBarObject.SetActive(true);
            drawTime += Time.deltaTime;
            drawbar.UpdateDrawBar(drawTime);
        }

        if (Input.GetKeyUp(KeyCode.Mouse0))
        {
            Fire();
            drawBarObject.SetActive(false);
        }
    }

    void Fire()
    {
        isDrawing = false;

        if (drawTime > drawMax)
        {
            drawTime = drawMax;
        }

        GameObject tempArrow = Instantiate(arrow, fireTransform.position, fireTransform.rotation);
        tempArrow.GetComponent<Rigidbody>().AddForce(tempArrow.transform.forward * force * drawTime);

        drawTime = 0;
    }

}
