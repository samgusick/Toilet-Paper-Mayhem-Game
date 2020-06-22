using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TPParticleManager : MonoBehaviour
{
    public ParticleSystem RollParticles;
    public List<ParticleCollisionEvent> collisionList;
    public GameObject player;

    private void Start() {
        player = GameObject.Find("Player");
        collisionList = new List<ParticleCollisionEvent>();
    }


void OnParticleTrigger()
    {

        // particles
        List<ParticleSystem.Particle> enter = new List<ParticleSystem.Particle>();
        List<ParticleSystem.Particle> exit = new List<ParticleSystem.Particle>();

        // get
        int numEnter = RollParticles.GetTriggerParticles(ParticleSystemTriggerEventType.Enter, enter);
        int numExit = RollParticles.GetTriggerParticles(ParticleSystemTriggerEventType.Exit, exit);
        
            // foreach (var item in enter)
            // {
            //     print(item);
            // }


            

            List<ParticleSystem.Particle> placeholderList = new List<ParticleSystem.Particle>();
            placeholderList.Clear();

            foreach (var item in enter)
            {
                if (!playerManager.isDead)
                {
                TutorialMessages.TPCollected =  true;
                playerManager.health += 15f;
                gameManager.score++;
                int particleNum = enter.IndexOf(item);
                ParticleSystem.Particle singlePart = enter[particleNum];
                singlePart.remainingLifetime = 0;
                placeholderList.Add(singlePart);
                }
            }

            

            RollParticles.SetTriggerParticles(ParticleSystemTriggerEventType.Enter, placeholderList);
    }
}
