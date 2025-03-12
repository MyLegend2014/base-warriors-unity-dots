using Unity.Entities;
using UnityEngine;

namespace Game.Gameplay.GameEntities.Common
{
    public class UnitTargetAuthoring : MonoBehaviour
    {
        private class TargetAuthoringBaker : Baker<UnitTargetAuthoring>
        {
            public override void Bake(UnitTargetAuthoring authoring)
            {
                GetEntity(TransformUsageFlags.Dynamic);
                AddComponent<TargetEntity>();
                AddComponent<TargetDistance>();
                AddComponent<TargetPosition>();
            }
        }
    }
}