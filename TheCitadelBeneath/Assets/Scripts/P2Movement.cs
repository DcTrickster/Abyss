using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class P2Movement : MonoBehaviour 
{
	Rigidbody2D body;
	public float moveSpeed;
	public float minSpeed;
	public float maxSpeed;

	//Variable to flip sprite
	public bool facingRight = true;

	float deadzone = 0.25f;

	public bool isPaused;

	public KeyCode InteractKey;
	public KeyCode ThrowKey;
	public KeyCode PauseKey;

	public float moveHor;
	public float moveVer;
	public bool Flipped;

	public bool grabable = false;
	public bool grabbed = false;
	PickUp pickUpScript;

	void Start()
	{
		body = transform.GetComponent<Rigidbody2D>();
	}

	void Update ()
	{
		if (Input.GetKeyDown (PauseKey)) 
		{
			Debug.Log ("Paused");
		}

		if (Input.GetKey (InteractKey)) 
		{
			if (grabable) 
			{
				if (!grabbed) 
				{
					Debug.Log ("I grabbed something!");
					pickUpScript.SetParent(this.gameObject);
					grabbed = true;
				}

			}
		}

		if (Input.GetKeyUp (InteractKey)) 
		{
			Debug.Log ("I let something go!");
			pickUpScript.DetachFromParent();
			grabbed = false;
		}

		if (Input.GetKeyDown (ThrowKey)) 
		{
			Debug.Log ("Tossed!");
		}
	}


	void FixedUpdate()
	{

		moveHor = Input.GetAxisRaw ("PlayerTwoLeftJoystickHor");
		moveVer = Input.GetAxisRaw ("PlayerTwoLeftJoystickVert");

		Vector2 stickInput = new Vector2 (moveHor, moveVer);
		if (Mathf.Abs (stickInput.x) < deadzone)
			stickInput.x = 0.0f;
		if (Mathf.Abs (stickInput.y) < deadzone)
			stickInput.y = 0.0f;

		Vector2 movement = new Vector2 (moveHor, moveVer);

		body.AddForce (movement * (Mathf.Clamp(Time.time, minSpeed, maxSpeed)));
	}


	public void OnTriggerEnter2D(Collider2D other)
	{
		if (other.gameObject.tag == "Interactable") 
		{
			pickUpScript = other.gameObject.GetComponent<PickUp> ();
			grabable = true;
		}
	}

	public void OnTriggerExit2D(Collider2D other)
	{
		if (other.gameObject.tag == "Interactable") 
		{
			grabable = false;
		}
	}

}