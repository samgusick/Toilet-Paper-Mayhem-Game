using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class gameManager : MonoBehaviour
{
    public static int highScore = 0;
    
    public static string thisUser = "";
    public static int score;
    public GameObject foodItem;

    public GameObject startButton;
    public GameObject quitButton;
    public GameObject chooseUser;

    public highScores highScoresInstance;
    void Start()
    {
        Screen.fullScreen = true;
        Screen.fullScreenMode = FullScreenMode.ExclusiveFullScreen;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        
        score = 0;
        // for (int x = -33; x <= 33; x++)
        // {
        //     for (int y = 0; y <= 5; y++)
        //     {
        //         for (int z = -37; z <= 33; z++)
        //         {
        //             Instantiate<GameObject>(foodItem, new Vector3(x,y,z), Quaternion.identity);
        //         }
        //     }
        // }   
    }

    void Update()
    {



        if (score > highScore)
        {
            highScore = score;
            highScoresInstance.AddNewHighscore(gameManager.thisUser, score);
        }   
    }
}
