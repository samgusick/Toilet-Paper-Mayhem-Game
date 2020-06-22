using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using Invector.vCharacterController;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;
 

public class playerManager : MonoBehaviour
{
    public float FireAbilityLength = 10f;
    public float SpeedAbilityLength = 10f;
    
    public Volume volume;
    public float sharedTimer;

    public float healthDegrationSpeed = 6f;
    public bool timerStarted;
    public static float health;

    public static bool isDead;
    public GameObject FireTrail;
    public new Rigidbody rigidbody;
    public GameObject player;
    public int normalSpeed = 10;
    public int doubleSpeed = 15;
    public GameObject playerTrail;

    public Material playerMaterial;

    public string ActiveAbility;
    public static playerManager Instance;

    private void Awake() {
        Instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        isDead = false;
        timerStarted = false;
        FireTrail.SetActive(false);
        playerMaterial = player.GetComponent<Renderer>().material;
        playerMaterial.SetColor("Color_93DE4B8", Color.white);
        rigidbody = GameObject.Find("Player").GetComponent<Rigidbody>();
        playerTrail = GameObject.Find("trail");
        health = 100f;
        playerMaterial.SetColor("Color_D91C126E", new Color(0.8018868f, 0.8018868f, 0.8018868f));
        ActiveAbility = "none";
        playerTrail.SetActive(true);
        playerTrail.GetComponent<TrailRenderer>().material.SetColor("Color_93DE4B8", Color.white);
    }

    // Update is called once per frame
    void Update()
    {
        if (ActiveAbility == "none")
        {
            setNormalPP();
        }

        else if (ActiveAbility == "fire")
        {
            setFirePP();
        }

        else if (ActiveAbility == "speed")
        {
            setSpeedPP();
        }


        if (rigidbody.velocity.magnitude > 0.5 || rigidbody.velocity.magnitude < -0.5)
        {
            health -=  healthDegrationSpeed * Time.deltaTime;
        }

        if (health <= 0)
        {
            playerMaterial.SetColor("Color_93DE4B8", new Color(165/255f, 136f/255f, 85f/255f));
            playerDead();
        }
    }

    private void OnCollisionEnter(Collision other) {
        if (other.gameObject.tag == "enemy" && ActiveAbility == "fire")
        {
            other.gameObject.GetComponent<NavMeshAgent>().enabled = false;
            other.gameObject.GetComponent<Rigidbody>().isKinematic = false;
            other.gameObject.GetComponent<AIScript>().setHitOnHead();
            
        }

        if (other.gameObject.tag == "enemy" && ActiveAbility == "none" && !other.gameObject.GetComponent<AIScript>().getEnemyDeathState())
        {
            playerDead();
        }


        if (other.gameObject.tag == "fire")
        {
            timerStarted = false;

            setActiveAbility("fire");
        }

        else if (other.gameObject.tag == "speed")
        {
                        timerStarted = false;
            setActiveAbility("speed");
        }

    }

    #region  abilityHandler
    public void setActiveAbility(string abilityName)
    {
        if (!isDead)
        {
            ActiveAbility = abilityName;
        }

        else
        {
            ActiveAbility = "none";
        }

    }


    public string getActiveAbility()
    {
        return ActiveAbility;
    }

    private void FixedUpdate() {
        if (ActiveAbility == "fire")
        {

        GetComponent<vThirdPersonController>().moveSpeed = normalSpeed;
         GetComponent<vThirdPersonController>().airSpeed = normalSpeed;
        playerMaterial.SetColor("Color_93DE4B8", Color.red);

        playerTrail.GetComponent<TrailRenderer>().emitting = false;
        // TOGGLE TRAIL GENERATION
        FireTrail.SetActive(true);
         playerTrail.GetComponent<TrailRenderer>().material.SetColor("Color_93DE4B8", Color.white);
        if (!timerStarted)
                    {
                                                timerStarted = true;
                                    StartCoroutine(FireAbilityTimer());
                    }
        }

        else if (ActiveAbility == "speed")
        {


                    playerMaterial.SetColor("Color_93DE4B8", Color.blue);
                    playerTrail.GetComponent<TrailRenderer>().emitting = true;
                    // TOGGLE TRAIL GENERATION
                    FireTrail.SetActive(false);
                    playerTrail.GetComponent<TrailRenderer>().material.SetColor("Color_93DE4B8", Color.blue);
                    GetComponent<vThirdPersonController>().moveSpeed = doubleSpeed;
                    GetComponent<vThirdPersonController>().airSpeed = doubleSpeed;
                                        if (!timerStarted)
                    {
                                                timerStarted = true;
                                    StartCoroutine(SpeedAbilityTimer());
                    }

        }

        else // no ability
        {
            GetComponent<vThirdPersonController>().moveSpeed = normalSpeed;
            GetComponent<vThirdPersonController>().airSpeed = normalSpeed;
                    playerMaterial.SetColor("Color_93DE4B8", Color.white);
                    playerTrail.GetComponent<TrailRenderer>().emitting = true;
                    // TOGGLE TRAIL GENERATION
                    FireTrail.SetActive(false);
                    playerTrail.GetComponent<TrailRenderer>().material.SetColor("Color_93DE4B8", Color.white);
        }
    }

    IEnumerator FireAbilityTimer()
    {
        for (float timer = FireAbilityLength; timer >= 0; timer -= Time.deltaTime)
        {
            sharedTimer = timer;
            if (!timerStarted)
            {
                yield break;
            }
            yield return null;
        } 

                setActiveAbility("none");
                yield break;
    }

        IEnumerator SpeedAbilityTimer()
    {
        for (float timer = SpeedAbilityLength; timer >= 0; timer -= Time.deltaTime)
        {
            sharedTimer = timer;
            if (!timerStarted)
            {
                yield break;
            }
            yield return null;
        } 

        setActiveAbility("none");
        yield break;
    }
    
    

    #endregion

    #region deathHandler
    public void playerDead()
    {
        isDead = true;
        playerMaterial.SetColor("Color_D91C126E", Color.black);
        playerTrail.GetComponent<TrailRenderer>().emitting = false;
        if (health <= 0)
        {
            causeOfDeathScript.outOfTP();
        }
        else
        {
            causeOfDeathScript.captured();
        }
    

        GetComponent<vThirdPersonInput>().enabled = false;
        Cursor.lockState = CursorLockMode.Confined;
    }
    #endregion

    #region  postProcessingEffects
    public void setFirePP()
    {
        WhiteBalance whiteBalance;
        ColorAdjustments colorAdjustments;
        Vignette vignette;
        if (
            volume.profile.TryGet<WhiteBalance>(out whiteBalance)
        && volume.profile.TryGet<ColorAdjustments>(out colorAdjustments)
        && volume.profile.TryGet<Vignette>(out vignette)
        )
        {
            whiteBalance.temperature.value = 100;
            colorAdjustments.contrast.value = 100;
            colorAdjustments.colorFilter.value = new Color(0.9058824f, 0.4039216f, 0.4039216f);
            colorAdjustments.saturation.value = 0;
            vignette.intensity.value = .4f;
        }
    }


    public void setNormalPP()
    {
        WhiteBalance whiteBalance;
        ColorAdjustments colorAdjustments;
        Vignette vignette;
        if (
            volume.profile.TryGet<WhiteBalance>(out whiteBalance)
        && volume.profile.TryGet<ColorAdjustments>(out colorAdjustments)
        && volume.profile.TryGet<Vignette>(out vignette)
        )
        {
            whiteBalance.temperature.value = -30;
            colorAdjustments.contrast.value = 0f;
            colorAdjustments.colorFilter.value = Color.white;
            colorAdjustments.saturation.value = 100;
            vignette.intensity.value = .18f;
        }
    }

    public void setSpeedPP()
    {
        WhiteBalance whiteBalance;
        ColorAdjustments colorAdjustments;
        Vignette vignette;
        
        if (
            volume.profile.TryGet<WhiteBalance>(out whiteBalance)
        && volume.profile.TryGet<ColorAdjustments>(out colorAdjustments)
        && volume.profile.TryGet<Vignette>(out vignette)
        )
        {
            whiteBalance.temperature.value = -100f;
            colorAdjustments.contrast.value = 100f;
            colorAdjustments.colorFilter.value = Color.white;
            colorAdjustments.saturation.value = 0;
            vignette.intensity.value = .18f;

        }
    }

    #endregion
}
