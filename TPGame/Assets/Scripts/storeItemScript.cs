using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class storeItemScript : MonoBehaviour
{

    private void OnCollisionEnter(Collision other) {
        if (other.gameObject.tag == "floor")
        {
            Destroy(gameObject);
        }
    }

}
