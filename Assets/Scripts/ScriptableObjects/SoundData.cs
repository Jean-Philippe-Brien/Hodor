using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

[CreateAssetMenu(fileName = "SoundData", menuName = "ScriptableObject/SoundData")]
public class SoundData : ScriptableObject
{
    public List<Sound> Sounds;

    public Dictionary<Enum.SoundName, Sound> GetSoundLists()
    {
        Dictionary<Enum.SoundName, Sound> soundsList = new Dictionary<Enum.SoundName, Sound>();
        
        foreach (var sound in Sounds)
        {
            soundsList.Add(sound.name, sound);
        }

        return soundsList;
    }
}

[Serializable]
public struct Sound
{
    public Enum.SoundName name;
    [Range(0, 1)] public float volume;
    public AudioMixerGroup mixer;
    public AudioClip sound;
}
