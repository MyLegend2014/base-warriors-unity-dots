using Modules.ObjectsManagement.Pools;
using UnityEngine;

namespace Game.Gameplay.Effects
{
    public sealed class ParticleLauncherPool : Pool<ParticleLauncher>
    {
        public ParticleLauncherPool(ParticleLauncher prefab, Transform root) : base(prefab, root)
        {
        }

        public ParticleLauncherPool(ParticleLauncher prefab, Transform root, int initialCapacity) 
            : base(prefab, root, initialCapacity)
        {
        }
        
        protected override void OnSpawned(ParticleLauncher particleLauncher)
        {
            base.OnSpawned(particleLauncher);
            particleLauncher.Finished += OnFinish;
        }

        private void OnFinish(ParticleLauncher particleLauncher)
        {
            particleLauncher.Finished -= OnFinish;
            Return(particleLauncher);
        }
    }
}