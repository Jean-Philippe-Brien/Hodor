using System.Collections.Generic;
using GameCore;
using UnityEngine;

namespace Sound
{
    [RequireComponent(typeof(AudioSource))]
    public class SoundManager : BaseManager<SoundManager>
    {
        private AudioSource _audioSource;
        private Dictionary<SoundEnum.SoundName, SoundInfo> _soundsList = new Dictionary<SoundEnum.SoundName, SoundInfo>();
    
        protected override void Awake()
        {
            base.Awake();
            
            _audioSource = GetComponent<AudioSource>();
            _soundsList = Resources.Load<SoundData>("ScriptableObject/SoundData").GetSoundDictionary();
        }

        public void PlaySoundOneShot(SoundEnum.SoundName soundName)
        {
            _audioSource.PlayOneShot(_soundsList[soundName].audioClip);
        }
    }
}
