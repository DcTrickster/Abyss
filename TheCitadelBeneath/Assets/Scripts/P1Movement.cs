using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class P1Movement : MonoBehaviour 
{
	Rigidbody2D body;
	public float moveSpeed;
	public float maxSpeed;
	public bool jump = false;
	public float jumpForce;
	public bool canJump;

	public KeyCode JumpKey;
	public KeyCode InteractKey;
	public KeyCode ThrowKey;
	public KeyCode PauseKey;


	float deadzone = 0.25f;

	public bool isPaused;

	public float moveHor;
	public float moveVer;

	public bool grabable = false;
	public bool grabbed = false;
	PickUp pickUpScript;

	void Start()
	{
		body = transform.GetComponent<Rigidbody2D>();
		canJump = true;
	}

	void Update ()
	{
		if (Input.GetKeyDown(JumpKey) && canJump == true)
		{
			Debug.Log ("Jumped");
			body.velocity = new Vector2 (body.velocity.x, jumpForce);
			canJump = false;
//			jump = true;
		}

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

		moveHor = Input.GetAxisRaw ("PlayerOneLeftJoystickHor") * moveSpeed * Time.deltaTime;
		moveVer = Input.GetAxisRaw ("PlayerOneLeftJoystickVert") * moveSpeed * Time.deltaTime;

		Vector2 stickInput = new Vector2 (moveHor, moveVer);
		if (Mathf.Abs (stickInput.x) < deadzone)
			stickInput.x = 0.0f;
		if (Mathf.Abs (stickInput.y) < deadzone)
			stickInput.y = 0.0f;

		Vector2 movement = new Vector2 (moveHor, moveVer);

		body.AddForce (movement * moveSpeed);

	}


	public void Pause()
	{
		
	}

	public void Interact()
	{
		
	}

	public void Throw()
	{

	}

	public void OnTriggerEnter2D(Collider2D other)
	{
		if (other.gameObject.tag == "Interactable") 
		{
			pickUpScript = other.gameObject.GetComponent<PickUp> ();
			grabable = true;
		}

		if (other.gameObject.tag == "Underwater") 
		{
			//Player Dies
		}
	}

	public void OnTriggerExit2D(Collider2D other)
	{
		if (other.gameObject.tag == "Interactable") 
		{
			grabable = false;
		}
	}

	void OnCollisionEnter2D (Collision2D other)
	{
		if(other.gameObject.CompareTag("Ground"))
		{
			canJump = true;
		}
	}
}