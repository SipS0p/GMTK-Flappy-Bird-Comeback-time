using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private GameObject PipeToSpawn;
    private float TimeUntilSpawn = 3.5f;
    private float TimeBetweenSpawns = -13.62f;
    private float MinSpawnHeight = -13.62f;
    private float MaxSpawnHeight = 6f;

    private void Start()
    {
        TimeBetweenSpawns = TimeUntilSpawn;
    }

    void Update()
    {
        // Check if it's time to spawn a new pipe
        if (TimeUntilSpawn <= 0)
        {
            // Generate a random Y position within the specified range
            float randomY = Random.Range(MinSpawnHeight, MaxSpawnHeight);

            // Create a spawn position based on the spawner's x position and the random Y
            Vector2 spawnPosition = new Vector2(transform.position.x, randomY);

            // Instantiate a new PipeToSpawn GameObject at the calculated spawn position
            Instantiate(PipeToSpawn, spawnPosition, Quaternion.identity);

            // Reset the TimeUntilSpawn to its initial value
            TimeUntilSpawn =TimeBetweenSpawns;

            // Decrease the TimeBetweenSpawn, gradually making spawning faster
            if (TimeBetweenSpawns > 2.3f)
            {
                TimeBetweenSpawns -= 0.075f;
            }
        }
        else
        {
            // Decrease the TimeUntilSpawn while it's above zero
            TimeUntilSpawn -= Time.deltaTime;
        }
    }
}
