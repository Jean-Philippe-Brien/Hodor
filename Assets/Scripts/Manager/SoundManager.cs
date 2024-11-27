using System.Collections.Generic;
using ScriptableObjects;
using Struct;
using UnityEngine;

namespace Manager
{
    [RequireComponent(typeof(AudioSource))]
    public class SoundManager : MonoBehaviour
    {
        public static SoundManager Instance;

        private AudioSource audioSource;
        private Dictionary<Enum.SoundName, Sound> soundsList = new Dictionary<Enum.SoundName, Sound>();
    
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

        public void PlaySoundOneShot(Enum.SoundName soundName)
        {
            audioSource.PlayOneShot(soundsList[soundName].AudioClip);
        }
    }
}
