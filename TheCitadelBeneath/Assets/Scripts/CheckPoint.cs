﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoint : MonoBehaviour 
{
	LevelManager levelManager;

	// Use this for initialization
	void Start () 
	{
		levelManager = FindObjectOfType<LevelManager> ();
	}
	
	// Update is called once per frame
	void Update () 
	{
		
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.name == "Player 1") 
		{
			levelManager.currentCheckpointP1 = gameObject;
		}

		if (other.name == "Player 2") 
		{
			levelManager.currentCheckpointP2 = gameObject;
		}
	}
}

