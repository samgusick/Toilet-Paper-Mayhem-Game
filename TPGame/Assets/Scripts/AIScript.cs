using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AIScript : MonoBehaviour
{
    Transform target;
    NavMeshAgent agent; 

    private bool enemyDead;
    // Start is called before the first frame update
    GameObject Head;
    GameObject shirt;
    GameObject pants;

    playerManager playerAccess;

    private void Awake() {
        enemyDead = false;
        StartCoroutine(DeathTime());
        playerAccess = GameObject.Find("Player").GetComponent<playerManager>();
        
    }

    public bool getEnemyDeathState()
    {
        return enemyDead;
    }
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        target = playerManager.Instance.player.transform;
        
    }

    // Update is called once per frame
    void Update()
    {
        if (playerAccess.ActiveAbility == "speed")
        {
            agent.speed = 1f;
        }

        else
        {
            agent.speed = 5f;
        }
    }

    private void FixedUpdate() {
        if (!enemyDead && !playerManager.isDead && agent.enabled == true)
        {
                    if (playerAccess.getActiveAbility() == "fire")
                    {
                        Vector3 dirToPlayer = transform.position - target.transform.position;

                        Vector3 newPos = transform.position + dirToPlayer;

                        agent.SetDestination(newPos);
                    }

                    else
                    {
                        agent.SetDestination(target.position);
                    }
                    
        }

        if (playerManager.isDead)
        {
            agent.enabled = false;
        }

    }

    private void OnCollisionEnter(Collision other) {
        if (other.gameObject.tag == "Player" && !enemyDead && playerAccess.getActiveAbility() == "none")
    {
        playerAccess.playerDead();
    }

    }

    public void setHitOnHead()
    {
        enemyDead = true;
 
    }

    IEnumerator DeathTime()
    {
        while (true)
        {
            if (enemyDead)
            {
                gameManager.score++;
                yield return new WaitForSeconds(5f);
                Destroy(this.gameObject);
            }
            else
            {
            yield return null;
            }
        }

    }
}
