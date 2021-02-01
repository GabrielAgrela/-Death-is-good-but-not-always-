using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class playerScript : MonoBehaviour
{
	private float nextActionTime;                // verificar se atingiu o tempo

    public Animator playerAnim;

	public Animator animator;
	public Animator animator2;
	public GameObject camera;
	public int counter=0;
	public int start = 0;
	private int win = 0;
	private int wasLvl1=1;
    [SerializeField]
    private float timeBetween = .1f;
	private GameObject[] spaceships;
    public float period = 0.01f;                 // pixels per mov
    private Vector2 snakeGridPos;                // posição da snake na grid
    private Vector2 moveDir;                     // moveDir default
    private int snakeSize;                       // tamanho da cobra

    [SerializeField]
    private AudioClip eatSound;

    [SerializeField]
    private AudioClip areaCompleted;

    private AudioSource source;

    [SerializeField]
    private GameObject prefabBody;

    private List<Vector2> lastPositions;        // last positions of snake body

    public int battleState;

    void Awake()
	{
        source = GetComponent<AudioSource>();
        //animator.SetInteger("lvl",3);
		 //animator2.SetInteger("tlvl",2);
        playerAnim = GetComponent<Animator>();
        battleState = 0;
		wasLvl1=0;
		QualitySettings.vSyncCount = 0;
		Application.targetFrameRate=8;
        snakeSize = 0;
        snakeGridPos = new Vector2(0, 0);        // pos Inicial da snake
        nextActionTime = timeBetween;
        moveDir = new Vector2(period, 0);       // move-se para a direita no inicio do jogo por default
        lastPositions = new List<Vector2>();
    }

	void Update () 
	{//print(battleState);
		/*if (snakeSize == 1)
		{
			
			//cima camera.transform.position = new Vector3(0f, 0.48f, -10f);
			//baixo camera.transform.position = new Vector3(0f, -0.48f, -10f);
			//esq camera.transform.position = new Vector3(-0.84f, 0f, -10f);
			//dir camera.transform.position = new Vector3(0.84f, 0f, -10f);
		}
			
		if (snakeSize == 2)
			//animator.SetInteger("lvl",2);
		if (snakeSize == 3)
			//animator.SetInteger("lvl",3);
		if (snakeSize == 4)
			//animator.SetInteger("lvl",4);
		*/
		print ("CCCCCCCCCOOOOOOOOOOOOUUUUUUUNTER "+counter);
		if (counter == 12)
			win=1;
        if (battleState == 1)
        {
			//print(battleState);
            Movement();
        }
	}
	
	public void up()
	{
		 if (moveDir.y != -period)           // so se pode andar para cima se nao tivermos a andar para baixo
            {
                moveDir.x = 0;
                moveDir.y = period;
            }
	}
	
	public void down()
	{
		if (moveDir.y != period)
            {
                moveDir.x = 0;
                moveDir.y = -period;
            }
	}
	
	public void l()
	{
		if (moveDir.x != period)
            {
                moveDir.x = -period;
                moveDir.y = 0;
            }
	}
	
	public void r()
	{
		if (moveDir.x != -period)           // so se pode andar para a direita se nao tivermos a andar para a esquerda
            {
                moveDir.x = period;
                moveDir.y = 0;
            }
	}

    private void Movement()
    {
        if (Input.GetKey(KeyCode.UpArrow))
        {
            if (moveDir.y != -period)           // so se pode andar para cima se nao tivermos a andar para baixo
            {
                moveDir.x = 0;
                moveDir.y = period;
            }

        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            if (moveDir.y != period)
            {
                moveDir.x = 0;
                moveDir.y = -period;
            }
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            if (moveDir.x != -period)           // so se pode andar para a direita se nao tivermos a andar para a esquerda
            {
                moveDir.x = period;
                moveDir.y = 0;
            }
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            if (moveDir.x != period)
            {
                moveDir.x = -period;
                moveDir.y = 0;
            }

        }

        nextActionTime += Time.deltaTime;

        if (nextActionTime >= timeBetween)                  // mover na direção se passou timeBetween tempo
        {
            lastPositions.Insert(0, snakeGridPos);          // guarda posição anterior

            snakeGridPos += moveDir;
            nextActionTime -= timeBetween;

            if (lastPositions.Count >= snakeSize+2  )       // se o tamanho da lista ja for maior que o tamanho da cobra, remove a ultima posição da lista
            {
                lastPositions.RemoveAt(lastPositions.Count - 1);
            }
			//print(lastPositions.Count);
            for (int i = 0; i < lastPositions.Count; i++)       // instancia o body na posição que ele tava antes
            {
				
				print("x: "+lastPositions[0][0]);
				print("y: "+lastPositions[0][1]);
				if (lastPositions[0][1] > 0.70f)
				{
					print("xDxDX"+1);
					snakeGridPos.y=0.30f;
				}
				if (lastPositions[0][1] < -0.70f)
				{
					print("xDxDX"+2);
					snakeGridPos.y=-0.20f;
				}
				if (lastPositions[0][0] > 0.38f && animator.GetInteger("lvl") != 3)
				{
					print("xDxDX"+3 + " " + animator.GetInteger("lvl"));
					snakeGridPos.x=-0.38f;
				}
				if (lastPositions[0][0] < -0.39f && animator.GetInteger("lvl") != 2)
				{print("xDxDX"+4);
					snakeGridPos.x=0.37f;
				}
				if (lastPositions[0][1] > 0.15f && animator.GetInteger("lvl") != 1)
				{print("xDxDX"+5);
					print(animator.GetInteger("lvl")+ " XD");
					if (animator.GetInteger("lvl") == 2)
						print(animator.GetInteger("lvl")+ " XD");
					else
					snakeGridPos.y=-0.18f;
				}
				
				if (lastPositions[0][1] < -0.19f && animator.GetInteger("lvl") != 4)
				{
					print("xDxDX"+6);
					snakeGridPos.y=0.14f;
				}
				
				
				if (lastPositions[0][1]> 0.23f  && animator.GetInteger("lvl") !=2 )
				{print("xDxDX"+7);
					wasLvl1=1;
					//animator2.SetInteger("tlvl",1);
					camera.transform.position = new Vector3(0f, 0.48f, -10f);
				}		
				else if (lastPositions[0][1]< -0.27f)
					camera.transform.position = new Vector3(0f, -0.48f, -10f);
				else if (lastPositions[0][0]> 0.40f)
					camera.transform.position = new Vector3(0.84f, 0f, -10f);
				else if (lastPositions[0][0]< -0.46f)
					camera.transform.position = new Vector3(-0.84f, 0f, -10f);
				else {
						int lol=0;
						spaceships = GameObject.FindGameObjectsWithTag("Enemy");
						if (spaceships[0].GetComponent<Enemy>().dead == true && spaceships[1].GetComponent<Enemy>().dead == true && wasLvl1==1 && animator.GetInteger("lvl") !=3)
						{
							camera.transform.position = new Vector3(0f, 0f, -10f);
							StartCoroutine(ExecuteAfterTime(1));
						}
						else if (animator.GetInteger("lvl") ==3 && lastPositions[0][0]> 0.35f) 
							camera.transform.position = new Vector3(0.84f, 0f, -10f);
						else if (start == 0) 
						{
							camera.transform.position = new Vector3(0f, -0.48f, -10f);
						}
						else
						{
							camera.transform.position = new Vector3(0f, 0f, -10f);
						}
					}
				if (win == 1) 
					{
						camera.transform.position = new Vector3(0f, -0.96f, -10f);
					}
				if (lastPositions[0]==lastPositions[i] && i != 0 && wasLvl1!=1)
				{
					
					scoreScript.scoreValue=50;
					animator.SetInteger("lvl",1);
                    source.PlayOneShot(areaCompleted);

                    /*snakeGridPos.x=0;
					snakeGridPos.y=0;*/
                    //print(lastPositions.Count);
                    lastPositions.RemoveAt(0);
					snakeSize--;
				}
				else
				{
					Vector2 snakeMovePos = lastPositions[i];
					GameObject body = Instantiate(prefabBody);
					body.transform.position = snakeMovePos;
					
					Destroy(body, timeBetween);                    // Destroi esse body depois de timeBetween tempo
				}
                
            }

        }


        transform.position = new Vector3(snakeGridPos.x, snakeGridPos.y, 0);
    }

	
	IEnumerator ExecuteAfterTime(float time)
	 {
		yield return new WaitForSeconds(time);
	 
		animator.SetInteger("lvl",2);
        //source.PlayOneShot(areaCompleted); 
        //animator2.SetInteger("tlvl",2);
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Food")
        {
			if (animator.GetInteger("lvl")==3)
				counter++;
            source.PlayOneShot(eatSound);
            scoreScript.scoreValue+= 10;
            snakeSize++;
			
        }
		if (collision.gameObject.tag == "skull")
        {
            source.PlayOneShot(eatSound);
            animator.SetInteger("lvl",3);
            source.PlayOneShot(areaCompleted);
            //animator2.SetInteger("tlvl",3);
            camera.transform.position = new Vector3(0f, 0f, -10f);
			snakeGridPos.y=0f;
			snakeGridPos.x=0f;
            //snakeSize--;
        }
		if (collision.gameObject.tag == "wall")
        {
			moveDir.x = -period;
            moveDir.y = 0;
			print("XDDDDDDDDDDDDDDDDDD");
			snakeGridPos.x=-0.52f;
			snakeGridPos.y=-0.18f;
			/*if (collision.transform.position.x > 0.4f)
			{
				print("1");
				snakeGridPos.x=collision.transform.position.x-0.76f;
				snakeGridPos.y=collision.transform.position.y;	
			}*/
			/*if (collision.transform.position.x < -0.39f)
			{
				print("2");
				snakeGridPos.x=collision.transform.position.x+0.76f;
				snakeGridPos.y=collision.transform.position.y;	
			}
			else if (collision.transform.position.y < -0.218f)
			{
				print("3");
				snakeGridPos.x=collision.transform.position.x;
				snakeGridPos.y=collision.transform.position.y+0.36f;	
			}
			else if (collision.transform.position.y > 0.168f)
			{
				//print(collision.transform.position.x);
				print("4");
				snakeGridPos.x=collision.transform.position.x;
				snakeGridPos.y=collision.transform.position.y-0.36f;	
			}*/
			//print(collision.transform.position.y);
			//print("ok");
        }
    }
}
