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

	public bool glowable = false;
	PickUp pickUpScript;

	public LevelManager levelManager;

	public Animator anim;


	void Start()
	{
		body = transform.GetComponent<Rigidbody2D>();
		levelManager = FindObjectOfType<LevelManager> ();

	}

	void Update ()
	{
		if (Input.GetKeyDown (PauseKey)) 
		{
			Debug.Log ("Paused");
		}

		if (Input.GetKeyDown (InteractKey)) 
		{

			if (glowable) 
			{
				Debug.Log ("Connecting");
				anim.SetTrigger ("GlowGreen");

				pickUpScript.Connect ();
			}
		}

		if (Input.GetKeyDown (ThrowKey)) 
		{
			Debug.Log ("Tossed!");
		}
	}


	void FixedUpdate()
	{

		moveHor = Input.GetAxisRaw ("PlayerTwoLeftJoystickHor")  * Mathf.Lerp(minSpeed,maxSpeed,Time.deltaTime) * Time.deltaTime;
		moveVer = Input.GetAxisRaw ("PlayerTwoLeftJoystickVert") * Mathf.Lerp (minSpeed, maxSpeed, Time.deltaTime) * Time.deltaTime;

		Vector2 stickInput = new Vector2 (moveHor, moveVer);
		if (Mathf.Abs (stickInput.x) < deadzone)
			stickInput.x = 0.0f;
		if (Mathf.Abs (stickInput.y) < deadzone)
			stickInput.y = 0.0f;

		Vector2 movement = new Vector2 (moveHor, moveVer);

		body.AddForce (movement * (Mathf.Clamp(Time.time, minSpeed, maxSpeed)));

//		if (moveHor < 0) 
//		{
//		}
//
//		if (moveHor > 0) 
//		{
//		}

	}


	public void OnTriggerEnter2D(Collider2D other)
	{

		if (other.gameObject.tag == "CrystalInteractable") 
		{
			glowable = true;
			pickUpScript = other.gameObject.GetComponent<PickUp> ();
		}

		if (other.gameObject.tag == "Land") 
		{
			Respawn ();
		}
	}

	public void OnTriggerExit2D(Collider2D other)
	{
		if (other.gameObject.tag == "CrystalInteractable") 
		{
			glowable = false;
		}
	}

	void OnCollisionEnter2D (Collision2D other)
	{
		if (other.gameObject.name == "AirPocket") 
		{
			body.velocity = Vector2.zero;
		}
	}

	void Respawn()
	{
		GetComponent<Rigidbody2D> ().velocity = Vector2.zero;
		this.transform.position = levelManager.currentCheckpointP2.transform.position;
	}


}