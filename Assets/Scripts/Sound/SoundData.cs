using System.Collections.Generic;
using UnityEngine;

namespace Sound
{
    [CreateAssetMenu(fileName = "SoundData", menuName = "ScriptableObject/SoundData")]
    public class SoundData : ScriptableObject
    {
        [SerializeField] private List<SoundInfo> sounds;

        public Dictionary<SoundEnum.SoundName, SoundInfo> GetSoundDictionary()
        {
            var soundDictionary = new Dictionary<SoundEnum.SoundName, SoundInfo>();

            foreach (var sound in sounds)
            {
                if (sound == null)
                {
                    Debug.LogWarning("Null SoundInfo found in the list. Skipping...");
                    continue;
                }

                if (soundDictionary.TryAdd(sound.name, sound)) continue;
                
                Debug.LogWarning($"Duplicate SoundName detected: {sound.name}. Ignoring duplicate entry.");
            }

            return soundDictionary;
        }
    }
}
