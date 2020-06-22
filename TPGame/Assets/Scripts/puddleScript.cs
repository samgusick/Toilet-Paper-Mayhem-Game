using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class puddleScript : MonoBehaviour
{
    bool hasStarted;

    Quaternion rotation;
    // Start is called before the first frame update
    void Start()
    {
        hasStarted = false;
    }

    private void Awake() {
        rotation = Quaternion.Euler(0, Random.Range(0f,360f), 0);

        transform.rotation = rotation;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay(Collider other) {
        if (other.gameObject.tag == "Player" && !hasStarted)
        {
            StartCoroutine(WetspotStay());
            hasStarted = true;
        }
    }

    private void OnTriggerExit(Collider other) {
            if (other.gameObject.tag == "Player" && hasStarted)
        {
            hasStarted = false;
        }
    }

    IEnumerator WetspotStay()
    {
        while (true)
        {
            playerManager.health -= 15f;
            yield return new WaitForSeconds (1f);
            if (hasStarted == false)
            {
                yield break; 
            }
        }

    }
}
