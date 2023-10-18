using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class HUDScript : MonoBehaviour
{
    bool ispaused;
    protected static int PlayerScore =100 ,
    EnemyScore= 100; // made static becase if one instance is changed it is updated everywhere
    [SerializeField]
    TextMeshProUGUI scoreText , enemyScore;
    string  Playerscoreprefix = "Player HP :";
    string Enemyscoreprefix = "Enemy HP :";




    // Start is called before the first frame update
    void Start()
    {
        //attaching ball script
        ballScript ballscript = GameObject.FindWithTag("Ball").GetComponent<ballScript>();

       

        //adding listner tp player and evemy scores
        ballscript.addpointsAddedEventListner(Scorepoints);
        ballscript.addpointsAddedEventListnerEnemy(EnemyScorepoints);

        //setting up the up that displays
        scoreText.text = Playerscoreprefix + PlayerScore.ToString();
        enemyScore.text = Enemyscoreprefix + EnemyScore.ToString();
    }

    // Update is called once per frame
    void Update()
    {

        // scene management
        if (PlayerScore == 0 || EnemyScore == 0)
        {
            SceneManager.LoadScene(1);
        }
        if (Input.GetKeyDown(KeyCode.P))
        {
            PauseEvent();
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }

    //updating score
    public  void Scorepoints(int score)
    {
        PlayerScore += score;
        scoreText.text = Playerscoreprefix + PlayerScore.ToString();
    }
    public void EnemyScorepoints(int score)
    {
       // Score = EnemyScore;
        EnemyScore += score;
        enemyScore.text = Enemyscoreprefix + EnemyScore.ToString();
    }

    //pausing and unpausing the game
    public void PauseEvent()
    {
        if (!ispaused)
        {
            Time.timeScale = 0;
            ispaused = true;
        }
        else
        {
            Time.timeScale = 1;
            ispaused = false;
        }
        
    }
}
