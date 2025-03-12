using Sirenix.OdinInspector;
using Unity.Entities;
using UnityEngine;

namespace Game.Gameplay.GameEntities.Sounds
{
    public class AudioViewReferenceAuthoring : MonoBehaviour
    {
        [field: SerializeField, Required] public AudioViewAuthoring AudioView;
        
        private class AudioViewLinkAuthoringBaker : Baker<AudioViewReferenceAuthoring>
        {
            public override void Bake(AudioViewReferenceAuthoring authoring)
            {
                GetEntity(TransformUsageFlags.Dynamic);
                Entity audioViewEntity = GetEntity(authoring.AudioView.gameObject, TransformUsageFlags.Dynamic);
                AddComponent(new AudioViewReference() { AudioView = audioViewEntity });
            }
        }
    }
}