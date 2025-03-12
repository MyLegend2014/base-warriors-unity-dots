using Unity.Entities;
using UnityEngine;

namespace Game.Gameplay.GameEntities.Sounds
{
    public class TakeDamageSoundAuthoring : MonoBehaviour
    {
        [field: SerializeField] public SoundType Type { get; private set; }
        
        private class TakeDamageSoundAuthoringBaker : Baker<TakeDamageSoundAuthoring>
        {
            public override void Bake(TakeDamageSoundAuthoring authoring)
            {
                Entity entity = GetEntity(TransformUsageFlags.Dynamic);
                AddComponent(entity, new TakeDamageSound() { Type = authoring.Type});
            }
        }
    }
}