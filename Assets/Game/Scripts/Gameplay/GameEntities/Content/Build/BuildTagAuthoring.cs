using Unity.Entities;
using UnityEngine;

namespace Game.Gameplay.GameEntities.Content
{
    public class BuildTagAuthoring : MonoBehaviour
    {
        private class BuildTagAuthoringBaker : Baker<BuildTagAuthoring>
        {
            public override void Bake(BuildTagAuthoring authoring)
            {
                GetEntity(TransformUsageFlags.Dynamic);
                AddComponent<BuildTag>();
            }
        }
    }
}