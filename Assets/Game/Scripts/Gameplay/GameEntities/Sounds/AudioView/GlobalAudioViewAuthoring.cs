using Unity.Entities;
using UnityEngine;

namespace Game.Gameplay.GameEntities.Sounds
{
    [RequireComponent(typeof(AudioSource))]
    public class GlobalAudioViewAuthoring : MonoBehaviour
    {
        private class GlobalAudioViewAuthoringBaker : Baker<GlobalAudioViewAuthoring>
        {
            public override void Bake(GlobalAudioViewAuthoring authoring)
            {
                Entity entity = GetEntity(TransformUsageFlags.Dynamic);
                AddComponent(new GlobalAudioView() { ViewEntity = entity });
            }
        }
    }
}