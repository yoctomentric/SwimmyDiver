using UnityEngine;
using System.Collections;

public class GarbageMover : MonoBehaviour {

	public Vector2 velocity = new Vector2(-8, 0);

	// Use this for initialization
	void Update()
	{
		GetComponent<Rigidbody2D>().velocity = velocity;
	}




}