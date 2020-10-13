using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelfDestructEnemy : MonoBehaviour
{

    public Text scoreText;
    public GameObject blood;

    //Enemy health
    public int health = 50;

    //Player targeting
    private Transform player;
    private Vector2 target;
    public float speed;
    public int damagePlayer = 5;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform; //Find player
        target = new Vector2(player.position.x, player.position.y); //On start follow player
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime); //Follow player

        if(transform.position.x ==  target.x && transform.position.y == target.y)
        {
            DestroyEnemy();
        }
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            DestroyEnemy();
        }

        if (collision.CompareTag("Bullet"))
        {
            scoreText.text = "Score: " + Score.scoreCounter.ToString();
            Score.scoreCounter++;
            Debug.Log(Score.scoreCounter);
        }
    }

    void DestroyEnemy()
    {
        Destroy(this.gameObject);
    }

    public void TakeDamage(int damage)
    {
        health -= damage;

        if (health <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Destroy(this.gameObject);
        Instantiate(blood, transform.position, Quaternion.identity);
        Invoke("BloodRemove", 1.0f);
    }

    void BloodRemove()
    {
        Destroy(blood.gameObject);
    }
}
