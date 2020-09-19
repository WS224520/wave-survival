using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthSpawner : MonoBehaviour
{
    public GameObject[] healthSpawn;

    private float timeBtwSpawn;
    public float startTimeBtwSpawn;
    public float decreaseTime;
    public float minTime = 0.65f;

    // Update is called once per frame
    void Update()
    {
        int rand = Random.Range(0, healthSpawn.Length);
        Instantiate(healthSpawn[rand], transform.position, Quaternion.identity);

        timeBtwSpawn = startTimeBtwSpawn;
        if(startTimeBtwSpawn > minTime)
        {
            startTimeBtwSpawn -= decreaseTime;
        }

        else
        {
            startTimeBtwSpawn -= Time.deltaTime;
        }

}
}
