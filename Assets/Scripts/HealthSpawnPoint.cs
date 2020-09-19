using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthSpawnPoint : MonoBehaviour
{
    public GameObject healthPickup;
    void Update()
    {
        Instantiate(healthPickup, transform.position, Quaternion.identity);
    }
}
