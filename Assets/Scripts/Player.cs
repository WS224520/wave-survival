﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public GameObject gameOverUI;
    public GameObject Rifle;
    public GameObject Pistol;

    public bool WeaponSwitch;

    //Movement
    public float speed;
    public float moveInput;
    private Rigidbody2D rb;

    //Health
    public Text healthDisplay;
    public int healthCounter = 3;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Rifle.SetActive(false);
        GetComponent <Rifle> ().enabled = false;
    }

    void FixedUpdate()
    {
        moveInput = Input.GetAxisRaw("Vertical");
        rb.velocity = new Vector2(moveInput * speed, rb.velocity.y);

        moveInput = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(moveInput * speed, rb.velocity.x);
    }

    void Update()
    {
        SwitchWeapon();
    }

     void OnTriggerEnter2D(Collider2D collision)
    {

        if(collision.CompareTag("Obstacle"))
        {
            healthDisplay.text = "Health: " + healthCounter.ToString(); //Convert health counter to string 
            healthCounter--;
        }

        if(collision.CompareTag("Health"))
        {
            healthDisplay.text = "Health: " + healthCounter.ToString(); //Convert health counter to string 
            healthCounter++;
        }

        if(collision.CompareTag("EnemyProjectile"))
        {
            healthDisplay.text = "Health: " + healthCounter.ToString(); //Convert health counter to string 
            healthCounter--;
        }
    }

    public void playerTakeDamage(int damage)
    {
        healthCounter -= damage;

        if(healthCounter <= 0)
        {
            KillPlayer();
        }
    }

    void KillPlayer()
    {
        if(healthCounter <= 0)
        {
            GameOver();
            Debug.Log("Player killed");

        }
    }

    public void GameOver()
    {
        Time.timeScale = 0;
        gameOverUI.SetActive(true);
    }

    public void Quit()
    {
        Debug.Log("Application quitting...");
        Application.Quit();
    }

    public void Retry()
    {
        SceneManager.LoadScene("GameScene");
        gameOverUI.SetActive(false);
        Time.timeScale = 1;
    }

    void SwitchWeapon()
    {
        if(Input.GetKeyDown(KeyCode.Q))
        {
            Rifle.SetActive(true);
            Pistol.SetActive(false);
            GetComponent<Rifle>().enabled = true;
            GetComponent<Weapon>().enabled = false;
        }

        else if(Input.GetKeyDown(KeyCode.E))
        {
            Rifle.SetActive(false);
            Pistol.SetActive(true);
            GetComponent<Rifle>().enabled = false;
            GetComponent<Weapon>().enabled = true;
        }

    }
}
