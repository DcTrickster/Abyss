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

	// Use this for initialization
	void Start () 
	{
		body2D = GetComponent<Rigidbody2D> ();
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (grabbed) 
		{
			body2D.constraints = RigidbodyConstraints2D.FreezePositionY;
			body2D.constraints = RigidbodyConstraints2D.FreezeRotation;

			if (onRightSide) 
			{
				this.transform.position = new Vector3 (player.transform.position.x + 1f, player.transform.position.y, player.transform.position.z);
			}

			if (onLeftSide) 
			{
				this.transform.position = new Vector3 (player.transform.position.x - 1f, player.transform.position.y, player.transform.position.z);
			}

			if (onTop) 
			{
				this.transform.position = new Vector3 (player.transform.position.x, player.transform.position.y  + 1f, player.transform.position.z);
			}

			if (onBottom) 
			{
				this.transform.position = new Vector3 (player.transform.position.x, player.transform.position.y  - 1f, player.transform.position.z);
			}
		} 
		else 
		{
			body2D.constraints = RigidbodyConstraints2D.None;

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

		if (other.gameObject.name == "ObjectSpaceTop") 
		{
			onTop = true;
		}

		if (other.gameObject.name == "ObjectSpaceBottom") 
		{
			onBottom = true;
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

}
