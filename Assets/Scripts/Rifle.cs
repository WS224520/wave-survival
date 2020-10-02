using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rifle : MonoBehaviour
{
    public AudioSource RifleSound;
    public Transform RifleFirePoint;

    public GameObject bulletPrefab;
    public float bulletTime;
    public float offset;

    private float timeBtwShots;
    public float startTimeBtwShots;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    public void Update()
    {
        Vector3 difference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position; //Follow mouse positon
        float rotZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg; //Calculates mouse position
        transform.rotation = Quaternion.Euler(0f, 0f, rotZ + offset);


        if(timeBtwShots <= 0)
        {
            if(Input.GetMouseButtonDown(0))
            {
                Instantiate(bulletPrefab, RifleFirePoint.position, transform.rotation);
                timeBtwShots = startTimeBtwShots;
                RifleSound.Play();
                Debug.Log("Rifle fire");
            }
        }

        else
        {
            timeBtwShots -= Time.deltaTime;
        }
    }
}
