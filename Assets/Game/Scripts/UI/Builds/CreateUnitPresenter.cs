using System.Collections;
using System.Collections.Generic;
using Game.Gameplay.GameEntites.Common;
using Game.Gameplay.GameEntities.Common;
using Game.Gameplay.GameEntities.Content;
using Unity.Collections;
using Unity.Entities;
using Unity.Transforms;
using UnityEngine;
using UnityEngine.UI;

namespace Game.Scripts.UI.Builds
{
    public class CreateUnitPresenter : MonoBehaviour
    {
        [SerializeField] private TeamColor _team;
        [SerializeField] private Button _button;

        private List<Entity> _buildEntities = new();
        private EntityManager _entityManager;

        private IEnumerator Start()
        {
            yield return new WaitUntil(() => World.DefaultGameObjectInjectionWorld.IsCreated);
            
            _entityManager = World.DefaultGameObjectInjectionWorld.EntityManager;
            EntityQuery query = _entityManager.CreateEntityQuery(typeof(BuildTag));

            if (query.CalculateEntityCount() > 0)
            {
                using (NativeArray<Entity> entities = query.ToEntityArray(Unity.Collections.Allocator.TempJob))
                {
                    foreach (Entity entity in entities)
                    {
                        Team team = _entityManager.GetComponentData<Team>(entity);

                        if (team.Value != _team)
                            continue;
                    
                        _buildEntities.Add(entity);
                    }
                }
            }
        }

        private void OnEnable()
        {
            _button.onClick.AddListener(OnButtonClick);
        }
        
        private void OnDisable()
        {
            _button.onClick.RemoveListener(OnButtonClick);
        }

        private void OnButtonClick()
        {
            _buildEntities.ForEach(buildEntity =>
            {
                if (buildEntity != Entity.Null && _entityManager.HasComponent<LocalTransform>(buildEntity))
                    _entityManager.SetComponentEnabled<UnitSpawnRequest>(buildEntity, true);
            });
        }
    }
}