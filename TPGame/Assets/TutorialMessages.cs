using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TutorialMessages : MonoBehaviour
{
    // Start is called before the first frame update
    public static int tutorialStep = 1;
    public static bool tutorialEnded = false;
    public static bool TPCollected = false;
    public Text tutorialMessage;
    void Start()
    {
        tutorialStep = 1;
        TPCollected = false;
        tutorialEnded = false;
    }

    // Update is called once per frame
    void Update()
    {
        switch (tutorialStep)
        {
            default: tutorialMessage.text = "";
            break;

            case (1):
            tutorialMessage.text = "Mouse to Look";
            break;

            case (2):
            tutorialMessage.text = "Space to Jump";
            break;

            case (3):
            tutorialMessage.text = "W A S D to Move";
            break;

            case (4):
            tutorialMessage.text = "Collect TP to Stay alive + up your Score";
            break; 

            case(5):
            if (!tutorialEnded)
            {
            StartCoroutine(FinalMessages());
            tutorialEnded = true;
            }
            break;

            case(6):
            tutorialMessage.text = "";
            break;

        }
    if (tutorialStep == 1 && (Input.GetAxis("Mouse X")>0 || Input.GetAxis("Mouse X")<0))
    {
        tutorialStep++;
    }

    if (tutorialStep == 2 && Input.GetKeyDown(KeyCode.Space))
    {
        tutorialStep++;   
    }

        if (tutorialStep == 3 && (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.A)  || Input.GetKeyDown(KeyCode.D)))
    {
        tutorialStep++;   
    }

        if (TPCollected)
    {
        tutorialStep = 5;   
    }


    }

    IEnumerator FinalMessages()
    {

        tutorialMessage.text = "Don't let the customers grab you & stay out of puddles";
        yield return new WaitForSeconds(5f);
        tutorialMessage.text = "Survive as long as possible. Good Luck!";
        yield return new WaitForSeconds(5f);
        tutorialStep++;
        yield break;
    }
}
