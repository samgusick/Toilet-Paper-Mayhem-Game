using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class getUsername : MonoBehaviour
{
    public static bool usernameChosen = false; 
    public TextMeshProUGUI userInputText;

    public GameObject mainStart;
    public GameObject mainQuit;

    public GameObject usernameUI;
    public GameObject leaderButton;
    // Start is called before the first frame update
    void Start()
    {
        if (!usernameChosen)
        {
            mainStart.SetActive(false);
            mainQuit.SetActive(false);
            usernameUI.SetActive(true);
            leaderButton.SetActive(false);
        }
        else
        {
            mainStart.SetActive(true);
            mainQuit.SetActive(true);
                        leaderButton.SetActive(true);
            usernameUI.SetActive(false);
        }    
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void FindUserString()
    {

        gameManager.thisUser = userInputText.text;
        mainStart.SetActive(true);
        mainQuit.SetActive(true);
        leaderButton.SetActive(true);
        usernameUI.SetActive(false);
        usernameChosen = true;

    }
}
