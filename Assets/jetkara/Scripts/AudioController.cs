using UnityEngine;

public class AudioController : MonoBehaviour
{
	public Sprite on;
	public Sprite off;
	
	SpriteRenderer sp;
	
	void Awake ()
	{
		sp = GetComponent<SpriteRenderer>();
		
		if (PlayerPrefs.GetInt("Mute",0) == 1)
		{
			AudioListener.volume = 0;
			sp.sprite = off;
		}
		else
		{
			AudioListener.volume = 1;
			sp.sprite = on;
		}
	}
	
	void OnMouseDown()
	{
		transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
	}
	
	void OnMouseUp()
	{
		transform.localScale = new Vector3(0.6f, 0.6f, 0.6f);
			
			if (PlayerPrefs.GetInt("Mute",0) == 0)
			{
				AudioListener.volume = 0;
				PlayerPrefs.SetInt("Mute",1);
				sp.sprite = off;
			}
			else
			{
				AudioListener.volume = 1;
				PlayerPrefs.SetInt("Mute",0);
				sp.sprite = on;
			}		
			PlayerPrefs.Save();
	}
}
