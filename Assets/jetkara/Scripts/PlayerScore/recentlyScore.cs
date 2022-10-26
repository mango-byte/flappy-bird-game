using UnityEngine;
using TMPro;

public class recentlyScore : MonoBehaviour
{  public GameObject canvasRecentlyPlaying;
    public GameObject bgPlaying;

    public GameObject playing;

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
        //GetComponent<BoxCollider2D> ().enabled = false;
        canvasRecentlyPlaying.SetActive(true);
        createPlaying(); 	 
	}

    public void btnClose()
	{
        foreach(GameObject btn in Buttons)
        {
            btn.GetComponent<BoxCollider2D>().enabled = true;
        }
               
        for (var i = bgPlaying.transform.childCount - 1; i >= 0; i--)
        {
            Object.Destroy(bgPlaying.transform.GetChild(i).gameObject);
        }
	}
    
    // void OnMouseUp()
	// {
    //     if(!EventSystem.current.IsPointerOverGameObject())
    //     {
    //         canvasRecentlyPlaying.SetActive(false);
    //         destroyRecentlyPlaying();
    //     }  
    // }	
    public void createPlaying()
    {
        int i = 0;
        PlayerScript.recentlyPlay.Reverse();
        foreach(int play in PlayerScript.recentlyPlay)
        {
            if(i == 5)
            {
                return;
            }
            GameObject rowPlaying = Instantiate(playing) as GameObject; 
            rowPlaying.GetComponentInChildren<TextMeshProUGUI>().text = 
            PlayerScript.recentlyPlay[i].ToString();
            rowPlaying.transform.SetParent(bgPlaying.transform, false);
            i++;
        }
    }	
}
