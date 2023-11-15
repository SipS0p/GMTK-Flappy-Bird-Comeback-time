using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class CloudSpawner : MonoBehaviour
{
    [SerializeField ] private GameObject Cloud;
    private float TimeBetweenSpawn = 3f;
    private float MinSpawnHeight = 10f;
    private float MaxSpawnHeight = 18.9f;
    private float MinSpawnWidth = 20f;
    private float MaxSpawnWidth = 50f;

    // Update is called once per frame
    void Update()
    {
        if (TimeBetweenSpawn <= 0)
        {
            float randomY = Random.Range(MinSpawnHeight, MaxSpawnHeight);
            float randomX = Random.Range(MinSpawnWidth, MaxSpawnWidth);
            Vector3 spawnPosition = transform.position + new Vector3(randomX, randomY);
            Instantiate(Cloud, spawnPosition, Quaternion.identity);
            TimeBetweenSpawn = 3;
        }
        else
        {
            TimeBetweenSpawn -= Time.deltaTime;

        }

    }
}
