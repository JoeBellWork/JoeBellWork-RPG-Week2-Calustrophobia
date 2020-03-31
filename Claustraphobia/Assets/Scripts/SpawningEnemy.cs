using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawningEnemy : MonoBehaviour
{
    public Transform[] spawnPoints;
    public GameObject enemy;
    int randomSpawnPoint;
    public static bool spawnAllowed;

    private void Start()
    {
        spawnAllowed = true;
        InvokeRepeating("spawnEnemies", 0f, 3f);
    }

    void spawnEnemies()
    {
        if(spawnAllowed)
        {
            randomSpawnPoint = Random.Range(0, spawnPoints.Length);
            Instantiate(enemy, spawnPoints[randomSpawnPoint].position, Quaternion.identity);
        }
    }
}
