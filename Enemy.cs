using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    private GameObject otherSpaceShip;

    [SerializeField]
    Animator anim;

    [SerializeField]
    private int health;

    [SerializeField]
    private int typeEnemy;      // 0 - spaceship

    public int revives = 3;

    public bool canMove;

    public bool dead;


    void Start()
    {
        dead = false;
        canMove = true;
        anim = GetComponent<Animator>();
        anim.SetFloat("Health", health);
        anim.SetInteger("revives", revives);
    }

    void Update()
    {
        if (otherSpaceShip.GetComponent<Enemy>().dead == true && health <= 0)
        {
            GameObject.Find("Snake").GetComponent<playerScript>().battleState = 1;
            GameObject.Find("Snake").GetComponent<playerScript>().playerAnim.SetInteger("battleState", 0);
            //GameObject.Find("Snake").transform.position = transform.position;
            if (revives > 0)
            {
                StartCoroutine(reviveSpaceShip(1));
            }
            
        }
        
    }

    public void Damage(int valor)
    {
        health -= valor;

        if (health <= 0)
        {
            dead = true;
            canMove = false;
            // Play animação caso for nave
            if (typeEnemy == 0)
            {
                anim.SetFloat("Health", health);
                anim.SetInteger("revives", revives);
                
            }
        }

    }


    IEnumerator reviveSpaceShip( float delay)
    {
        yield return new WaitForSeconds(delay);
        health = 100;
        anim.SetFloat("Health", health);
        canMove = true;
        dead = false;
    }

}
