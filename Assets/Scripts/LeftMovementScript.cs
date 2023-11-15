using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class LeftMovementScript : MonoBehaviour
{
    public Rigidbody2D myRigidbody;

    // Update is called once per frame
    void FixedUpdate()
    {
        myRigidbody.velocity = Vector2.left * SpeedUp.Speed;
    }

    //old idea down there

    /* public void OnPlayerDeath()
     {
         Debug.Log("Pipe Should stop now");
         myRigidbody.velocity = Vector2.zero; // Stop the pipe movement
         enabled = false;    
     }
     public void OnSpeedChange () 
     { 
         //I want to make the Speed to become the same as the Speed in the SpeedUp Script 
     } */
}
