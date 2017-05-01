using UnityEngine;
using System.Collections;

public class GarbagePool : MonoBehaviour 
{
	
	public GameObject garbagePrefab;                                 //The column game object.
	public int garbagePoolSize = 5;                                  //How many columns to keep on standby.
	public float spawnRate = 3f;                                    //How quickly columns spawn.
	public float trashMin = -1f;                                   //Minimum y value of the column position.
	public float trashMax = 3.5f;                                  //Maximum y value of the column position.

	private GameObject[] garbages;                                   //Collection of pooled columns.
	private int currentGarbage = 0;                                  //Index of the current column in the collection.

	private Vector2 objectPoolPosition = new Vector2 (-15,-25);     //A holding position for our unused columns offscreen.
	private float spawnXPosition = 15f;

	private float timeSinceLastSpawned;


	void Start()
	{
		timeSinceLastSpawned = 0f;

		//Initialize the columns collection.
		garbages = new GameObject[garbagePoolSize];
		//Loop through the collection... 
		for(int i = 0; i < garbagePoolSize; i++)
		{
			//...and create the individual columns.
			garbages[i] = (GameObject)Instantiate(garbagePrefab, objectPoolPosition, Quaternion.identity);
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
			float spawnYPosition = Random.Range(trashMin, trashMax);

			//...then set the current column to that position.
			garbages[currentGarbage].transform.position = new Vector2(spawnXPosition, spawnYPosition);
			garbages [currentGarbage].SetActive (true);

			//Increase the value of currentColumn. If the new size is too big, set it back to zero
			currentGarbage ++;

			if (currentGarbage >= garbagePoolSize) 
			{
				currentGarbage = 0;
			}
		}      
	}
}