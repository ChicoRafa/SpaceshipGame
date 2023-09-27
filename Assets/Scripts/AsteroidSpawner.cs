using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidSpawner : MonoBehaviour
{
    public GameObject[] spawnPoints;
    public GameObject asteroidPrefab;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnAsteroid", 1f, 1f);
    }

    private void SpawnAsteroid()
    {
        Instantiate(asteroidPrefab, spawnPoints[Random.Range(0, spawnPoints.Length)].transform.position, Quaternion.identity);
    }
}
