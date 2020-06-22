using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boxExplainer : MonoBehaviour
{
    public GameObject explainerGroup;
    // Start is called before the first frame update
    void Start()
    {
        explainerGroup.SetActive(true);
        // StartCoroutine(WaitThenDissapear());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator WaitThenDissapear()
    {
        yield return new WaitForSeconds(30f);
        Destroy(explainerGroup);
    }
}
