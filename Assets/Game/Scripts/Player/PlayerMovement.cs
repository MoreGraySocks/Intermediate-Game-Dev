using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody playerBody;
    private float moveInputHorizontal;
    private float moveInputVertical;
    public bool shiftHeld;

    public float speed;
    private float maxWalkSpeed = 1.6f; //taken from looking at max velocity when going a single direction
    private float maxRunSpeed = 2.5f;

    void Start()
    {
        transform.position = new Vector3(0, 0, 0); //change to spawnpoint later, currently centre
    }

    void Update()  //don't add physics
    {
        moveInputHorizontal = Input.GetAxis("Horizontal");
        moveInputVertical = Input.GetAxis("Vertical");

        if (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift))
        {
            shiftHeld = true;
        }
        else
        {
            shiftHeld = false;
        }

    }

    private void Awake()
    {
        playerBody = GetComponent<Rigidbody>();  //gets rigidbody at beginning
    }

    private void Move()
    {
        //shift to sprint
        if (shiftHeld == true)
        {
            speed = 4;
        }
        else
        {
            speed = 3;
        }

        Vector3 forwardMovement = transform.forward * moveInputVertical * speed * Time.deltaTime;
        //playerBody.AddForce(forwardMovement * 250);    //moves player forward and backward
        Vector3 sideMovement = transform.right * moveInputHorizontal * speed * Time.deltaTime;
        //playerBody.AddForce(sideMovement * 250);      //moves player left and right 

        Vector3 movement = forwardMovement + sideMovement;
        playerBody.AddForce(movement * 250);          //moves all directions   (tiny optimisation?)

        //diagonal speed limiter
        if (shiftHeld == false && playerBody.velocity.magnitude > maxWalkSpeed) 
        { 
            playerBody.velocity = playerBody.velocity.normalized * maxWalkSpeed; 
        } 
        else if (shiftHeld && playerBody.velocity.magnitude > maxRunSpeed)
        {
            playerBody.velocity = playerBody.velocity.normalized * maxRunSpeed;
        }


        //if (shiftHeld == false)
        //{
        //    switch (playerBody.velocity.x)
        //    {
        //        case > maxWalkSpeed:
        //            playerBody.velocity.x = maxWalkSpeed; break;
        //        case < -maxWalkSpeed:
        //            playerBody.velocity.x = -maxWalkSpeed; break;     //since left is -right I need to use a negative max speed as well
        //    }

        //    switch (playerBody.velocity.z) 
        //    {
        //        case > maxWalkSpeed:
        //            playerBody.velocity.z = maxWalkSpeed; break;
        //        case < -maxWalkSpeed:
        //            playerBody.velocity.z = -maxWalkSpeed; break;
        //    }
        //}
        //else
        //{
        //    switch (playerBody.velocity.x)
        //    {
        //        case > maxRunSpeed:
        //            playerBody.velocity.x = maxRunSpeed; break;
        //        case < -maxRunSpeed:
        //            playerBody.velocity.x = -maxRunSpeed; break;     
        //    }

        //    switch (playerBody.velocity.z)
        //    {
        //        case > maxRunSpeed:
        //            playerBody.velocity.z = maxRunSpeed; break;
        //        case < -maxRunSpeed:
        //            playerBody.velocity.z = -maxRunSpeed; break;
        //    }
        //}
    }

    private void FixedUpdate()  //for physics
    {
        Move();
    }


}
