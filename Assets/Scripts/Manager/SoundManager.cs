using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

[RequireComponent(typeof(AudioSource))]
public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance;

    private AudioSource audioSource;
    private Dictionary<Enum.SoundName, Sound> soundLists = new Dictionary<Enum.SoundName, Sound>();
    
    private void Awake()
    {
        if (Instance != null)
        {
            Debug.LogError(Instance.gameObject.name + " conflict with:\n" + gameObject.name + " Managers Cannot be duplicated");
        }

        Instance = this;
        audioSource = GetComponent<AudioSource>();
        soundLists = Resources.Load<SoundData>("ScriptableObject/Sounds/SoundData").GetSoundLists();
        foreach (var VARIABLE in soundLists)
        {
            Debug.Log(VARIABLE.Key);
        }
    }

    public void PlaySoundOneShot(Enum.SoundName soundName)
    {
        audioSource.PlayOneShot(soundLists[soundName].sound);
    }
}
