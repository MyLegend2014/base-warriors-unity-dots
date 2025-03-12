using Unity.Entities;
using UnityEngine;

namespace Game.Gameplay.GameEntities.Common
{
    public class MoveSpeedAuthoring : MonoBehaviour
    {
        [field: SerializeField] public float Value { get; private set; } = 10f;
        
        private class MoveSpeedAuthoringBaker : Baker<MoveSpeedAuthoring>
        {
            public override void Bake(MoveSpeedAuthoring authoring)
            {
                GetEntity(TransformUsageFlags.Dynamic);
                AddComponent(new MoveSpeed { Value = authoring.Value});
            }
        }
    }
}