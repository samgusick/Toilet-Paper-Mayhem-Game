using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class highScores : MonoBehaviour
{
 const string privateCode = "0aSeey9IdkmEfeOxJxNYigH6_RBoj1y0-K7wJa65duWw";
 const string publicCode = "5ef0b368377eda0b6c5c39df";
 const string webURL = "http://dreamlo.com/lb/";

public GameObject contentObject;
 public static string masterScoreString;

    scoreAdder highscoresDisplay; 
public Highscore[] highscoresList;
    private void Awake() {
        
        highscoresDisplay = contentObject.GetComponent<scoreAdder>();
        downloadHighscore();
    }
    public void AddNewHighscore(string username, int score)
    {
        StartCoroutine(UploadNewHighScore(username, score)); 
    }

    IEnumerator UploadNewHighScore(string username, int score) {

    UnityWebRequest www = new UnityWebRequest(webURL + privateCode + "/add/"  + UnityWebRequest.EscapeURL(username) + "/" + score); 
    yield return www.SendWebRequest();

    if (string.IsNullOrEmpty(www.error))
    {
//        print("upload successful");

    }
    else
    {
  //      print("Error uploading: " + www.error);
    }

    }


    public void downloadHighscore()
    {
        StartCoroutine(DownloadHighscoresFromDatabase()); 
    }
    IEnumerator DownloadHighscoresFromDatabase()
    {
        UnityWebRequest www = new UnityWebRequest(webURL + publicCode + "/pipe/");
        www.downloadHandler = new DownloadHandlerBuffer();
        yield return www.SendWebRequest();


                if (string.IsNullOrEmpty(www.error))
    {
        FormatHighscores(www.downloadHandler.text);
    }
    else
    {
  //      print("Error downloading: " + www.error);
    }

    }

    void FormatHighscores(string textStream)
    {
        string[] entries = textStream.Split(new char[] {
            '\n'
        }, System.StringSplitOptions.RemoveEmptyEntries);
        highscoresList = new Highscore[entries.Length];
        masterScoreString = "";
        for (int i = 0; i < entries.Length; i++)
        {
            string[] entryInfo = entries[i].Split(new char[] {'|'});
            string username = entryInfo[0];
            int score = int.Parse(entryInfo[1]);
            masterScoreString += (score + " - " + username + "\n");
        }
    }
    
}


public struct Highscore {
    public string username;
    public int score;

    public Highscore(string _username, int _score)
    {
        username = _username;
        score = _score;
    }
}