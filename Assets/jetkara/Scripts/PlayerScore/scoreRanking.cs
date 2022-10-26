using UnityEngine;
using TMPro;

public class scoreRanking : MonoBehaviour
{
    public GameObject canvasHighScore;
    public GameObject bgRanking;

    public GameObject ranking;
    public GameObject [] Buttons;
   	void Awake ()
	{	

	}

	void OnMouseDown()
	{
        foreach(GameObject btn in Buttons)
        {
            btn.GetComponent<BoxCollider2D>().enabled = false;
        }
        canvasHighScore.SetActive(true);
        createHighscore();  
	}
    public void btnClose()
	{
        foreach(GameObject btn in Buttons)
        {
            btn.GetComponent<BoxCollider2D>().enabled = true;
        }
                
        for (var i = bgRanking.transform.childCount - 1; i >= 0; i--)
        {
            Object.Destroy(bgRanking.transform.GetChild(i).gameObject);
        }
	}
    // void OnMouseUp()
	// {
    //    canvasHighScore.SetActive(false);
    //    destroyRanking();
    // }	
    public void createHighscore()
    {
        for(int i = 0; i < 5; i++)
		{  
			if(PlayerPrefs.HasKey(i.ToString()))
			{
                //rowRanking.name = i.ToString();
                GameObject rowRanking = Instantiate(ranking) as GameObject;
                rowRanking.GetComponentInChildren<TextMeshProUGUI>().text = PlayerPrefs.GetInt(i.ToString()).ToString();
                rowRanking.transform.SetParent(bgRanking.transform, false);
			}
			else
			{
				return;
			}
		}
    }
}
