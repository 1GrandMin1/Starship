using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerAsteroid : MonoBehaviour
{
    public GameObject [] asteroidVariant;

    private float timeSpawn;
    public float startTimeSpawn;
    public float decreaseTime;
    public float minTime = 0.65f;
    private void Update()
    {
        if (startTimeSpawn > minTime) {
            if (timeSpawn <= 0)
            {               
                int rand = Random.Range(0, asteroidVariant.Length);
                Instantiate(asteroidVariant[rand], transform.position, Quaternion.identity);
                timeSpawn = startTimeSpawn - decreaseTime;
                int previous = rand;
            }
            timeSpawn -= Time.deltaTime;
        }
    }
}
