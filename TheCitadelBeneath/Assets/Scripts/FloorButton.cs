using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorButton : MonoBehaviour 
{

	public GameObject horizontalWalls;
	public GameObject verticalWalls;

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
		if (other.gameObject.name == "Boulder") 
		{
			horizontalWalls.SetActive (true);
			verticalWalls.SetActive (false);
		}
	}

	public void OnTriggerExit2D (Collider2D other)
	{
		if (other.gameObject.name == "Boulder") 
		{
			horizontalWalls.SetActive (false);
			verticalWalls.SetActive (true);
		}
	}
}
