using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lobesterMover : MonoBehaviour {


	public Vector2 velocity = new Vector2(-8, 0);
	Vector3 tempPos;



	void Update()
	{
		GetComponent<Rigidbody2D>().velocity = velocity;


	}
}