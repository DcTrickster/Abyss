using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IgnoreCollisions : MonoBehaviour 
{

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnCollisionEnter2D (Collision2D other)
	{
		if (this.gameObject.name == "WaterRim") 
		{
			if (other.gameObject.layer == 11) 
			{
				Physics2D.IgnoreLayerCollision (11, 8); 
			}

			if (other.gameObject.layer == 9) 
			{
				Physics2D.IgnoreLayerCollision (9, 8); 
			}
		}

		if (this.gameObject.name == "AirPocket") 
		{
			if (other.gameObject.layer == 12) 
			{
				Physics2D.IgnoreLayerCollision (12, 13); 
			}

		}

		if (other.gameObject.layer == 10)
		{
			Physics2D.IgnoreLayerCollision (13,10); 
		}
	}
}
