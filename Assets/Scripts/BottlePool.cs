using UnityEngine;
using System.Collections;

public class BottlePool : MonoBehaviour 
{
	public GameObject bottlePrefab;                                 //The bottle game object.
	public int bottlePoolSize = 5;                                  //How many columns to keep on standby.
	public float spawnRate = 3f;                                    //How quickly columns spawn.
	public float bottleMin = -1f;                                   //Minimum y value of the column position.
	public float bottleMax = 3.5f;                                  //Maximum y value of the column position.

	private GameObject[] bottles;                                   //Collection of pooled columns.
	private int currentBottle = 0;                                  //Index of the current column in the collection.

	private Vector2 objectPoolPosition = new Vector2 (-15,-25);     //A holding position for our unused columns offscreen.
	private float spawnXPosition = 15f;

	private float timeSinceLastSpawned;


	void Start()
	{
		timeSinceLastSpawned = 0f;

		//Initialize the columns collection.
		bottles = new GameObject[bottlePoolSize];
		//Loop through the collection... 
		for(int i = 0; i < bottlePoolSize; i++)
		{
			//...and create the individual columns.
			bottles[i] = (GameObject)Instantiate(bottlePrefab, objectPoolPosition, Quaternion.identity);
		}
	}


	//This spawns columns as long as the game is not over.
	void Update()
	{
		timeSinceLastSpawned += Time.deltaTime;

		if (timeSinceLastSpawned >= spawnRate)   //ADD THIS ONCE ENDSTATE IS DEFINED: GameControl.instance.gameOver == false &&
		{    
			timeSinceLastSpawned = 0f;

			//Set a random y position for the column
			float spawnYPosition = Random.Range(bottleMin, bottleMax);

			//...then set the current column to that position.
			bottles[currentBottle].transform.position = new Vector2(spawnXPosition, spawnYPosition);
			bottles[currentBottle].SetActive (true);

			//Increase the value of currentColumn. If the new size is too big, set it back to zero
			currentBottle ++;

			if (currentBottle >= bottlePoolSize) 
			{
				currentBottle = 0;
			}
		}      
	}
}