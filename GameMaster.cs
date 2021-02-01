using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMaster : MonoBehaviour
{

    [SerializeField]
    private float maxWidth = 0.42f;             // largura e altura max para spawnar comida
    [SerializeField]
    private float maxHeight = 0.24f;

    [SerializeField]
    private GameObject foodPrefab;

    private Vector2 foodSpawnPoint;

    private GameObject player;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    private void Update()
    {
        //spawnFood();
    }


    private void spawnFood()
    {

        if (GameObject.FindGameObjectWithTag("Food") == null)       // se não existe comida no jogo
        {
            foodSpawnPoint.x = Random.Range(-maxWidth, maxWidth);
            foodSpawnPoint.y = Random.Range(-maxHeight, maxHeight);

            //Debug.Log("SpawnPositionFood: " + foodSpawnPoint);
            GameObject prefabFood = Instantiate(foodPrefab);
            prefabFood.transform.position = foodSpawnPoint;
        }
    }
}
