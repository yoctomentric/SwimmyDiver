using UnityEngine;
using System.Collections;

public class TrashCollection : MonoBehaviour {

	public int trashScoreValue;
	public ScoreKeeper gameController;
	public int garbageScoreValue;


	void OnTriggerEnter2D(Collider2D other) 
	{
		if (other.gameObject.tag == "PickUpTrash")
		{
			other.gameObject.SetActive (false);
			gameController.AddScore (trashScoreValue);

		}
		if (other.gameObject.tag == "PickUpGarbage")
		{
			other.gameObject.SetActive (false);
			gameController.AddScore (garbageScoreValue);
		}



	}
}
