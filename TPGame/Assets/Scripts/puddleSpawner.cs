using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class puddleSpawner : MonoBehaviour
{
    public GameObject puddle1;
    public GameObject puddle2;
    void Start()
    {
        for (int i = 2; i < 10; i++)
        {
            float randX = Random.Range(-20f, 30f);
            float randZ = Random.Range(-25f, 30f);
            if (i % 2 == 0)
            {
                Instantiate(puddle1, new Vector3(randX, -0.093f, randZ), Quaternion.identity);
            }

            else
            {
                Instantiate(puddle2, new Vector3(randX, -0.093f, randZ), Quaternion.identity);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
