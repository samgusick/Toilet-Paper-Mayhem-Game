using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class playerInfoScript : MonoBehaviour
{
    // Start is called before the first frame update
    public TextMeshProUGUI text;
    void Start()
    {
        text = GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        text.text = "User: " + gameManager.thisUser + "\n" + "Highscore: " + gameManager.highScore;
    }
}
