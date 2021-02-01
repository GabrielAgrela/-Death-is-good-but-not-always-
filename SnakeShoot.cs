using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeShoot : MonoBehaviour
{
    private Animator anim;

    public Transform spawnPoint;

    [SerializeField]
    private GameObject bulletPrefab;

    private playerScript PlayerScript;

    [SerializeField]
    private float speed;

    private bool spawned;
    private Vector2 moveDir;

    [SerializeField]
    private float period = 0.02f;

    [SerializeField]
    private float maxHeight;

    [SerializeField]
    private float minHeight;

    [SerializeField]
    private float delayBetweenShots;
    private float timePassed;

    [SerializeField]
    private AudioClip shootShound;

    private AudioSource source;

    // Start is called before the first frame update
    void Start()
    {
        source = GetComponent<AudioSource>();
        anim = GetComponent<Animator>();
        moveDir = new Vector2(spawnPoint.position.x, spawnPoint.position.y);
        spawned = false;
        PlayerScript = gameObject.GetComponent<playerScript>();
    }

    // Update is called once per frame
    void Update()
    {
        // battleState shoot
        if (PlayerScript.battleState == 2)
        {
            setPosition();
            move();
            shoot();
        }
    }

    // set snake position to the spawn Point
    private void setPosition()
    {
        if (!spawned)
        {
            transform.position = new Vector3(spawnPoint.position.x, 0, 0);
            Debug.Log("SnakeShoot Onde spawnou a cobra: " + spawnPoint.position);
            spawned = true;
        }
    }
	
	public void up()
	{
		 moveDir.y += period;
	}
	
	public void down()
	{
		 moveDir.y -= period;
	}

    // move in y axis
    private void move()
    {
        // limite de onde se pode mover
        if (transform.position.y < maxHeight)
        {
            if (Input.GetKey(KeyCode.UpArrow))
            {
                moveDir.y += period;
            }
        }
        if (transform.position.y > minHeight)
        {
            if (Input.GetKey(KeyCode.DownArrow))
            {
                moveDir.y -= period;
            }
        }
 
        transform.position = moveDir;
    }


    // shoot stuff
    private void shoot()
    {
        timePassed += Time.deltaTime;
        if (Input.GetKey(KeyCode.Space) || Input.GetMouseButtonDown(0))
        {

            if (timePassed >= delayBetweenShots)
            {

                timePassed = 0;
                Instantiate(bulletPrefab, new Vector2(transform.position.x, transform.position.y), Quaternion.identity);
                source.PlayOneShot(shootShound);
            }
        }
    }
}
