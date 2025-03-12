using Sirenix.OdinInspector;
using UnityEngine;

namespace Game.Gameplay.Effects
{
    public class ParticlesPoolBehaviour : MonoBehaviour
    {
        [SerializeField, Required, AssetsOnly] private ParticleLauncher _prefab;
        [SerializeField, Required] private Transform _root;
        [SerializeField, MinValue(0)] private int _initialSize = 6;

        private ParticleLauncherPool _pool;

        private void Awake()
        {
            _pool = new ParticleLauncherPool(_prefab, _root, _initialSize);
        }

        [Button, HideInEditorMode]
        public void Play(Vector3 position)
        {
            ParticleLauncher launcher = _pool.Rent();
            launcher.transform.position = position;
            launcher.Play(position);
        }
    }
}