using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Food : MonoBehaviour
{
    [SerializeField]
    private float maxWidth = 0.35f;             // largura e altura max para spawnar comida
    [SerializeField]
    private float maxHeight = 0.20f;
	private Vector2 foodSpawnPoint;
    [SerializeField]
    private GameObject foodPrefab;

    void OnCollisionEnter2D(Collision2D collision)
    {
        // aumenta tamanho da snake
		if (collision.gameObject.tag == "Player")
		{
			spawnFood();
			print("poof");
            Destroy(this.gameObject);


		}
		
    }
	
	private void spawnFood()
    {
		foodSpawnPoint.x = Random.Range(-maxWidth, maxWidth);
		foodSpawnPoint.y = Random.Range(-maxHeight, maxHeight);

		Debug.Log("SpawnPositionFood: " + foodSpawnPoint);
		GameObject prefabFood = Instantiate(foodPrefab);
		prefabFood.transform.position = foodSpawnPoint;
    }
}
