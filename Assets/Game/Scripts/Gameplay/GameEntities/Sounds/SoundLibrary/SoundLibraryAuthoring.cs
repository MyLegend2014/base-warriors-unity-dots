using Sirenix.OdinInspector;
using Unity.Entities;
using UnityEngine;

namespace Game.Gameplay.GameEntities.Sounds
{
    public class SoundLibraryAuthoring : MonoBehaviour
    {
        [field: SerializeField, Required] public SoundLibraryConfig SoundLibraryConfig { get; private set; }
        
        private class AudioLibraryAuthoringBaker : Baker<SoundLibraryAuthoring>
        {
            public override void Bake(SoundLibraryAuthoring authoring)
            {
                GetEntity(TransformUsageFlags.Dynamic);
                AddComponentObject(new SoundLibrary() { Value = authoring.SoundLibraryConfig });
            }
        }
    }
}