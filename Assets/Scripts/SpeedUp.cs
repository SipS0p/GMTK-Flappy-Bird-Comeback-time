using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedUp : MonoBehaviour
{
    float Timer = 5f; 
    public static float Speed = 8f; 
    float MaxSpeed = 24f;

    private void Start()
    {
        Speed = 8f;
    }
    // Update is called once per frame
    void Update()
    {
        Timer -= Time.deltaTime;
        if (Timer <= 0 && (Speed < MaxSpeed))
        {
            Speed *= 1.1f;
            Timer = 5f;
        }
    }
}
