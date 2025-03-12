using System;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Game.Gameplay.Effects
{
    public sealed class ParticleLauncher : MonoBehaviour
    {
        [Required, ChildGameObjectsOnly]
        [field: SerializeField] public ParticleSystem ParticleSystem { get; private set; }

        private bool _isPlaying;
        
        public event Action<ParticleLauncher> Finished;

        public void Play(Vector3 position)
        {
            ParticleSystem.transform.position = position;
            ParticleSystem.Play();
            _isPlaying = true;
        }

        private void Update()
        {
            if (_isPlaying && ParticleSystem.isStopped)
            {
                Finished?.Invoke(this);
                _isPlaying = false;
            }
        }
    }
}