using Game.Gameplay.Effects;
using Unity.Entities;
using UnityEngine;

namespace Game.Gameplay.GameEntities.View
{
    public class DieParticleTypeAuthoring : MonoBehaviour
    {
        [field: SerializeField] public ParticleType Value { get; set; }
        
        private class DestroyParticleTypeAuthoringBaker : Baker<DieParticleTypeAuthoring>
        {
            public override void Bake(DieParticleTypeAuthoring authoring)
            {
                Entity entity = GetEntity(TransformUsageFlags.Dynamic);
                AddComponent(entity, new DieParticleType() {Value = authoring.Value});
            }
        }
    }
}