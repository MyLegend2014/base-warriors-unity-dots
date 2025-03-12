using Unity.Entities;
using UnityEngine;

namespace Game.Gameplay.GameEntities.Sounds
{
    public class DieSoundAuthoring : MonoBehaviour
    {
        [field: SerializeField] public SoundType Type { get; private set; }
        
        private class DieSoundAuthoringBaker : Baker<DieSoundAuthoring>
        {
            public override void Bake(DieSoundAuthoring authoring)
            {
                Entity entity = GetEntity(TransformUsageFlags.Dynamic);
                AddComponent(entity, new DieSound() { Type = authoring.Type});
            }
        }
    }
}