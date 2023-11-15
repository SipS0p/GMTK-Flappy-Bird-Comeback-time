using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundSpawner : MonoBehaviour
{
    public GameObject Ground;
    public Transform parentGrassbiome; // Reference to the parent GameObject*/

    // Update is called once per frame
    void Update()
    {
        // Check if there are no other "Ground" GameObjects in the scene
        if (GameObject.FindGameObjectsWithTag("Ground").Length == 1)
        {
            SpawnGround();
        }
    }

    void SpawnGround()
    {
        //Global Position: 60.07002 -24
        //Child Position: -74.72998 -3
        Debug.Log("SpawnGround activated");
        // Set the position where you want the "Ground" GameObject to spawn
        Vector2 spawnPosition = new Vector2(60, -24);
        Debug.Log(spawnPosition);

        // Spawn the "Ground" GameObject
        GameObject newGround = Instantiate(Ground, spawnPosition, Quaternion.identity);
        //Make the ground GameObject a child of the parent
        newGround.transform.SetParent(parentGrassbiome);

    }
}
