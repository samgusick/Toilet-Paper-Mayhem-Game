using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class fireMessageScript : MonoBehaviour
{
    Text fireMessage;

    // Start is called before the first frame update
    void Start()
    {
     fireMessage = GetComponent<Text>();   
    }

    // Update is called once per frame
    void Update()
    {
        if (GameObject.Find("Player").GetComponent<playerManager>().getActiveAbility() == "fire")
        {
            fireMessage.enabled = true;
        }

        else
        {
            fireMessage.enabled = false;
        }
    }
}
