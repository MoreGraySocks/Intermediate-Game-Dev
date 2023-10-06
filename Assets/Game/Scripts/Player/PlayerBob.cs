using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBob : MonoBehaviour
{
    private bool goUp = true;
    private float bobTime;
    public PlayerMovement shiftHeld;
    public Transform bobRig;

    //public Transform target

    void Start()
    {
        bobTime = 0f;

        //startTime = Time.time;
        //journeyLength = Vector3.Distance(transform.position, target.position)
    }



    private void FixedUpdate()
    {
        //bob "animation"(try using Time.deltaTime?)
        //thought I was being smart with this but it literally didn't do anything

        while (goUp == true)
        {
            if (shiftHeld == false)
            {
                bobTime += Time.deltaTime;
            }
            else
            {
                bobTime += Time.deltaTime * 1.25f;
            }

            while (bobTime > 1)
            {
                transform.position += Vector3.up * bobTime;
            }
            bobTime = 0;
            goUp = false;
        }

        while (goUp == false)
        {
            if (shiftHeld == false)
            {
                bobTime += Time.deltaTime;
            }
            else
            {
                bobTime += Time.deltaTime * 1.25f;
            }

            while (bobTime > 1)
            {
                transform.position -= Vector3.up * bobTime;
            }
            bobTime = 0;
            goUp = true;
        }




    }
}
