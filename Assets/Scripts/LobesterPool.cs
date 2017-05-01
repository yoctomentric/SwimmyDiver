
using UnityEngine;
using System.Collections;

public class LobesterPool : MonoBehaviour 
{
	public GameObject LobesterPrefab;                                 //The bottle game object.
	public int lobesterPoolSize = 5;                                  //How many columns to keep on standby.
	public float spawnRate = 3f;                                    //How quickly columns spawn.
	public float lobesterMin = -1f;                                   //Minimum y value of the column position.
	public float lobesterMax = 3.5f;                                  //Maximum y value of the column position.

	private GameObject[] lobesters;                                   //Collection of pooled columns.
	private int currentLobester = 0;                                  //Index of the current column in the collection.

	private Vector2 objectPoolPosition = new Vector2 (-15,-25);     //A holding position for our unused columns offscreen.
	private float spawnXPosition = 15f;

	private float timeSinceLastSpawned;


	void Start()
	{
		timeSinceLastSpawned = 0f;

		//Initialize the columns collection.
		lobesters = new GameObject[lobesterPoolSize];
		//Loop through the collection... 
		for(int i = 0; i < lobesterPoolSize; i++)
		{
			//...and create the individual columns.
			lobesters[i] = (GameObject)Instantiate(LobesterPrefab, objectPoolPosition, Quaternion.identity);
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
			float spawnYPosition = Random.Range(lobesterMin, lobesterMax);

			//...then set the current column to that position.
			lobesters[currentLobester].transform.position = new Vector2(spawnXPosition, spawnYPosition);
			lobesters[currentLobester].SetActive (true);

			//Increase the value of currentColumn. If the new size is too big, set it back to zero
			currentLobester ++;

			if (currentLobester >= lobesterPoolSize) 
			{
				currentLobester = 0;
			}
		}      
	}
}