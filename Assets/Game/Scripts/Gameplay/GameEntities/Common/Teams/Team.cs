using Game.Gameplay.GameEntites.Common;
using Unity.Entities;

namespace Game.Gameplay.GameEntities.Common
{
    public struct Team : IComponentData
    {
        public TeamColor Value;
    }
}