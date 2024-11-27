using System.Collections.Generic;
using Struct;
using UnityEngine;

namespace ScriptableObjects
{
    [CreateAssetMenu(fileName = "SoundData", menuName = "ScriptableObject/SoundData")]
    public class SoundData : ScriptableObject
    {
        [SerializeField] private List<SoundInfo> sounds;

        public Dictionary<Enum.SoundName, SoundInfo> GetSoundLists()
        {
            Dictionary<Enum.SoundName, SoundInfo> soundsList = new Dictionary<Enum.SoundName, SoundInfo>();
        
            foreach (var sound in sounds)
            {
                soundsList.Add(sound.Name, sound);
            }

            return soundsList;
        }
    }
}
