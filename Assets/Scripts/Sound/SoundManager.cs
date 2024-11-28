using System.Collections.Generic;
using UnityEngine;

namespace Sound
{
    [RequireComponent(typeof(AudioSource))]
    public class SoundManager : MonoBehaviour
    {
        public static SoundManager Instance;

        private AudioSource audioSource;
        private Dictionary<SoundEnum.SoundName, SoundInfo> soundsList = new Dictionary<SoundEnum.SoundName, SoundInfo>();
    
        private void Awake()
        {
            if (Instance != null)
            {
                Debug.LogError($"{Instance.gameObject.name} conflict with: {gameObject.name} Managers Cannot be duplicated");
            }

            Instance = this;
            audioSource = GetComponent<AudioSource>();
            soundsList = Resources.Load<SoundData>("ScriptableObject/SoundData").GetSoundLists();
        }

        public void PlaySoundOneShot(SoundEnum.SoundName soundName)
        {
            audioSource.PlayOneShot(soundsList[soundName].AudioClip);
        }
    }
}
