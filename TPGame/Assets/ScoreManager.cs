using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        gameManager.score = 0;
    }

    // Update is called once per frame
    void Update()
    {
        GetComponent<Text>().text = gameManager.score.ToString();
    }
}
