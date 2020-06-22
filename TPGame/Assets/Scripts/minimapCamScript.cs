using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class minimapCamScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float xPos  = Mathf.Lerp(transform.position.x, GameObject.Find("Player").transform.position.x, 0.5f);
        float zPos  = Mathf.Lerp(transform.position.z, GameObject.Find("Player").transform.position.z, 0.5f);
    
    transform.position = new Vector3(xPos, 50f, zPos);
    }
}
