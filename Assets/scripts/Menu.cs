using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Menu : HUDScript
{
    [SerializeField]
    TextMeshProUGUI Whowon;
    
    // Start is called before the first frame update
    void Start()
    {
        
 
      if(PlayerScore == 0)
      {
            Whowon.text = "Enemy Win";
      }
      else if (EnemyScore == 0)
      {
            Whowon.text = "Player Win";
      }
    }


    public void onPlayEvent()
    {
        SceneManager.LoadScene(1);
    }
    public void onQuitEvent()
    {
        Application.Quit();
       // Debug.Log("Is quittng");
    }
}
