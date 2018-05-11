using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CrystalLightUp : MonoBehaviour 
{
	public GameObject lights;
	public bool lit = false;
	public Canvas finalCanvas;

	// Use this for initialization
	void Start () 
	{
		lights.SetActive (false);
		finalCanvas.enabled = false;

	}
	
	// Update is called once per frame
	void Update () 
	{
		
	}

	public void OnCollisionEnter2D (Collision2D other)
	{
		if (other.gameObject.tag == "Player") 
		{
			lit = true;
			Debug.Log ("Finshed!");
			lights.SetActive (true);
			finalCanvas.enabled = true;
			StartCoroutine ("Restart");
		}
	}

	IEnumerator Restart()
	{
		yield return new WaitForSeconds (8);

		SceneManager.LoadScene (0);
	}
}
