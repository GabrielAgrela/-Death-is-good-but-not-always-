using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSnake : MonoBehaviour
{

    [SerializeField]
    private float bulletSpeed = 1f;
    // Start is called before the first frame update
    void Start()
    {
        this.GetComponent<Rigidbody2D>().velocity = transform.right * bulletSpeed;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        
        if (collision.gameObject.tag == "Enemy")
        {
            // damage
            Enemy enemy = collision.gameObject.GetComponent<Enemy>();
            enemy.Damage(50);

            Destroy(gameObject);
        }
		else if (collision.gameObject.tag != "Player")
		{
			Destroy(gameObject);
		}
    }

}
