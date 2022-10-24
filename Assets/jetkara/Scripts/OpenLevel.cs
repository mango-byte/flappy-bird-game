using UnityEngine;
using UnityEngine.SceneManagement;

public class OpenLevel : MonoBehaviour 
{
	public string levelName;

	void OnMouseDown()
	{
		transform.localScale = new Vector3(0.5f,0.5f,0.5f);
	}
	
	void OnMouseUp()
	{
		transform.localScale = new Vector3(0.6f,0.6f,0.6f);
		SceneManager.LoadScene(levelName);
	}
}
