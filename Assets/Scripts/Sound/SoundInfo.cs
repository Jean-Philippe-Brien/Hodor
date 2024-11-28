using System;
using UnityEngine;
using UnityEngine.Audio;

namespace Sound
{
    [Serializable]
    public struct SoundInfo
    {
        public SoundEnum.SoundName Name;
        [Range(0, 1)] public float volume;
        public AudioMixerGroup Mixer;
        public AudioClip AudioClip;
    }
}
 