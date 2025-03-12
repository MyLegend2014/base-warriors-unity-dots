using Unity.Entities;
using UnityEngine;

namespace Game.Gameplay.GameEntities.Common
{
    public class MoveDirectionAuthoring : MonoBehaviour
    {
        private class MoveDirectionAuthoringBaker : Baker<MoveDirectionAuthoring>
        {
            public override void Bake(MoveDirectionAuthoring authoring)
            {
                GetEntity(TransformUsageFlags.Dynamic);
                AddComponent(new MoveDirection());
            }
        }
    }
}