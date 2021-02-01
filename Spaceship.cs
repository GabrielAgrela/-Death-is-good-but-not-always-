using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spaceship : MonoBehaviour
{
    [SerializeField]
    private GameObject bulletPrefab;

    [SerializeField]
    private Transform shootPoint;

    [SerializeField]
    private float timeBetweenShots;
    private float timePassed;

    [SerializeField]
    private float heightMax;

    [SerializeField]
    private float heightMin;

    [SerializeField]
    private float speed = 0.03f;

    private Vector3 posTop, posDown, currentGoal;

    void Start()
    {

        posTop = new Vector3(transform.position.x, heightMax, transform.position.z);
        posDown = new Vector3(transform.position.x, heightMin, transform.position.z);
        currentGoal = posTop;
    }

    // Update is called once per frame
    void Update()
    {
        if (gameObject.GetComponent<Enemy>().canMove)
        {
            Shoot();
            Move();
        }
        
    }

    private void Shoot()
    {
        timePassed += Time.deltaTime;
        if (timePassed >= timeBetweenShots)
        {
            timePassed = 0;
            // shoot
            GameObject bullet = Instantiate(bulletPrefab, new Vector2(shootPoint.position.x, shootPoint.position.y), Quaternion.identity);
        }
    }

    // mover spaceship up and down
    private void Move()
    {
        transform.position = Vector3.MoveTowards(transform.position, currentGoal, Time.deltaTime * speed);

        Vector3 currentPos = new Vector3(transform.position.x, transform.position.y, transform.position.z);

        if (Vector3.Distance(currentPos, currentGoal) == 0)
        {
            changePos();
        }

    }

    private void changePos()
    {
        if (currentGoal == posTop)
        {
            currentGoal = posDown;
        } else
        {
            currentGoal = posTop;
        }
    }

}
