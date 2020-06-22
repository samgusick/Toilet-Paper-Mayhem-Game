using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shirtScript : MonoBehaviour
{
    private Renderer[] shirtComponenets = new Renderer[2];
    // Start is called before the first frame update
    private void Awake() {
        shirtComponenets = GetComponentsInChildren<Renderer>();
          Color background = new Color(
      Random.Range(0f, 1f), 
      Random.Range(0f, 1f), 
      Random.Range(0f, 1f)
  );

        GetComponent<Renderer>().material.color = background;  
        foreach (var item in shirtComponenets)
        {
            item.material.color = background;
        }
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
