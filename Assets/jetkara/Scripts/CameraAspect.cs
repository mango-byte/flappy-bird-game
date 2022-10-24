using UnityEngine;


public class CameraAspect : MonoBehaviour 
{
	public GameObject[] gm;

	
	void Start ()
	{
		Camera.main.aspect = 9/16f;
		Screen.sleepTimeout = SleepTimeout.NeverSleep;
		Time.timeScale = 1;
	}

	

	void LateUpdate()
	{
		if (Input.GetKeyDown(KeyCode.Escape))
		{
			Application.Quit();
		}
	}
}
