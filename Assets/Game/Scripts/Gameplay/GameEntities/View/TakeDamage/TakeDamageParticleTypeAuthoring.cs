using Game.Gameplay.Effects;
using Unity.Entities;
using UnityEngine;

namespace Game.Gameplay.GameEntities.View
{
    public class TakeDamageParticleTypeAuthoring : MonoBehaviour
    {
        [field: SerializeField] public ParticleType Value { get; set; }
        
        private class TakeDamageParticleTypeAuthoringBaker : Baker<TakeDamageParticleTypeAuthoring>
        {
            public override void Bake(TakeDamageParticleTypeAuthoring authoring)
            {
                Entity entity = GetEntity(TransformUsageFlags.Dynamic);
                AddComponent(entity, new TakeDamageParticleType {Value = authoring.Value});
            }
        }
    }
}