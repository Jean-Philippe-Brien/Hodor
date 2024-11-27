using System.Collections.Generic;
using Struct;
using UnityEngine;

namespace ScriptableObjects
{
    [CreateAssetMenu(fileName = "SoundData", menuName = "ScriptableObject/SoundData")]
    public class SoundData : ScriptableObject
    {
        [SerializeField] private List<Sound> sounds;

        public Dictionary<Enum.SoundName, Sound> GetSoundLists()
        {
            Dictionary<Enum.SoundName, Sound> soundsList = new Dictionary<Enum.SoundName, Sound>();
        
            foreach (var sound in sounds)
            {
                soundsList.Add(sound.Name, sound);
            }

            return soundsList;
        }
    }
}
