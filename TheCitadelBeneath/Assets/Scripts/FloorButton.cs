using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorButton : MonoBehaviour 
{

	public GameObject horizontalWalls;
	public GameObject verticalWalls;

	public AudioClip buttonClip;
	public AudioSource buttonClick;

	// Use this for initialization
	void Start () 
	{
		horizontalWalls.SetActive (false);
		verticalWalls.SetActive (true);
	}
	
	// Update is called once per frame
	void Update () 
	{
		
	}

	public void OnTriggerEnter2D (Collider2D other)
	{
		if (this.gameObject.name == "BigButton") 
		{
			if (other.gameObject.name == "Boulder") 
			{
				horizontalWalls.SetActive (true);
				verticalWalls.SetActive (false);
				SpriteRenderer renderer = GetComponent<SpriteRenderer> ();
				renderer.color = new Color (0, 205, 0);
			}
		}

		if (this.gameObject.name == "SmallButton") 
		{
			if (other.gameObject.name == "Player 1" || other.gameObject.name == "Boulder") 
			{
				horizontalWalls.SetActive (true);
				verticalWalls.SetActive (false);
				SpriteRenderer renderer = GetComponent<SpriteRenderer> ();
				renderer.color = new Color (0, 205, 0);
			}
		}
	}

	public void OnTriggerExit2D (Collider2D other)
	{
		if (this.gameObject.name == "BigButton") 
		{
			if (other.gameObject.name == "Boulder") 
			{
				buttonClick.PlayOneShot (buttonClip);
				horizontalWalls.SetActive (false);
				verticalWalls.SetActive (true);
				SpriteRenderer renderer = GetComponent<SpriteRenderer> ();
				renderer.color = new Color (255, 0, 0);
			}
		}



		if (this.gameObject.name == "SmallButton") 
		{
			if (other.gameObject.name == "Player 1" || other.gameObject.name == "Boulder") 
			{
				horizontalWalls.SetActive (false);
				verticalWalls.SetActive (true);
				SpriteRenderer renderer = GetComponent<SpriteRenderer> ();
				renderer.color = new Color (0, 0, 255);
			}
		}
	}
}
