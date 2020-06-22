using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnManager : MonoBehaviour
{
    public GameObject enemeyAI;
    public GameObject spawn1;
    public GameObject spawn2;

    public float spawnRate = 4f;

    public float maxEnemies;
    public static float enemyCount;
    public float enemyCountCopy;

    // Start is called before the first frame update
    void Start()
    {
        enemyCount = 0;


                StartCoroutine(SpawnTimer());
            StopCoroutine(SpawnTimer());
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        enemyCountCopy = enemyCount;
    }

    IEnumerator SpawnTimer()
    {


        while(true) {

        yield return new WaitForSeconds(spawnRate);

        if (TutorialMessages.tutorialEnded == true)
        {
        float randSpawn = Random.value;
        GameObject spawnPoint;

        if (randSpawn >= .5f)
        {
            spawnPoint = spawn1;
        }
        else{
            spawnPoint = spawn2;
        }
        
        if (enemyCount < maxEnemies)
        {
            Instantiate(enemeyAI, spawnPoint.transform.position, Quaternion.identity);
            enemyCount++;
            yield return null;
        }

        if (enemyCount == maxEnemies && maxEnemies < 10)
        {
            yield return new WaitForSeconds(6f);
            maxEnemies++;
        }
        }

        }

    }
}
