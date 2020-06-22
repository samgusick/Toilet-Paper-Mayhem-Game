using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RollModelSettings : MonoBehaviour
{
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate() {
        float health = playerManager.health;
        transform.localScale = new Vector3(1f, .3f + health/100f, .3f + health/100f);
    }
}
