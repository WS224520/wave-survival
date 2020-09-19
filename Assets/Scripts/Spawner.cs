using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject[] obstaclePatterns;

    private float timeBtwSpawn;
    public float startTimeBtwSpawn;
    public float decreaseTime;
    public float minTime = 0.65f;

 

    //Spawner that picks out a random value in the array
    void Update()
    {
        int rand = Random.Range(0, obstaclePatterns.Length);
        Instantiate(obstaclePatterns[rand], transform.position, Quaternion.identity);
        timeBtwSpawn = startTimeBtwSpawn;

        if(startTimeBtwSpawn > minTime)
        {
            startTimeBtwSpawn -= decreaseTime;
        }

        else
        {
            timeBtwSpawn -= Time.deltaTime;
        }
    }
}
