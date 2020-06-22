using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class inGameButtonsAndMenus : MonoBehaviour
{
    public static bool paused;
    public GameObject playerUI;
    public GameObject pauseUI;

    public GameObject DeathUI;

    // Start is called before the first frame update
    void Start()
    {
        paused = false;
        DeathUI.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {


        if (Input.GetKeyDown(KeyCode.Escape) && !playerManager.isDead)
        {
            pauseMenu();

        }

                if (playerManager.isDead)
        {
            DeathUI.SetActive(true);
            playerUI.SetActive(false);
            pauseUI.SetActive(false);
            TutorialMessages.tutorialEnded = true;
            TutorialMessages.tutorialStep = 6;
            Cursor.lockState = CursorLockMode.Confined;
            Cursor.visible = true;
            Time.timeScale = 0.05f;
            Time.fixedDeltaTime = Time.timeScale * .02f;
        }   

        if (paused)
        {
            playerUI.SetActive(false);
            pauseUI.SetActive(true);
            Cursor.lockState = CursorLockMode.Confined;
            Cursor.visible = true;
            Time.timeScale = 0;

        }

        else if (!paused && !playerManager.isDead)
        {
            playerUI.SetActive(true);
            pauseUI.SetActive(false);
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
            Time.timeScale = 1;
        }
    }

    public void backToMenu()
    {
        SceneManager.LoadScene(0);
    }

        public void resumeButton()
    {
        pauseMenu();
    }

    public void pauseMenu()
    {
        paused =  !paused;
    }

    public void playAgain()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public string displayDeath(string causeOfDeath)
    {
        return causeOfDeath;
    }

}
