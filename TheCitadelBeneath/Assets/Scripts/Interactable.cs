using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Interactable : MonoBehaviour 
{
	public GameObject interactButton;


	// Use this for initialization
	void Start () 
	{
		interactButton.SetActive(false);
	}
	
	// Update is called once per frame
	public void OnTriggerEnter2D (Collider2D other)
	{
		if (this.gameObject.tag == "Interactable")
		{
			if (other.gameObject.name == "Player 1") 
				{
					interactButton.SetActive(true);
				}
		}

		if (this.gameObject.tag == "CrystalInteractable")
		{
			if (other.gameObject.name == "Player 2") 
			{
				interactButton.SetActive(true);
			}
		}
	}

	public void OnTriggerExit2D (Collider2D other)
	{
		if (other.gameObject.tag == "Player") 
		{
			interactButton.SetActive(false);
		}
	}
}
