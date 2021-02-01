using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hearts : MonoBehaviour
{
    [SerializeField]
    private GameObject[] spaceships;

    // Start is called before the first frame update
    void Start()
    {
        spaceships = GameObject.FindGameObjectsWithTag("Enemy");
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Destroy(this.gameObject);
            collision.gameObject.GetComponent<playerScript>().battleState = 2;
            collision.gameObject.GetComponent<playerScript>().playerAnim.SetInteger("battleState", 2);
            for (int i = 0; i < spaceships.Length; i++)
            {
                spaceships[i].GetComponent<Enemy>().revives--;
            }
            
        }
        
    }
}
