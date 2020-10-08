using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject EnemyObject;
    public GameObject DestructEnemyObject;
    

    public Transform EnemySpawner;
    public Transform DestructEnemySpawner;

    
    public GameObject[] obstaclePatterns;

    private float timeBtwSpawn;
    public float startTimeBtwSpawn;
    public float decreaseTime;
    public float minTime = 0.65f;
    
 

    void Start()
    {
        /*
        InvokeRepeating("SpawnEnemy", 5, 5);
        InvokeRepeating("SpawnDestructEnemy", 10, 10);
        */
    }

    //Spawner that picks out a random value in the array
    private void Update()
    {

        if(timeBtwSpawn <= 0)
        {
            int rand = Random.Range(0, obstaclePatterns.Length);
            Instantiate(obstaclePatterns[rand], transform.position, Quaternion.identity);
            timeBtwSpawn = startTimeBtwSpawn;

            startTimeBtwSpawn -= decreaseTime;
            if (startTimeBtwSpawn > minTime)
            {
                startTimeBtwSpawn -= decreaseTime;
            }
        }

        else
        {
            timeBtwSpawn -= Time.deltaTime;
        }
        
        /*
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
        */
        
    }

}
