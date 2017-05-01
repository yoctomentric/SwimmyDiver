using UnityEngine;
using System.Collections;


public class Player : MonoBehaviour
{
	// The force which is added when the player jumps
	// This can be changed in the Inspector window
	public Vector2 jumpForce = new Vector2(0, 300);

	// Update is called once per frame
	void Update ()
	{
		// Jump
		if (Input.GetKeyUp("space"))
		{
			GetComponent<Rigidbody2D>().velocity = Vector2.zero;
			GetComponent<Rigidbody2D>().AddForce(jumpForce);
		}
		if (transform.position.y < -6) {
			gameObject.SetActive (false);
			//LoseScreen.Setactive (true);


		}
		if (transform.position.y > 6) {
			gameObject.SetActive (false);
			//LoseScreen.Setactive (true);


		}



	}



}
