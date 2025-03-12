using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Game.Gameplay.GameEntities.Sounds
{
    [CreateAssetMenu(fileName = "SoundLibraryConfig", menuName = "Game/SoundLibraryConfig", order = 0)]
    public sealed class SoundLibraryConfig : ScriptableObject
    {
        [field: SerializeField] public List<GameAudio> Audios { get; private set; }

        public bool IsExistsAudio(SoundType type, out AudioClip clip)
        {
            clip = Audios.Where(x => x.Type == type).Select(x => x.Clip).FirstOrDefault();

            return clip != null;
        }
    }

    [Serializable]
    public class GameAudio
    {
        [field: SerializeField] public SoundType Type { get; private set; }
        
        [field: SerializeField] public AudioClip Clip { get; private set; }
    }
}