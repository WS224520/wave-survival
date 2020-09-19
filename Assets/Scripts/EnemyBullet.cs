using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    private Transform player;
    private Vector2 target;
    public int bulletDamage = 5;
    public float speed;


    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform; //Set the player position
        target = new Vector2(player.position.x, player.position.y); //The bullets target is the players position
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, target, speed * Time.deltaTime); //Move bullet to the target

        if(transform.position.x == target.x && transform.position.y == target.y) //If the bullet reaches the target
        {
            DestroyProjectile(); //DestroyProjectile function is called
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            DestroyProjectile(); //DestroyProjectile function is called
        }

        if(collision.CompareTag("Player"))
        {
            Player player = collision.GetComponent<Player>();

            if (player != null)
            {
                player.playerTakeDamage(bulletDamage);
            }
        }
    }

    void DestroyProjectile()
    {
        Destroy(gameObject); //Destroy the projectile on collision

    }
}
