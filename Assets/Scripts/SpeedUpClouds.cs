using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedUpClouds : MonoBehaviour
{
    public float Timer = 5f;
    static public float Speed = 2f;
    public float MaxSpeed = 6f;
    // Start is called before the first frame update
    void Start()
    {
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
