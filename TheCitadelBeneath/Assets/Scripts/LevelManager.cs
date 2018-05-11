using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class LevelManager : MonoBehaviour 
{
	public GameObject currentCheckpointP1;
	public GameObject currentCheckpointP2;


	// Use this for initialization
	void Start () 
	{
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (Input.GetKeyDown(KeyCode.Q))
		{
			Restart();
		}
	}

	public void Restart()
	{
		SceneManager.LoadScene (0);
	}
}
