using Unity.Entities;
using UnityEngine;

namespace Game.Gameplay.GameEntities.Sounds
{
    public class AttackSoundAuthoring : MonoBehaviour
    {
        [field: SerializeField] public SoundType Type { get; private set; }
        
        private class AttackSoundAuthoringBaker : Baker<AttackSoundAuthoring>
        {
            public override void Bake(AttackSoundAuthoring authoring)
            {
                Entity entity = GetEntity(TransformUsageFlags.Dynamic);
                AddComponent(entity, new AttackSound() { Type = authoring.Type});
            }
        }
    }
}