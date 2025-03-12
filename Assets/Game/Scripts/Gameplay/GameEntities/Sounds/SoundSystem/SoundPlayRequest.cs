using Game.Gameplay.GameEntities.Common;
using Unity.Entities;

namespace Game.Gameplay.GameEntities.Sounds
{
    public struct SoundPlayRequest : IBufferedRequest
    {
        public Entity AudioView;
        
        public SoundType SoundType;
    }
}