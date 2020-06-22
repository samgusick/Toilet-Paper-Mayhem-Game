using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class causeOfDeathScript : MonoBehaviour
{
    // Start is called before the first frame update
    public static TextMeshProUGUI deathText;
    void Start()
    {
      deathText = GetComponentInChildren<TextMeshProUGUI>();

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public static void outOfTP()
    {
        deathText.text = "You ran out of toilet paper :(";
    }

        public static void captured()
    {

        deathText.text = "A customer captured you :(";
    }
}
