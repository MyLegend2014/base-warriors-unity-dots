using Unity.Entities;
using UnityEngine;

namespace Game.Gameplay.GameEntities.Content
{
    public class ProjectileTagAuthoring : MonoBehaviour
    {
        private class ProjectileTagAuthoringBaker : Baker<ProjectileTagAuthoring>
        {
            public override void Bake(ProjectileTagAuthoring authoring)
            {
                GetEntity(TransformUsageFlags.Dynamic);
                AddComponent<ProjectileTag>();
            }
        }
    }
}