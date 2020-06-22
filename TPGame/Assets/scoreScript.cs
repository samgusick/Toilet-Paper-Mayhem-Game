using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class scoreScript : MonoBehaviour
{
    // Start is called before the first frame update
    TextMeshProUGUI scoreText;
    void Start()
    {
        scoreText = GetComponentInChildren<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = "Score: " + gameManager.score  + " Rolls";
    }
}
