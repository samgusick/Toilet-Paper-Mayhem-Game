using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pickupBasicFuncitons : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision other) {
        if (other.gameObject.tag == "Player" && !playerManager.isDead)
        {
                    StartCoroutine(MiniDeathTimer());
        }
    }

    IEnumerator MiniDeathTimer()
    {
        TutorialMessages.TPCollected = true;
        yield return new WaitForSeconds(.2f);
        pickupSpawner.numberOfPickupsSpawned--;
        Destroy(this.gameObject);
    }
}
