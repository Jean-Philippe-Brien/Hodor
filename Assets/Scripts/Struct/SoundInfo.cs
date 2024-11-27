using System;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.Serialization;

namespace Struct
{
    [Serializable]
    public struct SoundInfo
    {
        [FormerlySerializedAs("name")] public Enum.SoundName Name;
        [Range(0, 1)] public float volume;
        [FormerlySerializedAs("mixer")] public AudioMixerGroup Mixer;
        [FormerlySerializedAs("sound")] public AudioClip AudioClip;
    }
}
 