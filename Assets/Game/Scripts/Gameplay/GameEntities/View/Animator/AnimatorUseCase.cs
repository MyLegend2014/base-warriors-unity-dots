using Rukhanka.Toolbox;
using Unity.Collections;

namespace Game.Gameplay.GameEntities.View
{
    public static class AnimatorUseCase
    {
        private static readonly FixedString512Bytes AttackEventName = "OnAttackAnimation";

        public static uint CreateAttackEventNameHash() => FixedStringExtensions.CalculateHash32(AttackEventName);
    }
}