using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class healthManager : MonoBehaviour
{

    // Start is called before the first frame update
    public Slider healthBar;
    public string activeAbility;
    playerManager playerAccess;

    public Slider sliderCursor;

    public Image sliderIcon;

    public Image backgroundFill;
    public Image normalFill;

    public Image placeHolderTP;
    void Start()
    {
        healthBar = GetComponent<Slider>();
        playerAccess = GameObject.Find("Player").GetComponent<playerManager>();
    }

    // Update is called once per frame
    void Update()
    {
        playerManager.health = Mathf.Clamp(playerManager.health, 0f, 100f);
        activeAbility = GameObject.Find("Player").GetComponent<playerManager>().getActiveAbility();
        if (activeAbility == "fire")
        {
            playerManager.health = 100f;
            healthBar.value = playerAccess.sharedTimer/playerAccess.FireAbilityLength;
            placeHolderTP.enabled = true;
            sliderIcon.color = Color.red;
            normalFill.color = Color.red;
            backgroundFill.color = Color.white;

        }

        else if(activeAbility == "speed")
        {
            playerManager.health = 100f;
            healthBar.value = playerAccess.sharedTimer/playerAccess.SpeedAbilityLength;
            placeHolderTP.enabled = true;
            sliderIcon.color = Color.blue;
            normalFill.color = Color.blue;
            backgroundFill.color = Color.white;
        }

        else
        {
            healthBar.value = playerManager.health/100f;
            placeHolderTP.enabled = false;
            sliderIcon.color = Color.white;
            normalFill.color = Color.white;
            backgroundFill.color = Color.grey;
        }
    }
}
