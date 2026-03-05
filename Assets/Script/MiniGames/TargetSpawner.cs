using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetSpawner : MonoBehaviour
{
    public GameObject targetPrefab; 
    public Vector2 spawnAreaMin , spawnAreaMax;
    private GameObject currentTarget;

    void Update()
    {
        // Continuously check if there is no active target and spawn a new one
        if (currentTarget == null)
        {
            SpawnTarget();
        }
    }

    public void SpawnTarget()
    {
        if (currentTarget == null)
        {
            // Generate a random position within the spawn area
            Vector2 randomPosition = new Vector2(
                Random.Range(spawnAreaMin.x, spawnAreaMax.x),
                Random.Range(spawnAreaMin.y, spawnAreaMax.y)
            );

            // Instantiate the target prefab at the random position
            currentTarget = Instantiate(targetPrefab, randomPosition, Quaternion.identity);
        }
    }
}
