using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour
{
	//public static GameManager obj = new GameManager();
	public static float speedClone;
	public GameObject objects;
	public GameObject GroundMove;

	public TextMesh scoreLabel;
	public static int score;
	public int Score
	{
		set
		{
			score = value;

			scoreLabel.text = Score.ToString();
		}
		get
		{
			return score;
		}
	}

	void Start() 
	{
		score = 0;
		speedClone = 2.3f;
		StartCoroutine(CreateObstacle());
	}


	IEnumerator CreateObstacle()
	{
		while(true)
		{
			Instantiate(objects, new Vector3(7.5f, Random.Range(-2f, 2.1f) , 0) , Quaternion.identity);
			Instantiate(GroundMove, new Vector3(15f, -5.6f , 0) , Quaternion.identity);
			yield return new WaitForSeconds(speedClone) ;
		}
	}
}
