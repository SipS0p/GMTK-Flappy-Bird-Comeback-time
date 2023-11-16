using System;
using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{

    public Sounds[] sounds;
    // Start is called before the first frame update
    void Awake()
    {
        GameObject player = GameObject.Find("Player");        
        PlayerScript playerScript = player.GetComponent<PlayerScript>();
        playerScript.OnSpacePressed += PlayerScript_OnSpacePressed;
        playerScript.OnSuccess += PlayerScript_OnSuccess;


        foreach (Sounds s in sounds)
        {
            s.audioSource = gameObject.AddComponent<AudioSource>();
            s.audioSource.clip = s.audioClip;
            s.audioSource.volume = s.volume;
            s.audioSource.pitch = s.pitch;
            s.audioSource.loop = s.loop;
        }
    } 

    void Start()
    {        
        Play("BirdFlap");
    }

    void PlayerScript_OnSpacePressed(object sender, EventArgs e)
    {
        Play("BirdFlap");
    }

    void PlayerScript_OnSuccess (object sender, EventArgs e)
    {
        Debug.Log("OnSuccess activted in AudioManager");
        Play("Success");
    }
    public void Play (string name)
    {
        Sounds s = Array.Find(sounds, sound => sound.name == name);
        if (s == null) 
        {
            Debug.LogWarning("Sound: " + name + " is null. Check the spelling!");
        }
        else 
        { 
            s.audioSource.Play(); 
        }  
    } 
}
