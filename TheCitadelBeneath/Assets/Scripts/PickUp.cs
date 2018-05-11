using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour 
{
	
	public GameObject player;
	public bool grabbed;
	Rigidbody2D body2D;
	public bool onRightSide;
	public bool onLeftSide;
	public bool onTop;
	public bool onBottom;

	public bool connected;
	public float force = 15;

	Light crystalLight;
	public float duration = 0.3f;

	public Animator anim;

	P2Movement player2Script;

	// Use this for initialization
	void Start () 
	{

		player2Script = GameObject.Find ("Player 2").GetComponent<P2Movement> ();


		body2D = GetComponent<Rigidbody2D> ();
		body2D.bodyType = RigidbodyType2D.Dynamic;

		if (this.gameObject.tag == ("CrystalInteractable")) 
		{
			body2D.bodyType = RigidbodyType2D.Kinematic;
			crystalLight = GetComponentInChildren<Light> ();
			crystalLight.enabled = false;
		}
	}
	
	// Update is called once per frame
	void Update () 
	{


		if (this.gameObject.tag == ("CrystalInteractable")) 
		{
			if (connected) 
			{
				crystalLight.enabled = true;
				transform.position = new Vector2(transform.position.x, Mathf.Lerp(transform.position.y,-1.5f, Time.deltaTime));
				body2D.gravityScale = 0;
				anim.SetTrigger ("Flash");

				StartCoroutine ("Timer");
			}
		}

		if (this.gameObject.tag == ("Interactable")) 
		{
			if (grabbed) 
			{
				body2D.constraints = RigidbodyConstraints2D.FreezePositionY;
				body2D.constraints = RigidbodyConstraints2D.FreezeRotation;
				body2D.velocity = Vector2.zero;

				if (onRightSide) 
				{
					this.transform.position = new Vector3 (player.transform.position.x + 1f, player.transform.position.y, player.transform.position.z);
				}

				if (onLeftSide) 
				{
					this.transform.position = new Vector3 (player.transform.position.x - 1f, player.transform.position.y, player.transform.position.z);
				}

			} 
			else 
			{
				body2D.constraints = RigidbodyConstraints2D.None;

			}
		}

		if (onLeftSide) 
		{
			onRightSide = false;
			onTop = false;
			onBottom = false;
		}
				
		if (onRightSide) 
		{
			onLeftSide = false;
			onTop = false;
			onBottom = false;
		}

		if (onTop) 
		{
			onLeftSide = false;
			onRightSide = false;
			onBottom = false;
		}

		if (onBottom) 
		{
			onLeftSide = false;
			onRightSide = false;
			onTop = false;
		}


	}

	public void OnTriggerEnter2D (Collider2D other)
	{
		if (other.gameObject.tag == "Player") 
		{
			Debug.Log ("AHH Someone is beside me!");
			player = other.gameObject;
		}

		if (other.gameObject.name == "ObjectSpaceRight") 
		{
			onRightSide = true;
		}

		if (other.gameObject.name == "ObjectSpaceLeft") 
		{
			onLeftSide = true;
		}


		if (other.gameObject.name == "Player 2") 
		{
			Debug.Log ("The Crystals begin to hum");
			GameObject.Find ("Player 2").GetComponent<P2Movement> ();
		}
	}

	public void OnTriggerExit2D (Collider2D other)
	{
		if (other.gameObject.tag == "Player") 
		{
			player = null;
			onLeftSide = false;
			onRightSide = false;
		}

	}

	public void SetParent(GameObject newParent)
	{
		this.transform.parent = newParent.transform;
		this.transform.position = new Vector3 (newParent.transform.position.x + 1f, newParent.transform.position.y, newParent.transform.position.z);
		grabbed = true;
	}

	public void DetachFromParent()
	{
		transform.parent = null;
		grabbed = false;
	}

	public void Connect()
	{
		if (player2Script.glowable == true)
		{
			connected = !connected;
		}
	}

	IEnumerator Timer()
	{
		yield return new WaitForSeconds (2.5f);
		connected = false;
		transform.position = new Vector2(transform.position.x, Mathf.Lerp(transform.position.y,-4f, Time.deltaTime));
		crystalLight.enabled = false;

	}

}
