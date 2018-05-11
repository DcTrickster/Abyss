using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialScript : MonoBehaviour 
{
	public Animator anim;
	public GameObject TutorialMessage;

	// Use this for initialization
	void Start () 
	{
		TutorialMessage.SetActive (false);
	}
	
	// Update is called once per frame
	void Update () 
	{
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.gameObject.tag == "Player") 
		{
			TutorialMessage.SetActive (true);
			anim.SetBool("FadeIn", true);
			anim.SetBool("FadeOut", false);

		}
	}

	void OnTriggerExit2D(Collider2D other)
	{
		if (other.gameObject.tag == "Player") 
		{
			anim.SetBool("FadeIn", false);
			anim.SetBool("FadeOut", true);
//			TutorialMessage.SetActive (false);

		}
	}
}
