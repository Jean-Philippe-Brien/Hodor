using System;
using UnityEngine;
using UnityEngine.Audio;

namespace Struct
{
    [Serializable]
    public struct Sound
    {
        public Enum.SoundName name;
        [Range(0, 1)] public float volume;
        public AudioMixerGroup mixer;
        public AudioClip sound;
    }
}
    