using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteFlipper : MonoBehaviour 
{

	public GameObject player1;
	public GameObject player2;

	//Variable to flip sprite
	public bool facingRight = true;

	void Start()
	{
	}

	public void FixedUpdate()
	{

		if (this.gameObject.name == "PlayerSprite1")
		{
			if (player1.GetComponent<P1Movement> ().moveHor > 0 && !facingRight) 
			{
				Flip ();
				facingRight = true;
			} 
			else if (player1.GetComponent<P1Movement> ().moveHor < 0 && facingRight) 
			{
				Flip ();
				facingRight = false;
			}
	}

		if (this.gameObject.name == "PlayerSprite2") 
		{
			if (player2.GetComponent<P2Movement> ().moveHor > 0 && !facingRight) 
			{
				Flip ();
				facingRight = true;
			} 
			else if (player2.GetComponent<P2Movement> ().moveHor < 0 && facingRight) 
			{
				Flip ();
				facingRight = false;
			}
		}
	}

	public void Flip()
	{
		facingRight = !facingRight;
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
	}
}
