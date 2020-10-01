using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class Weapon : MonoBehaviour
{
    public AudioSource PistolSound;
    public Transform firePoint;
    public GameObject bulletPrefab;
    public float bulletTime;
    public float offset;

    private float timeBtwShots;
    public float startTimeBtwShots;

    public Player player;

    void Start()
    {
        player = GetComponent<Player>();
    }

    // Update is called once per frame
    private void Update()
    {
        Vector3 difference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position; //Follow mouse positon
        float rotZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg; //Calculates mouse position
        transform.rotation = Quaternion.Euler(0f, 0f, rotZ + offset);


        if(timeBtwShots <= 0)
        {
            if (Input.GetMouseButton(0))
            {
                Instantiate(bulletPrefab, firePoint.position, transform.rotation);
                timeBtwShots = startTimeBtwShots;
                PistolSound.Play();
            }
        }
        else
        {
            timeBtwShots -= Time.deltaTime;
        }
    }
}
