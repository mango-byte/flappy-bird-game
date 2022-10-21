using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class PlayerScript : MonoBehaviour
{
	public static bool dead;
	public AudioClip[] auClip;
	public GameObject fire;

	public GameObject background;

	public Sprite deadSprite;


	public static float speedObstacle;

	void Start()
	{
		speedObstacle = 0.06f;
		dead = false;
		GetComponent<AudioSource>().clip = auClip[0];
	}

	void Update()
	{
		if (Input.GetMouseButtonDown(0) && !dead)
		{		
			RaycastHit2D hit = Physics2D.Raycast (Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
			
			if(hit.collider == null)
			{
				Jump();
			}
		}
	}

	void Jump()
	{
		GetComponent<Rigidbody2D>().gravityScale = 1;
		fire.SetActive (true);
		GetComponent<AudioSource>().clip = auClip[0];
		GetComponent<AudioSource>().Play();
		GetComponent<Rigidbody2D>().velocity = Vector2.zero;
		GetComponent<Rigidbody2D>().AddForce(Vector2.up * 220);
	}

	void OnTriggerEnter2D(Collider2D col) 
	{
		if (!dead)
		{
			if (col.tag == "Score")
			{
				GetComponent<AudioSource>().clip = auClip[2];
				GetComponent<AudioSource>().Play();

				GameObject.FindObjectOfType<GameManager>().Score++;
				Destroy(col.gameObject);

				if(GameManager.score == 10) // easy
				{
					background.GetComponent<SpriteRenderer>().color = new Color32(220,220,220,255);
					GameManager.speedClone = GameManager.speedClone - 0.3f; 
					speedObstacle = speedObstacle + 0.02f;
				}
				else if(GameManager.score == 20) // medium
				{
					background.GetComponent<SpriteRenderer>().color = new Color32(190,190,190,255);
					GameManager.speedClone = GameManager.speedClone - 0.3f;
					speedObstacle = speedObstacle + 0.02f;
				}
				else if(GameManager.score == 30) // hard
				{
					background.GetComponent<SpriteRenderer>().color = new Color32(160,160,160,255);
					GameManager.speedClone = GameManager.speedClone - 0.3f;
					speedObstacle = speedObstacle + 0.02f;
				}
				else if(GameManager.score == 40) // Extreme
				{
					background.GetComponent<SpriteRenderer>().color = new Color32(130,130,130,255);
					GameManager.speedClone = GameManager.speedClone - 0.3f;
					speedObstacle = speedObstacle + 0.02f;
				}
				else if(GameManager.score == 50) // Insane
				{
					background.GetComponent<SpriteRenderer>().color = new Color32(100,100,100,255);
					GameManager.speedClone = GameManager.speedClone - 0.3f;
					speedObstacle = speedObstacle + 0.02f;
				}

			}
			else if (col.tag == "Finish")
			{
				Debug.Log(col.name);
				dead = true;				
				GetComponent<AudioSource>().clip = auClip[1];
				GetComponent<AudioSource>().Play();
				Invoke("BackToMain", 1.5f);

				this.gameObject.GetComponent<Animator>().SetBool("isDead", true);
				this.gameObject.GetComponent<Transform>().rotation = Quaternion.Euler(0,0, -90);
			}
		}
	}

	void BackToMain()
	{      
		  SceneManager.LoadScene("MainMenu");
	}
}
