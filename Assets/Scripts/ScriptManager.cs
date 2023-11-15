using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptManager : MonoBehaviour
{
    private int ScriptsDown;
    //16 scripts are managed here
    [SerializeField] AudioManager audioManager;
    [SerializeField] CanvasScript canvasScript;
    [SerializeField] CloudSpawner cloudSpawner;
    [SerializeField] DeathEngine deathEngine;
    [SerializeField] GroundSpawner groundSpawner;
    [SerializeField] LeftMovementScript leftMovementScript;
    [SerializeField] PlayerScript playerScript;
    [SerializeField] ScriptManager scriptManager;
    [SerializeField] Sounds sounds;
    [SerializeField] Spawner spawner;
    [SerializeField] SpeedUp speedUp;
    [SerializeField] SpeedUpClouds speedUpClouds;
    [SerializeField] StartMessageScript startMessageScript;
    [SerializeField] StartScript startScript;
    [SerializeField] CLoudMovement cloudMovement;
    
    private MonoBehaviour[] monoScripts;  


    void Awake () 
    {
        monoScripts = new MonoBehaviour[]
        {
            cloudSpawner,
            groundSpawner,
            leftMovementScript,
            playerScript,
            spawner,
            speedUp,
            speedUpClouds,
            cloudMovement,
            //Cut of - below this line the scripts wont shut down on player death
            startMessageScript,
            startScript,
            audioManager,
            canvasScript,
            scriptManager,
            deathEngine,
        };
    }
    private void Start()
    {
        ScriptsDown = 0;
    }
    void PlayerScript_OnPlayerDeath(object sender, EventArgs e)
    {
        Debug.Log("On player edeath activated");
        foreach (MonoBehaviour Script in monoScripts)
        {
            if (ScriptsDown >= 7)
            {
                enabled = false;
                ScriptsDown++;
            }
        }
    }
    
}
