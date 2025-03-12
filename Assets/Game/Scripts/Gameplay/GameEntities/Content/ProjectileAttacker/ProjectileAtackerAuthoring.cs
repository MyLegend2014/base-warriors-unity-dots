using Game.Gameplay.GameEntities.Content;
using Sirenix.OdinInspector;
using Unity.Entities;
using UnityEngine;

namespace Game.Gameplay.GameEntities.Common
{
    public class ProjectileAtackerAuthoring : MonoBehaviour
    {
        [SerializeField] private Transform _spawnPoint;
        [SerializeField, Required, AssetsOnly] private ProjectileTagAuthoring _projectilePrefab;
        [SerializeField, MinValue(0)] private float _attackCooldown = 1f;

        private ProjectileTagAuthoring ProjectilePrefab => _projectilePrefab;
        
        private float AttackCooldown => _attackCooldown;
        
        private Transform SpawnPoint => _spawnPoint;
        
        private class ProjectileAtackerAuthoringBaker : Baker<ProjectileAtackerAuthoring>
        {
            public override void Bake(ProjectileAtackerAuthoring authoring)
            {
                GetEntity(TransformUsageFlags.Dynamic);
                AddComponent<ProjectileAttackerTag>();
                
                AddComponent<AttackRequest>();
                SetComponentEnabled<AttackRequest>(false);
                
                AddComponent<AttackEvent>();
                SetComponentEnabled<AttackEvent>(false);
                
                AddComponent(new AttackCooldown() { MaxValue = authoring.AttackCooldown});
                
                AddComponent(new ProjectilePrefab()
                {
                    Value = GetEntity(authoring.ProjectilePrefab, TransformUsageFlags.Dynamic)
                });
                
                AddComponent(new SpawnPoint() { Value = GetEntity(authoring.SpawnPoint, TransformUsageFlags.Dynamic)});
            }
        }
    }
}