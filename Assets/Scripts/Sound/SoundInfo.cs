using System;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.Serialization;

namespace Sound
{
    [Serializable]
    public struct SoundInfo
    {
        [FormerlySerializedAs("name")] public SoundEnum.SoundName Name;
        [Range(0, 1)] public float volume;
        [FormerlySerializedAs("mixer")] public AudioMixerGroup Mixer;
        [FormerlySerializedAs("sound")] public AudioClip AudioClip;
    }
}
 