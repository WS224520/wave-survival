﻿using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    public Text scoreText;

    public GameObject blood;
    public AudioSource deathSound;

    //Enemy stats
    public int health = 50;

    //Enemy movement
    public float speed;
    public float stoppingDistance;
    public float retreatDistance;

    //Player
    public Transform player;

    //Shooting
    private float timeBtwShots;
    public float startTimeBtwShots;
    public GameObject projectile;

    //Health pickup
    public GameObject hpPickup;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;

        timeBtwShots = startTimeBtwShots;
    }

    void Update()
    {
        if(Vector2.Distance(transform.position, player.position) > stoppingDistance)
        {
            transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
        }

       else if(Vector2.Distance(transform.position, player.position) < stoppingDistance && Vector2.Distance(transform.position, player.position) > retreatDistance)
        {
            transform.position = this.transform.position;
        }

        else if(Vector2.Distance(transform.position, player.position) < retreatDistance)
        {
            transform.position = Vector2.MoveTowards(transform.position, player.position, -speed * Time.deltaTime);
        }

        if(timeBtwShots <= 0)
        {
            Instantiate(projectile, transform.position, Quaternion.identity);
            timeBtwShots = startTimeBtwShots;
        }

        else
        {
            timeBtwShots -= Time.deltaTime;
        }
    }

    public void TakeDamage(int damage)
    {
        health -= damage;

        if(health <= 0)
        {
            Die();
            Instantiate(blood, transform.position, Quaternion.identity);
            deathSound.Play();
        }
    }

    void Die()
    {
        Instantiate(hpPickup, transform.position, Quaternion.identity);
        Destroy(this.gameObject);
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            Destroy(this.gameObject);
        }

        if(collision.CompareTag("Bullet"))
        {
            scoreText.text = "Score: " + Score.scoreCounter.ToString();
            Score.scoreCounter++;
            Debug.Log(Score.scoreCounter);
        }
    }  
}
