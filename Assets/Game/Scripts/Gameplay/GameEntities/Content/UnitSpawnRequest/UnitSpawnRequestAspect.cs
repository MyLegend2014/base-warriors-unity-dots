using Game.Gameplay.GameEntities.Common;
using Game.Gameplay.GameEntities.Content;
using Unity.Entities;

namespace Game.Gameplay.GameEntities.Content
{
    public readonly partial struct UnitSpawnAspect : IAspect
    {
        private readonly RefRO<UnitSpawnRequest> _unitSpawnRequest;
        private readonly DynamicBuffer<SpawnPointBuffer> _unitSpawnPointsBuffer;
        private readonly DynamicBuffer<UnitPrefab> _unitsPrefabsBuffer;

        public readonly Entity Self;
        
        public Entity GetRandomUnitPrefab() =>
            _unitsPrefabsBuffer[UnityEngine.Random.Range(0, _unitsPrefabsBuffer.Length)].Value;
        
        public Entity GetRandomSpawnPoint() =>
            _unitSpawnPointsBuffer[UnityEngine.Random.Range(0, _unitSpawnPointsBuffer.Length)].Value;
    }
}