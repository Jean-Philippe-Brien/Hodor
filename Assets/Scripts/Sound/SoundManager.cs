using System.Collections.Generic;
using GameCore;
using UnityEngine;

namespace Sound
{
    [RequireComponent(typeof(AudioSource))]
    public class SoundManager : BaseManager<SoundManager>
    {
        [SerializeField] private SoundData soundData;
        
        private AudioSource _audioSource;
        private Dictionary<SoundEnum.SoundName, SoundInfo> _soundsList;
    
        protected override void Awake()
        {
            base.Awake();
            
            _audioSource = GetComponent<AudioSource>();
            if(soundData != null)
                _soundsList = soundData.GetSoundDictionary();
            else
                Debug.LogError("No SoundData Found in Sound Manager");
        }

        public void PlaySoundOneShot(SoundEnum.SoundName soundName)
        {
            _audioSource.PlayOneShot(_soundsList[soundName].audioClip);
        }
    }
}
