using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    public int points = 10; 
    private TargetSpawner targetSpawner;

    private void Start()
    {
   
        targetSpawner = FindObjectOfType<TargetSpawner>();
    }

    public void OnHit()
    {
        Destroy(gameObject);
        targetSpawner.SpawnTarget();
        ScoreManager.instance.AddScore(points);
    }
}
