using UnityEngine;


public class ObjectMove : MonoBehaviour 
{
	 // start speed
	void FixedUpdate () 
	{
		
		if (PlayerScript.dead)
		{
			return;
		}
		else{
			
			transform.position = new Vector3(transform.position.x - PlayerScript.speedObstacle, transform.position.y , 0);

			if (transform.position.x <= -7.5f)
			{
				Destroy(gameObject);
			}
		}
	}
}
