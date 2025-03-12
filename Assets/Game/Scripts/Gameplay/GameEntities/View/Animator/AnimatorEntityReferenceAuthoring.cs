using Sirenix.OdinInspector;
using Unity.Entities;
using UnityEngine;

namespace Game.Gameplay.GameEntities.View
{
    public class AnimatorEntityReferenceAuthoring : MonoBehaviour
    {
        [field: SerializeField, Required] public Animator Animator;
        
        private class AnimatorEntityAuthoringBaker : Baker<AnimatorEntityReferenceAuthoring>
        {
            public override void Bake(AnimatorEntityReferenceAuthoring referenceAuthoring)
            {
                Entity animatorEntity = GetEntity(referenceAuthoring.Animator.gameObject, TransformUsageFlags.Dynamic);

                GetEntity(TransformUsageFlags.Dynamic);
                AddComponent(new AnimatorEntityReference() { AnimatorEntity = animatorEntity });
            }
        }
    }
}