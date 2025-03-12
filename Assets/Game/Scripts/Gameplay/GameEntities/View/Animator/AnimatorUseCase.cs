using Rukhanka.Toolbox;

namespace Game.Gameplay.GameEntities.View
{
    public static class AnimatorUseCase
    {
        private const string AttackEventName = "OnAttackAnimation";

        public static uint CreateAttackEventNameHash() => FixedStringExtensions.CalculateHash32(AttackEventName);
    }
}