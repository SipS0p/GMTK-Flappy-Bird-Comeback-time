using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class CLoudMovement : MonoBehaviour
{
   
    public Rigidbody2D myRigidbody;

   
    // Update is called once per frame
    void FixedUpdate()
    {
            myRigidbody.velocity = Vector2.left * SpeedUpClouds.Speed;              
    }
    void OnPlayerDeath ()
    {
        myRigidbody.velocity = Vector2.zero; // Stop the pipe movement
    }
}
