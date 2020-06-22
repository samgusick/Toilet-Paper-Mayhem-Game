using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonCommandsScript : MonoBehaviour
{
    public GameObject startButton;
    public GameObject QuitButton;

    public GameObject leaderButton;
    public GameObject leaderboardUI;
    // Start is called before the first frame update
    void Start()
    {
        leaderButton.SetActive(true);
                startButton.SetActive(true);
        QuitButton.SetActive(true);
        leaderboardUI.SetActive(false);

        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void startButtonPressed()
    {
        SceneManager.LoadScene(1);
    }

        public void QuitButtonPressed()
    {
        Application.Quit();
    }

    public void LeaderboardsPressed()
    {
        leaderButton.SetActive(false);
        startButton.SetActive(false);
        QuitButton.SetActive(false);
        leaderboardUI.SetActive(true);
    }

    public void backToMenu()
    {
        leaderButton.SetActive(true);
        startButton.SetActive(true);
        QuitButton.SetActive(true);
        leaderboardUI.SetActive(false);
    }
}