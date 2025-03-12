using Unity.Entities;
using UnityEngine;

namespace Game.Gameplay.GameEntities.Sounds
{
    [RequireComponent(typeof(AudioSource))]
    public class AudioViewAuthoring : MonoBehaviour
    {
        private class AudioViewAuthoringBaker : Baker<AudioViewAuthoring>
        {
            public override void Bake(AudioViewAuthoring authoring)
            {
                GetEntity(TransformUsageFlags.Dynamic);
                AddComponent<AudioViewTag>();
                AddBuffer<SoundPlayRequest>();
                SetComponentEnabled<SoundPlayRequest>(false);
            }
        }
    }
}