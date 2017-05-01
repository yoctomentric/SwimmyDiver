using UnityEngine;
using System.Collections;

public class TrashMover : MonoBehaviour {

	public Vector2 velocity = new Vector2(-8, 0);
	Vector3 tempPos;



	void Update()
	{
		GetComponent<Rigidbody2D>().velocity = velocity;

	
	}





}