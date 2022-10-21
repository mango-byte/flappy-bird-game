using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundMove : MonoBehaviour
{
    	void FixedUpdate () 
	{
		
		if (PlayerScript.dead)
		{
			return;
		}
		else{
			
			transform.position = new Vector3(transform.position.x - PlayerScript.speedObstacle, transform.position.y , 0);

			if (transform.position.x <= -20f)
			{
				Destroy(gameObject);
			}
		}
	}
}
