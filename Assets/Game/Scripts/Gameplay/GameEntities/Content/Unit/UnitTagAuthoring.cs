using Unity.Entities;
using UnityEngine;

namespace Game.Gameplay.GameEntities.Content
{
    public class UnitTagAuthoring : MonoBehaviour
    {
        private class UnitAuthoringBaker : Baker<UnitTagAuthoring>
        {
            public override void Bake(UnitTagAuthoring tagAuthoring)
            {
                GetEntity(TransformUsageFlags.Dynamic);
                AddComponent<UnitTag>();
            }
        }
    }
}