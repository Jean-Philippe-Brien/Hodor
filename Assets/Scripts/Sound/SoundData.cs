using System.Collections.Generic;
using UnityEngine;

namespace Sound
{
    [CreateAssetMenu(fileName = "SoundData", menuName = "ScriptableObject/SoundData")]
    public class SoundData : ScriptableObject
    {
        [SerializeField] private List<SoundInfo> sounds;

        public Dictionary<SoundEnum.SoundName, SoundInfo> GetSoundLists()
        {
            Dictionary<SoundEnum.SoundName, SoundInfo> soundsList = new Dictionary<SoundEnum.SoundName, SoundInfo>();
        
            foreach (var sound in sounds)
            {
                soundsList.Add(sound.Name, sound);
            }

            return soundsList;
        }
    }
}
