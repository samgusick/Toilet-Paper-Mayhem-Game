using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class scoreAdder : MonoBehaviour
{
    highScores highscoreManager;

    public GameObject highScoresObject;
    private void Start() {

        GetComponent<TextMeshProUGUI>().text = highScores.masterScoreString;
        highscoreManager = highScoresObject.GetComponent<highScores>();
        StartCoroutine(RefreshHighscores());

    }


    private void Update() {
        GetComponent<TextMeshProUGUI>().text = highScores.masterScoreString;
    }
    IEnumerator RefreshHighscores()
    {
        while(true)
        {
            highscoreManager.downloadHighscore();
            GetComponent<TextMeshProUGUI>().text = highScores.masterScoreString;
            yield return new WaitForSeconds(30f);
        }
    }
}


