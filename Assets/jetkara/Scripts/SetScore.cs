using System.Net.Sockets;
using UnityEngine;
using System.Collections.Generic;
using System.Linq;


public class SetScore : MonoBehaviour 
{
	//public static int[] rankHighScore;
	public TextMesh bestScoreLabel;
	public TextMesh scoreLabel;

	void Start () 
	{
		scoreLabel.text = "Score: " + GameManager.score.ToString();

		if (PlayerPrefs.HasKey("0"))
		{
		  	bestScoreLabel.text = "HighScore: " + PlayerPrefs.GetInt("0", 0).ToString();
		}
		else
		{
			bestScoreLabel.text = "HighScore: " + "0";
		}
	}
}