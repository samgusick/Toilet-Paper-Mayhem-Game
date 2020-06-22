using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pickupSpawner : MonoBehaviour
{
    public GameObject firePickup;
    public GameObject speedPickup;

    public static int numberOfPickupsSpawned;
    public int localPickupNum;
    public int maxNumberOfPickups = 6;
    GameObject[] spawnPoints;
    // Start is called before the first frame update
    void Start()
    {
        localPickupNum = 0;
        numberOfPickupsSpawned = 0;
        spawnPoints = GameObject.FindGameObjectsWithTag("pickupSpawnPoint");
     StartCoroutine(SpawnTimer());   
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator SpawnTimer()
    {
        while (true)
        {
            yield return new WaitForSeconds(7f);

            int randIndex = Random.Range(0, spawnPoints.Length-1);

            if (numberOfPickupsSpawned < maxNumberOfPickups)
            {
                if (localPickupNum % 2 == 0)
                {
                Instantiate(firePickup, spawnPoints[randIndex].transform.position, Quaternion.identity);
                numberOfPickupsSpawned++;
                localPickupNum++;
                }

                else if (localPickupNum % 2 != 0)
                {
                Instantiate(speedPickup, spawnPoints[randIndex].transform.position, Quaternion.identity);
                numberOfPickupsSpawned++;
                localPickupNum++;
                }
            }
        }

    }
}
