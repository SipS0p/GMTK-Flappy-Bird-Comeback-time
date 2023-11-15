using System.Collections.Specialized;
using UnityEngine;
using UnityEngine.Audio;

[System.Serializable]
public class Sounds
{
    public string name;
    public AudioClip audioClip;

    [Range(0f, 1f)]
    public float volume;
    [Range(-3, 3)]
    public float pitch;

    [HideInInspector]
    public AudioSource audioSource;

    public bool loop;
}
