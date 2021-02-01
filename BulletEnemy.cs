using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class BulletEnemy : MonoBehaviour
{

    [SerializeField]
    private float bulletSpeed;


    // Start is called before the first frame update
    void Start()
    {
        this.GetComponent<Rigidbody2D>().velocity = -transform.right * bulletSpeed;
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        
        if (collision.gameObject.tag == "Player" || collision.gameObject.tag == "Body")
        {
            if (GameObject.Find("Snake").GetComponent<playerScript>().battleState == 2)
            {
                scoreScript.scoreValue = 0;
                // Load Scene again
                SceneManager.LoadScene("test1");
                
            }
            Destroy(gameObject);
            
        }
        else if (collision.gameObject.name.Contains("Bullet"))
        {
            Debug.Log("bala");
            Destroy(gameObject);
        } else
        {
            Destroy(gameObject, 1.3f);
        }
        

    }
}
