using Unity.Entities;
using Unity.Entities.UI;
using UnityEngine;

namespace Game.Gameplay.GameEntities.Common
{
    public class InstantAtackerAuthoring : MonoBehaviour
    {
        [field: SerializeField, MinValue(0)] public float AttackCooldown = 1f;
        
        private class InstantAtackerAuthoringBaker : Baker<InstantAtackerAuthoring>
        {
            public override void Bake(InstantAtackerAuthoring authoring)
            {
                GetEntity(TransformUsageFlags.Dynamic);
                AddComponent<InstantAttackTag>();
                
                AddComponent<AttackRequest>();
                SetComponentEnabled<AttackRequest>(false);
                
                AddComponent<AttackEvent>();
                SetComponentEnabled<AttackEvent>(false);
                
                AddComponent(new AttackCooldown() { MaxValue = authoring.AttackCooldown});
            }
        }
    }
}