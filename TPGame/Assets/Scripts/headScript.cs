using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class headScript : MonoBehaviour
{
        private float randVal;
    private void Awake() {

        randVal = Random.value;
        if (randVal >= .5f)
                        {
                        GetComponent<Renderer>().material.color = new Color(190f/255f, 114f/255f, 60f/255f); 
                        }
                        else
                        {
                        GetComponent<Renderer>().material.color = new Color(229f/255f, 184f/255f, 135f/255f); 
                        }

    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

}
