using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Bullet : MonoBehaviour
{

    //Bullet
    public int damage = 50;
    public float speed;
    public float lifeTime;
    public float distance;
    public LayerMask whatIsSolid;

    // Start is called before the first frame update
    void Start()
    {
        Invoke("DestroyProjectile", lifeTime);
    }

    
    //Bullet damage
    void OnTriggerEnter2D(Collider2D hitInfo)
    {
        Enemy enemy = hitInfo.GetComponent<Enemy>();

        if(enemy != null)
        {
            enemy.TakeDamage(damage);
            Destroy(this.gameObject);
        }

        SelfDestructEnemy selfDestructEnemy = hitInfo.GetComponent<SelfDestructEnemy>();

        if(selfDestructEnemy != null)
        {
            selfDestructEnemy.TakeDamage(damage);
            Destroy(this.gameObject);
        }
    }
    
    private void Update()
    {
        RaycastHit2D hitInfo = Physics2D.Raycast(transform.position, Vector2.right, distance, whatIsSolid);
        transform.Translate(Vector2.right * speed * Time.deltaTime);
    }
 
    void DestroyProjectile()
    {
        Destroy(gameObject);
    }
}
